using Microsoft.AspNetCore.Mvc;

namespace ProjetoLoja.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
