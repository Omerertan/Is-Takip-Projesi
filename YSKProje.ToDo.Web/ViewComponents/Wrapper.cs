using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.DTO.DTOs.AppUserDtos;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.Web.ViewComponents
{
    public class Wrapper : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IBildirimService _bildirimService;
        private readonly IMapper _mapper;
        public Wrapper(UserManager<AppUser> userManager, IBildirimService bildirimService, IMapper mapper)
        {
            _userManager = userManager;
            _bildirimService = bildirimService;
            _mapper = mapper;
        }
        public IViewComponentResult Invoke()
        {
            //var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            //AppUserListViewModel model = new AppUserListViewModel();
            //model.Id = user.Id;
            //model.Name = user.Name;
            //model.SurName = user.SurName;
            //model.Email = user.Email;
            //model.Picture = user.Picture;
            var identityUser = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var model = _mapper.Map<AppUserListDto>(identityUser);

            var bildirimSayisi = _bildirimService.GetirOkunmayanlar(model.Id).Count();
            ViewBag.BildirimSayisi = bildirimSayisi;

            var roles = _userManager.GetRolesAsync(identityUser).Result;

            if (roles.Contains("Admin"))
            {
                return View(model);
            }
            return View("Member", model);
        }
    }
}
