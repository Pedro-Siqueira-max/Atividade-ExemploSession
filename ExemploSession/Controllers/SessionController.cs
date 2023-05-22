using ExemploSession.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExemploSession.Controllers
{
    public class SessionController : Controller
    {

		public Context context;

		public SessionController(Context ctx)
		{
			context = ctx;
		}
		public IActionResult Index()
        {
			var acesso = HttpContext.Session.GetString("usuario_session");
			if (acesso != null)
				return View(context.Usuarios);
			else
				return View("Login");
		}
        public IActionResult Create()
        {
			ViewBag.Usuarios = new SelectList(context.Usuarios.OrderBy(f => f.Nome), "UsuarioID", "Nome");
			return View();
		}
        [HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Usuario usuario)
        {
			context.Add(usuario);
			context.SaveChanges();
			return RedirectToAction("Index");
		}
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
			var confirma = context.Usuarios.Where(u => u.Email.Equals(email) && u.Senha.Equals(senha)).FirstOrDefault();
			if (confirma != null)
			{
				HttpContext.Session.SetString("usuario_session", confirma.Nome);
				return RedirectToAction("Correto");
			}
			else
			{
				return RedirectToAction("Login");
			}
		}

        public IActionResult Correto()
        {
            return View();
        }
    }
}
