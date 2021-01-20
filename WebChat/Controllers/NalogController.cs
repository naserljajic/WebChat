using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebChat.Models;

namespace WebChat.Controllers
{
    public class NalogController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<Korisnik> _userManager;
        private readonly SignInManager<Korisnik> _signInManager;
        public NalogController(IMapper mapper, UserManager<Korisnik> userManager, SignInManager<Korisnik> signInManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Registracija()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registracija(KorisnikRegistrationModel userModel)
        {
            if(!ModelState.IsValid)
            {
                return View(userModel);
            }
            var user = _mapper.Map<Korisnik>(userModel);
            var result = await _userManager.CreateAsync(user, userModel.Sifra);
            if(!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return View(userModel);
            }
            if(userModel.Email == "admin@admin.com")
            {
                await _userManager.AddToRoleAsync(user, "Admin");
            }else if(userModel.Email == "mod@mod.com")
            {
                await _userManager.AddToRoleAsync(user, "Moderator");
            }
            else
            {
                await _userManager.AddToRoleAsync(user, "Korisnik");
            }

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
        [HttpGet]
        public IActionResult Prijava(string returnUrl= null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Prijava(KorisnikLoginModel userModel, string returnUrl = null)
        {
            if(!ModelState.IsValid)
            {
                return View(userModel);
            }
            var result = await _signInManager.PasswordSignInAsync(userModel.KorisnickoIme, userModel.Sifra, userModel.ZapamtiMe, false);
            if (result.Succeeded)
            {
                return RedirectToLocal(returnUrl);
            }
            else
            {
                ModelState.AddModelError("", "Korisnicko ime ili sifra nisu tacno uneti!");
                return View();
            }
            
        }
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            else
                return RedirectToAction(nameof(HomeController.Index), "Home");

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OdjaviSe()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }


    }
}
