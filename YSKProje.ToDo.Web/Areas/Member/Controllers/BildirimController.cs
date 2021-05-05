using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.DTO.DTOs.BildirimDtos;
using YSKProje.ToDo.Entities.Concrete;
using YSKProje.ToDo.Web.BaseControllers;
using YSKProje.ToDo.Web.StringInfo;

namespace YSKProje.ToDo.Web.Areas.Member.Controllers
{
    [Area(AreaInfo.Member)]
    [Authorize(Roles = RoleInfo.Member)]
    public class BildirimController : BaseIdentityController
    {
        private readonly IBildirimService _bildirimService;
        private readonly IMapper _mapper;
        public BildirimController(IBildirimService bildirimService, UserManager<AppUser> userManager, IMapper mapper) : base (userManager)
        {
            _bildirimService = bildirimService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            //var bildirimler = _bildirimService.GetirOkunmayanlar(user.Id);
            //List<BildirimListViewModel> models = new List<BildirimListViewModel>();
            //foreach (var bildirim in bildirimler)
            //{
            //    BildirimListViewModel model = new BildirimListViewModel();
            //    model.Id = bildirim.Id;
            //    model.Aciklama = bildirim.Aciklama;
            //    models.Add(model);
            //}

            TempData["Active"] = TempdataInfo.Bildirim;
            var user = await GetirGirisYapanKullanici();
            return View(_mapper.Map<List<BildirimListDto>>(_bildirimService.GetirOkunmayanlar(user.Id)));
        }
        [HttpPost]
        public IActionResult Index(int id)
        {
            var bildirim = _bildirimService.GetirIdile(id);
            bildirim.Durum = true;

            _bildirimService.Guncelle(bildirim);
            return RedirectToAction("Index");
        }
    }
}
