using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.DTO.DTOs.GorevDtos;
using YSKProje.ToDo.DTO.DTOs.RaporDtos;
using YSKProje.ToDo.Entities.Concrete;
using YSKProje.ToDo.Web.BaseControllers;
using YSKProje.ToDo.Web.StringInfo;

namespace YSKProje.ToDo.Web.Areas.Member.Controllers
{
    [Area(AreaInfo.Member)]
    [Authorize(Roles = RoleInfo.Member)]
    public class IsEmriController : BaseIdentityController
    {
        private readonly IGorevService _gorevService;
        private readonly IRaporService _raporService;
        private readonly IBildirimService _bildirimService;
        private readonly IMapper _mapper;
        public IsEmriController(IGorevService gorevService, UserManager<AppUser> userManager, IRaporService raporService, IBildirimService bildirimService, IMapper mapper) :base (userManager)
        {
            _gorevService = gorevService;
            _raporService = raporService;
            _bildirimService = bildirimService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            //var gorevler = _gorevService.GetirTumTablolarla(I => I.AppUserId == user.Id && !I.Durum);
            //List<GorevListAllViewModel> models = new List<GorevListAllViewModel>();

            //foreach (var item in gorevler)
            //{
            //    GorevListAllViewModel model = new GorevListAllViewModel();
            //    model.Id = item.Id;
            //    model.Ad = item.Ad;
            //    model.Aciklama = item.Aciklama;
            //    model.Aciliyet = item.Aciliyet;
            //    model.AppUser = item.AppUser;
            //    model.Raporlar = item.Raporlar;
            //    model.OlusturulmaTarih = item.OlusturulmaTarih;
            //    models.Add(model);
            //}

            TempData["Active"] = TempdataInfo.IsEmri;

            var user = await GetirGirisYapanKullanici();

            return View(_mapper.Map<List<GorevListAllDto>>(_gorevService.GetirTumTablolarla(I => I.AppUserId == user.Id && !I.Durum)));
        }

        public IActionResult EkleRapor(int id)
        {
            var gorev = _gorevService.GetirAciliyetileId(id);

            RaporAddDto model = new RaporAddDto
            {
                GorevId = id,
                Gorev = gorev
            };

            TempData["Active"] = TempdataInfo.IsEmri;

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EkleRapor(RaporAddDto model)
        {
            if (ModelState.IsValid)
            {
                _raporService.Kaydet(new Rapor
                {
                    Tanim = model.Tanim,
                    Detay = model.Detay,
                    GorevId = model.GorevId
                });

                var adminUserList = await _userManager.GetUsersInRoleAsync("Admin");
                var aktifKullanici = await GetirGirisYapanKullanici();
                foreach (var admin in adminUserList)
                {
                    _bildirimService.Kaydet(new Bildirim
                    {
                        Aciklama = $"{aktifKullanici.Name} {aktifKullanici.SurName} yeni bir rapor yazdı.",
                        AppUserId = admin.Id,
                    });
                }

                return RedirectToAction("Index");

            }


            return View(model);
        }

        public IActionResult GuncelleRapor(int id)
        {
            //var rapor = _raporService.GetirGorevileId(id);
            //RaporUpdateViewModel model = new RaporUpdateViewModel();
            //model.Id = rapor.Id;
            //model.Tanim = rapor.Tanim;
            //model.Detay = rapor.Detay;
            //model.Gorev = rapor.Gorev;
            //model.GorevId = rapor.GorevId;

            TempData["Active"] = TempdataInfo.IsEmri;
            return View(_mapper.Map<RaporUpdateDto>(_raporService.GetirGorevileId(id)));
        }
        [HttpPost]
        public IActionResult GuncelleRapor(RaporUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                var guncellenecekRapor = _raporService.GetirIdile(model.Id);
                guncellenecekRapor.Tanim = model.Tanim;
                guncellenecekRapor.Detay = model.Detay;

                _raporService.Guncelle(guncellenecekRapor);

                return RedirectToAction("Index");
            }

            return View(model);
        }
        public async Task<IActionResult> TamamlaGorev(int gorevId)
        {
            var guncellenecekGorev = _gorevService.GetirIdile(gorevId);
            guncellenecekGorev.Durum = true;
            _gorevService.Guncelle(guncellenecekGorev);

            var adminUserList = await _userManager.GetUsersInRoleAsync("Admin");
            var aktifKullanici = await GetirGirisYapanKullanici();
            foreach (var admin in adminUserList)
            {
                _bildirimService.Kaydet(new Bildirim
                {
                    Aciklama = $"{aktifKullanici.Name} {aktifKullanici.SurName} görevi tamamladı.",
                    AppUserId = admin.Id,
                });
            }

            return Json(null);
        }
    }
}
