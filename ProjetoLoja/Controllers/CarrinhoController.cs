using Microsoft.AspNetCore.Mvc;

namespace ProjetoLoja.Controllers
{
    public class CarrinhoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
