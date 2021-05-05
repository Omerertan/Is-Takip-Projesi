using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.DTO.DTOs.AppUserDtos;
using YSKProje.ToDo.Entities.Concrete;
using YSKProje.ToDo.Web.BaseControllers;

namespace YSKProje.ToDo.Web.Controllers
{
    public class HomeController : BaseIdentityController
    {
        private readonly SignInManager<AppUser> _signManager;
        private readonly ICustomLogger _customLogger;
        public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signManager, ICustomLogger customLogger) : base(userManager)
        {
            _signManager = signManager;
            _customLogger = customLogger;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GirisYap(AppUserSignInDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    var identityResult = await _signManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
                    if (identityResult.Succeeded)
                    {
                        var roller = await _userManager.GetRolesAsync(user);
                        if (roller.Contains("Admin"))
                        {
                            return RedirectToAction("Index", "Home", new { area = "Admin" });
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home", new { area = "Member" });

                        }
                    }

                }
                ModelState.AddModelError("", "Kullanıcı adı veya Parola hatalı");
            }
            return View("Index", model);
        }
        public IActionResult KayitOl()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> KayitOl(AppUserAddDto model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    Name = model.Name,
                    SurName = model.SurName,
                    UserName = model.UserName,
                    Email = model.Email

                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {

                    var addRoleResult = await _userManager.AddToRoleAsync(user, "Member");
                    if (addRoleResult.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        HataEkle(addRoleResult.Errors);
                    }
                }
                else
                {
                    HataEkle(result.Errors);
                }

            }

            return View(model);
        }

        public async Task<IActionResult> CikisYap()
        {
            await _signManager.SignOutAsync();
            return RedirectToAction("Index");
        }
        public IActionResult StatusCode(int? code)
        {
            if (code == 404)
            {
                ViewBag.Code = code;
                ViewBag.Message = "Sayfa Bulunamadı";
            }
            return View();
        }
        public IActionResult Error() 
        {
            var exceptionHandler = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            _customLogger.LogError($"Hatanın oluştuğu yer :{exceptionHandler.Path} /n Hatanın mesajı :{exceptionHandler.Error.Message} /n Stack tree :{exceptionHandler.Error.StackTrace}");

            ViewBag.Path = exceptionHandler.Path;
            ViewBag.Message = exceptionHandler.Error.Message;
            return View();
        }

        public void Hata() 
        {
            throw new Exception("Bu bir hata");
        }
    }
}
