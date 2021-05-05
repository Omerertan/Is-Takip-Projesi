using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.DTO.DTOs.GorevDtos;
using YSKProje.ToDo.Entities.Concrete;
using YSKProje.ToDo.Web.StringInfo;

namespace YSKProje.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class GorevController : Controller
    {
        private readonly IGorevService _gorevService;
        private readonly IAciliyetService _aciliyetService;
        private readonly IMapper _mapper;
        public GorevController(IGorevService gorevService, IAciliyetService aciliyetService, IMapper mapper)
        {
            _gorevService = gorevService;
            _aciliyetService = aciliyetService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            //List<Gorev> gorevler = _gorevService.GetirAciliyetileTamamlanmayan();
            //List<GorevListViewModel> models = new List<GorevListViewModel>();

            //foreach (var item in gorevler)
            //{
            //    GorevListViewModel model = new GorevListViewModel
            //    {
            //        Id = item.Id,
            //        Ad = item.Ad,
            //        Aciklama = item.Aciklama,
            //        Aciliyet = item.Aciliyet,
            //        AciliyetId = item.AciliyetId,
            //        Durum = item.Durum,
            //        OlusturulmaTarih = item.OlusturulmaTarih,

            //    };
            //    models.Add(model);
            //}

            TempData["Active"] = TempdataInfo.Gorev;
            return View(_mapper.Map<List<GorevListDto>>(_gorevService.GetirAciliyetileTamamlanmayan()));
        }
        public IActionResult EkleGorev()
        {
            TempData["Active"] = TempdataInfo.Gorev;
            ViewBag.Aciliyetler = new SelectList(_aciliyetService.GetirHepsi(), "Id","Tanim");
            return View(new GorevAddDto());
        }
        [HttpPost]
        public IActionResult EkleGorev(GorevAddDto model)
        {
            if (ModelState.IsValid)
            {
                _gorevService.Kaydet(new Gorev 
                {
                    Ad = model.Ad,
                    AciliyetId = model.AciliyetId,
                    Aciklama = model.Aciklama
                });
                return RedirectToAction("Index");
            }
            ViewBag.Aciliyetler = new SelectList(_aciliyetService.GetirHepsi(), "Id", "Tanim");
            return View(model);
        }
        public IActionResult GorevGuncelle(int id)
        {
            //var gorev = _gorevService.GetirIdile(id);
            //GorevUpdateViewModel model = new GorevUpdateViewModel 
            //{
            //    Id = gorev.Id,
            //    Ad = gorev.Ad,
            //    Aciklama = gorev.Aciklama,
            //    AciliyetId = gorev.AciliyetId
            //};

            TempData["Active"] = TempdataInfo.Gorev;
            var gorev = _gorevService.GetirIdile(id);
            ViewBag.Aciliyetler = new SelectList(_aciliyetService.GetirHepsi(), "Id", "Tanim", gorev.AciliyetId);

            return View(_mapper.Map<GorevUpdateDto>(gorev));
        }
        [HttpPost]
        public IActionResult GorevGuncelle(GorevUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                _gorevService.Guncelle(new Gorev
                {
                    Id = model.Id,
                    Ad = model.Ad,
                    Aciklama = model.Aciklama,
                    AciliyetId = model.AciliyetId
                });
                
                return RedirectToAction("Index");
            }
            ViewBag.Aciliyetler = new SelectList(_aciliyetService.GetirHepsi(), "Id", "Tanim", model.AciliyetId);
            return View(model);
        }

        public IActionResult SilGorev(int id)
        {
            _gorevService.Sil(new Gorev { Id = id });
            return Json(null);
        }

    }
}
