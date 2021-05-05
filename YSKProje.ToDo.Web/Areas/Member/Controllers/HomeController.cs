﻿using System;
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

namespace YSKProje.ToDo.Web.Areas.Member.Controllers
{
    [Area(AreaInfo.Member)]
    [Authorize(Roles = RoleInfo.Member)]
    public class HomeController : BaseIdentityController
    {
        private readonly IRaporService _raporService;
        private readonly IGorevService _gorevService;
        private readonly IBildirimService _bildirimService;
        public HomeController(IRaporService raporService, UserManager<AppUser> userManager, IGorevService gorevService, IBildirimService bildirimService) : base(userManager)
        {
            _raporService = raporService;
            _gorevService = gorevService;
            _bildirimService = bildirimService;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = TempdataInfo.Anasayfa;
            var user = await GetirGirisYapanKullanici();

            ViewBag.RaporSayisi = _raporService.GetirRaporSayisiileAppUserId(user.Id);
            ViewBag.TamamamlananGorevSayisi = _gorevService.GetirGorevSayisiTamamlananileAppUserId(user.Id);
            ViewBag.MevcutGorevSayisi = _gorevService.GetirGorevSayisiileTamamlanmayanileAppUserId(user.Id);
            ViewBag.TamamlanmayanGorevSayisi = _bildirimService.GetirOkunmayansayisiileAppUserId(user.Id);
            return View();
        }
    }
}
