﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using StockTrackingApp.UI.Models;

namespace StockTrackingApp.UI.Controllers
{
    public class LoginController : BaseController
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
 

        public LoginController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
    
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(LoginVM model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null)
            {
                NotifyError("Email veya şifre hatalı");
                return View(model);
            }

            var checkPass = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

            if (!checkPass.Succeeded)
            {
                NotifyError("Email veya şifre hatalı");
                return View(model);
            }

            var userRole = await _userManager.GetRolesAsync(user);
            if (userRole is null)
            {
                NotifyError("Kullanıcıya ait rol bulunamadı");
                return View(model);
            }
            TempData["Login"] = "ok";
            Json(new { success = true });
            return RedirectToAction("Index", "Home", new { Area = userRole[0].ToString() });
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> AccessDenied(AccessDeniedVM? accessDeniedVM)
        {
            var user = await _userManager.GetUserAsync(User);
            var userRole = await _userManager.GetRolesAsync(user);

            if (accessDeniedVM != null)
            {
                if (accessDeniedVM.AreaName == null)
                {
                    accessDeniedVM.AreaName = userRole[0].ToString();
                }
                return View(accessDeniedVM);
            }
            else
            {
                accessDeniedVM = new AccessDeniedVM();
                accessDeniedVM.AreaName = userRole[0].ToString();
                return View(accessDeniedVM);
            }

        }


        public async Task<IActionResult> ForgotPassword()
        {
            return View();
        }


        //[HttpPost]

        //public async Task<IActionResult> ForgotPassword(ForgotPasswordVM model)
        //{
        //    if (!ModelState.IsValid)
        //        return View(model);

        //    var user = await _userManager.FindByEmailAsync(model.Email);
        //    if (user == null)
        //    {
        //        // Kullanıcı yoksa bile hata göstermeyelim, güvenlik açısından
        //        return View("ForgotPasswordConfirmation");
        //    }

        //    // Şifre sıfırlama tokeni oluştur
        //    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        //    var resetLink = Url.Action("ResetPassword", "Account",
        //        new { token, email = user.Email }, Request.Scheme);

        //    // E-posta gönder (SMTP ayarlarını kullanarak)
        //    await _emailSender.SendEmailAsync(user.Email, "Şifre Sıfırlama",
        //        $"Şifrenizi sıfırlamak için <a href='{resetLink}'>buraya tıklayın</a>.");

        //    return View("ForgotPasswordConfirmation");
        //}

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return RedirectToAction("ResetPasswordConfirmation");

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);
            if (result.Succeeded)
                return RedirectToAction("ResetPasswordConfirmation");

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(model);
        }


    }
}
