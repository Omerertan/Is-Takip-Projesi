using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.DTO.DTOs.AppUserDtos;
using YSKProje.ToDo.DTO.DTOs.GorevDtos;
using YSKProje.ToDo.DTO.DTOs.RaporDtos;
using YSKProje.ToDo.Entities.Concrete;
using YSKProje.ToDo.Web.StringInfo;

namespace YSKProje.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class IsEmriController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IGorevService _gorevService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IDosyaService _dosyaService;
        private readonly IBildirimService _bildirimService;
        private readonly IMapper _mapper;
        public IsEmriController(IAppUserService appUserService, IGorevService gorevService, UserManager<AppUser> userManager, IDosyaService dosyaService, IBildirimService bildirimService, IMapper mapper)
        {
            _appUserService = appUserService;
            _gorevService = gorevService;
            _userManager = userManager;
            _dosyaService = dosyaService;
            _bildirimService = bildirimService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            //List<Gorev> gorevler = _gorevService.GetirTumTablolarla();

            //List<GorevListAllViewModel> models = new List<GorevListAllViewModel>();

            //foreach (var item in gorevler)
            //{
            //    GorevListAllViewModel model = new GorevListAllViewModel();
            //    model.Id = item.Id;
            //    model.Aciklama = item.Aciklama;
            //    model.Aciliyet = item.Aciliyet;
            //    model.Ad = item.Ad;
            //    model.AppUser = item.AppUser;
            //    model.OlusturulmaTarih = item.OlusturulmaTarih;
            //    model.Raporlar = item.Raporlar;
            //    models.Add(model);
            //}
            TempData["Active"] = TempdataInfo.IsEmri;
            return View(_mapper.Map<List<GorevListAllDto>>(_gorevService.GetirTumTablolarla()));
        }

        public IActionResult Detaylandir(int id)
        {
            //var gorev = _gorevService.GetirRaporlarileId(id);
            //GorevListAllViewModel model = new GorevListAllViewModel();
            //model.Id = gorev.Id;
            //model.Ad = gorev.Ad;
            //model.Raporlar = gorev.Raporlar;
            //model.Aciklama = gorev.Aciklama;
            //model.AppUser = gorev.AppUser;

            TempData["Active"] = TempdataInfo.IsEmri;
            return View(_mapper.Map<GorevListAllDto>(_gorevService.GetirRaporlarileId(id)));
        }
        public IActionResult GetirExcel(int id)
        {
            return File(_dosyaService.AktarExcel(_mapper.Map<List<RaporDosyaDto>>(_gorevService.GetirRaporlarileId(id).Raporlar)), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", Guid.NewGuid() + ".xlsx");
        }
        public IActionResult GetirPdf(int id)
        {
            var path = _dosyaService.AktarPdf(_mapper.Map<List<RaporDosyaDto>>(_gorevService.GetirRaporlarileId(id).Raporlar));
            return File(path, "application/pdf", Guid.NewGuid() + ".pdf");
        }
        public IActionResult AtaPersonel(int id, string s, int sayfa = 1)
        {
            //ViewBag.ToplamSayfa = (int)Math.Ceiling((double)_appUserService.GetirAdminOlmayanlar().Count / 3);

            //var personeller = _appUserService.GetirAdminOlmayanlar(out toplamSayfa, s, sayfa);
            //List<AppUserListViewModel> appUserListModel = new List<AppUserListViewModel>();
            //foreach (var item in personeller)
            //{
            //    AppUserListViewModel model = new AppUserListViewModel();
            //    model.Id = item.Id;
            //    model.Name = item.Name;
            //    model.SurName = item.SurName;
            //    model.Email = item.Email;
            //    model.Picture = item.Picture;
            //    appUserListModel.Add(model);
            //}

            //var gorev = _gorevService.GetirAciliyetileId(id);

            //GorevListViewModel gorevModel = new GorevListViewModel();
            //gorevModel.Id = gorev.Id;
            //gorevModel.Ad = gorev.Ad;
            //gorevModel.Aciklama = gorev.Aciklama;
            //gorevModel.Aciliyet = gorev.Aciliyet;
            //gorevModel.OlusturulmaTarih = gorev.OlusturulmaTarih;

            TempData["Active"] = TempdataInfo.IsEmri;
            ViewBag.AktifSayfa = sayfa;
            ViewBag.Aranan = s;

            var personeller = _mapper.Map<List<AppUserListDto>>(_appUserService.GetirAdminOlmayanlar(out int toplamSayfa, s, sayfa));
            ViewBag.ToplamSayfa = toplamSayfa;
            ViewBag.Personeller = personeller;

            return View(_mapper.Map<GorevListDto>(_gorevService.GetirAciliyetileId(id)));
        }
        [HttpPost]
        public IActionResult AtaPersonel(PersonelGorevlendirDto model)
        {
            var guncellencekGorev = _gorevService.GetirIdile(model.GorevId);
            guncellencekGorev.AppUserId = model.PersonelId;
            _gorevService.Guncelle(guncellencekGorev);

            _bildirimService.Kaydet(new Bildirim
            {
                AppUserId = model.PersonelId,
                Aciklama = $"{guncellencekGorev.Ad} adlı iş için görevlendirildiniz."
            });

            return RedirectToAction("Index");
        }

        public IActionResult GorevlendirPersonel(PersonelGorevlendirDto model)
        {

            //var user = _userManager.Users.FirstOrDefault(I => I.Id == model.PersonelId);
            //AppUserListViewModel userModel = new AppUserListViewModel();
            //userModel.Id = user.Id;
            //userModel.Name = user.Name;
            //userModel.SurName = user.SurName;
            //userModel.Picture = user.Picture;
            //userModel.Email = user.Email;

            //var gorev = _gorevService.GetirAciliyetileId(model.GorevId);
            //GorevListViewModel gorevModel = new GorevListViewModel();
            //gorevModel.Id = gorev.Id;
            //gorevModel.Ad = gorev.Ad;
            //gorevModel.Aciklama = gorev.Aciklama;
            //gorevModel.Aciliyet = gorev.Aciliyet;
            //PersonelGorevlendirListDto personelGorevlendirModel = new PersonelGorevlendirListDto();
            //personelGorevlendirModel.AppUser = userModel;
            //personelGorevlendirModel.Gorev = gorevModel;

            TempData["Active"] = TempdataInfo.IsEmri;

            PersonelGorevlendirListDto personelGorevlendirModel = new PersonelGorevlendirListDto
            {
                AppUser = _mapper.Map<AppUserListDto>(_userManager.Users.FirstOrDefault(I => I.Id == model.PersonelId)),
                Gorev = _mapper.Map<GorevListDto>(_gorevService.GetirAciliyetileId(model.GorevId))
            };

            return View(personelGorevlendirModel);
        }

    }

}

