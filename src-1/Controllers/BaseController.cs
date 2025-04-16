using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ShoeLandia.Controllers
{
    public class BaseController : Controller
    {
        protected string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
