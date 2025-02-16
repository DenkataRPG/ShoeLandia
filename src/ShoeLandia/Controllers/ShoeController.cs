using Microsoft.AspNetCore.Mvc;

namespace ShoeLandia.Controllers
{
    public class ShoeController : Controller
    {
        public IActionResult All()
        {
            return View();
        }
    }
}
