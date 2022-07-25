using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Core.Entities.Concrete;
using MvcUI.Models;

namespace MvcUI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<User> _usermanager; //kullanıcı yönetimi
        

        public AccountController(UserManager<User> usermanager, SignInManager<User> signInManager)
        {
            _usermanager = usermanager;
            _signInManager = signInManager;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string ReturnUrl = null) //kullanıcıyı loginden önceyi sayfaya yönlendirmemiz gerek login olduktan sonra bu yüzden return urli alıyoruz burada
        {
            return View(new LoginViewModel
            {
                ReturnUrl = ReturnUrl //bunu daha sonra input hiddenda tutarız (yanlis bir şeyler girildiğinde tekrar post metodundan geleceği için return url boş gelmesin)
            });
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _usermanager.FindByEmailAsync(model.Email); //username var mı diye control

            if (user == null)
            {
                ModelState.AddModelError("", "Hatalı");
                return View(model);
            }



            var result =

            if (result.Succeeded)
            {
                return Redirect(model.ReturnUrl ?? "~/"); //null sa home pageye git dedik.
            }
            ModelState.AddModelError("", "Girilen email veya şifre yanlış");

            return View(model);
        }
    }
}
