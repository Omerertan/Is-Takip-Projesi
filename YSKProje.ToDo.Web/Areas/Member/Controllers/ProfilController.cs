using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using YSKProje.ToDo.DTO.DTOs.AppUserDtos;
using YSKProje.ToDo.Entities.Concrete;
using YSKProje.ToDo.Web.BaseControllers;
using YSKProje.ToDo.Web.StringInfo;

namespace YSKProje.ToDo.Web.Areas.Member.Controllers
{
    [Area(AreaInfo.Member)]
    [Authorize(Roles = RoleInfo.Member)]
    public class ProfilController : BaseIdentityController
    {
        private readonly IMapper _mapper;
        public ProfilController(UserManager<AppUser> userManager, IMapper mapper) : base(userManager)
        {
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            //var appUser = await _userManager.FindByNameAsync(User.Identity.Name);

            //AppUserListViewModel model = new AppUserListViewModel();
            //model.Id = appUser.Id;
            //model.Name = appUser.Name;
            //model.SurName = appUser.SurName;
            //model.Email = appUser.Email;
            //model.Picture = appUser.Picture;

            TempData["Active"] = TempdataInfo.Profil;
            return View(_mapper.Map<AppUserListDto>(await GetirGirisYapanKullanici()));
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUserListDto model, IFormFile resim)
        {
            if (ModelState.IsValid)
            {
                var guncellenecekKullanici = _userManager.Users.FirstOrDefault(I => I.Id == model.Id);
                if (resim != null)
                {
                    string uzanti = Path.GetExtension(resim.FileName);
                    string resimAd = Guid.NewGuid() + uzanti;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + resimAd);

                    using var stream = new FileStream(path, FileMode.Create);
                    await resim.CopyToAsync(stream);

                    guncellenecekKullanici.Picture = resimAd;
                }
                guncellenecekKullanici.Name = model.Name;
                guncellenecekKullanici.SurName = model.SurName;
                guncellenecekKullanici.Email = model.Email;

                var result = await _userManager.UpdateAsync(guncellenecekKullanici);
                if (result.Succeeded)
                {
                    TempData["message"] = "Güncelleme işleminiz başarı ile gerçekleştirildi.";
                    return RedirectToAction("Index");
                }
                else
                {
                    HataEkle(result.Errors);
                }

            }

            return View(model);

        }

    }
}
