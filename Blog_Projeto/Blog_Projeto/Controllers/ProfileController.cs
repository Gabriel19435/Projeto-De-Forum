using Blog_Projeto.Models;
using Blog_Projeto.Models.dto;
using Blog_Projeto.Services.Profile.Profile_Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Site_Blog.Controllers
{
    public class ProfileController : Controller
    {
        private readonly Profile_Facade Facade;
        public ProfileController(Profile_Facade _Facade)
        {
            Facade = _Facade;
        }
        [HttpGet]
        public async Task<IActionResult> UserPage(int Owner)
        {
            var response = await Facade.Model.UserPage(Owner);
            ViewData["NumPosts"] = response.Item1.ViewMessage;
            ViewData["UserPhoto"] = response.Item2;
            ViewData["UserName"] = response.Item3;
            ViewData["Data"] = response.Item4;
            ViewData["UserDesc"] = response.Item5;
            ViewData["Owner"] = Owner;
            return View(response.Item1.Model);
        }
        //Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(DadosUser_dto User)
        {
            if (ModelState.IsValid)
            {
                var item = await Facade.Model.RegisterUser(User);                               
                if (item.Erro)
                {
                    ViewData["Erro"] = item.ViewMessage;
                    return View();
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["Erro"] = "Complete The Formulariun";
                return View();
            }
        }

        //Login
        [HttpGet]
        public IActionResult Login()
        {            
            return View();
        }
        [HttpPost]       
        public async Task<IActionResult> Login(DadosUser_dto User)
        {
            var item = await Facade.Model.Login(User);
            if (item.Erro)
            {
                ViewData["Erro"] = item.ViewMessage;
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
        
        //Logout
        [HttpGet,Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Home");
        }

        //Update
        [HttpGet,Authorize]
        public async Task<IActionResult> ProfileConfig(int id)
        {
            var item = await Facade.Model.Find(id);
            return View(item);
        }
        [HttpPost]
        public async Task<IActionResult> ProfileConfig(DadosUser User, IFormFile Photo, int id, string deleted)
        {
            var item = await Facade.Model.Update(User, Photo, id, deleted);
            if (item.Erro)
            {
                ViewData["Erro"] = item.ViewMessage;
                var erro = await Facade.Model.Find(id);
                return View(erro);
            }
            return RedirectToAction("Index", "Home");
        }

        //Remove
        [HttpGet,Authorize]
        public async Task<IActionResult> Remove(int id)
        {
            var item = await Facade.Model.Find(id);
            return View(item);
        }
        [HttpPost,ActionName("Remove"),Authorize]
        public async Task<IActionResult> RemoveConfirm(int id)
        {
            await Facade.Model.Remove(id);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}