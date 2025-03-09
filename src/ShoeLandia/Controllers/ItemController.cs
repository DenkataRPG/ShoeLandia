using Microsoft.AspNetCore.Mvc;
using ShoeLandia.Services.Interfaces;
using ShoeLandia.ViewModels.Item;

namespace ShoeLandia.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemService itemService;

        public ItemController(IItemService itemService)
        {
            this.itemService = itemService;
        }
        public IActionResult All()
        {
            IEnumerable<SingleItemViewModel> items = this.itemService.All();

            return View(items);
        }
    }
}
