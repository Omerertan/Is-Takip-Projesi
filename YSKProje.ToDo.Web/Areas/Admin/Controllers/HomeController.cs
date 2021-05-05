using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.Entities.Concrete;
using YSKProje.ToDo.Web.BaseControllers;
using YSKProje.ToDo.Web.StringInfo;

namespace YSKProje.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class HomeController : BaseIdentityController
    {
        private readonly IGorevService _gorevservice;
        private readonly IBildirimService _bildirimService;
        private readonly IRaporService _raporService;
        public HomeController(IGorevService gorevService, IBildirimService bildirimService, UserManager<AppUser> userManager, IRaporService raporService) : base(userManager)
        {
            _gorevservice = gorevService;
            _bildirimService = bildirimService;
            _raporService = raporService;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = TempdataInfo.Anasayfa;
            var user = await  GetirGirisYapanKullanici();

            ViewBag.atanmayıBekleyenGorevSayisi = _gorevservice.GetirAtanmayiBekleyenGorevSayisi();
            ViewBag.tamamlanmısGorevSayisi = _gorevservice.GetirGorevTamamlanmis();
            ViewBag.okunmamısBildirimSayisi = _bildirimService.GetirOkunmayansayisiileAppUserId(user.Id);
            ViewBag.tumRaporSayisi = _raporService.GetirRaporSayisi();
            return View();
        }
    }
}
