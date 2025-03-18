using Microsoft.AspNetCore.Mvc;
using ShoeLandia.Services.Interfaces;
using ShoeLandia.ViewModels.Item;

namespace ShoeLandia.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemService itemService;
        private readonly ICategoryService categoriesService;

        public ItemController(IItemService itemService, ICategoryService categoriesService)
        {
            this.itemService = itemService;
            this.categoriesService = categoriesService;
        }
        public IActionResult All()
        {
            IEnumerable<SingleItemViewModel> items = this.itemService.All();

            return View(items);
        }

        [HttpGet]
        public IActionResult Add()
        {

            var categories = this.categoriesService.GetAllAsKeyValuePairs().ToList();

            ItemFormViewModel viewModel = new ItemFormViewModel
            {
                CategoriesItems = categories
            };
            return View();
        }
    }
}
