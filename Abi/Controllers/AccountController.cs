using Abi.Models;
using Abi.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Abi.Controllers
{
    public class AccountController(UserManager<AppUser> _userManager,SignInManager<AppUser> _signInManager) : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var existUser=await _userManager.FindByNameAsync(vm.UserName);
            if (existUser != null)
            {
                ModelState.AddModelError("UserName", "Abi BU User VAR UJE");
            }
            existUser=await _userManager.FindByEmailAsync(vm.EmailAddress);
            if (existUser != null)
            {
                ModelState.AddModelError("EmailAddress", "Abi BU Email VAR UJE");
            }
            AppUser appUser = new()
            {
                UserName = vm.UserName,
                Email = vm.EmailAddress,
                FullName=vm.FullName
            };
            var pas=await _userManager.CreateAsync(appUser, vm.Password);
            if (!pas.Succeeded)
            {
            }
            return RedirectToAction("Index","Home");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var emailResult = await _userManager.FindByEmailAsync(vm.EmailAddress);
            if (emailResult is null)
            {
                ModelState.AddModelError("", "Sehv daxil edrisen");
                return View(vm);
            }
            var loginResult = await _userManager.CheckPasswordAsync(emailResult, vm.Password);
            if (!loginResult)
            {
                ModelState.AddModelError("", "Sehv daxil edrisen");
                return View(vm);
            }
            await _signInManager.SignInAsync(emailResult, vm.IsRememberMe);
            return RedirectToAction("Index", "Home");
        }
       [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}
