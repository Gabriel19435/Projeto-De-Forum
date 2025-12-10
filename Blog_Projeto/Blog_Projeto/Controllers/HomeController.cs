using Blog_Projeto.Models;
using Blog_Projeto.Services.Posts.Posts_Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace Blog_Projeto.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Posts_Facade Facade;

        public HomeController(ILogger<HomeController> logger, Posts_Facade facade)
        {
            _logger = logger;
            Facade = facade;
        }
        //Crud
        [HttpGet]
        public async Task<IActionResult> Index(string ordem)
        {
            var item = await Facade.Posts.ToList(ordem);
            return View(item);
        }

        //View (Index Extra Page)

        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var item = await Facade.Posts.FindCompletePost(id);
            return View(item);
        }

        //Search

        [HttpGet]
        public async Task<IActionResult> Search(string Procura, string Type)
        {
            if (string.IsNullOrEmpty(Procura))
            {
                return RedirectToAction("Index","Home");
            }
            var item = await Facade.Posts.Search(Procura, Type);
            ViewData["active"] = item.Item2;
            return View(item.Item1);
        }

        //Delete

        [HttpGet]
        public async Task<IActionResult> Deletar(int id)
        {
            var item = await Facade.Posts.Find(id);
            return View(item);
        }

        [HttpPost,ActionName("Deletar")]
        public async Task<IActionResult> DeletarConfirm(int id)
        {
            int UserId = Convert.ToInt32(User.FindFirst("ProfileIdentificator").Value);
            bool x = await Facade.Posts.DeletePost(id, UserId);
            if (x == false)
            {
                return Ok("Error");
            }
            return RedirectToAction("Index");
        }

        //Editar

        [HttpGet,Authorize]
        public async Task<IActionResult> Editar(int id)
        {
            var item = await Facade.Posts.Find(id);
            return View(item);
        }

        [HttpPost,Authorize,AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Editar(int id, DadosPost User, IFormFile Foto, string delete)
        {
            var item = await Facade.Posts.Editar(id, User, Foto, delete);
            if (item.Erro)
            {
                return View();
            }
            return RedirectToAction("Index");
        }

        //Create

        [HttpGet,Authorize]
        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost, Authorize, AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Criar(IFormFile Foto, DadosPost post, int UserId)
        {
            var item = await Facade.Posts.CriarPost(Foto, post, UserId);
            if (item == null)
            {
                return RedirectToAction("Index");
            }
            return View("Index", item);
        }

        //Error
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
