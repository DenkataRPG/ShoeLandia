using Microsoft.AspNetCore.Mvc;
using ShoeLandia.Data.Models;
using ShoeLandia.Services.Filter;
using ShoeLandia.Services.Interfaces;
using ShoeLandia.ViewModels.Item;

namespace ShoeLandia.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemService itemService;
        private readonly ICategoryService categoryService;

        public ItemController(IItemService itemService, ICategoryService categoryService)
        {
            this.itemService = itemService;
            this.categoryService = categoryService;
        }
        public async Task<IActionResult> All([FromQuery] AllItemsQueryModel queryModel)
        {
            AllItemsFilteredAndPagedServiceModel serviceModel =
                await itemService.All(queryModel);

            queryModel.Items = serviceModel.Items;
            queryModel.TotalItems = serviceModel.TotalItemsCount;
            queryModel.Categories = await categoryService.AllCategoryNamesAsync();

            return View(queryModel);
        }


        [HttpGet]
        public IActionResult Add()
        {

            var categories = this.categoryService.GetAllAsKeyValuePairs().ToList();

            ItemFormViewModel viewModel = new ItemFormViewModel
            {
                CategoriesItems = categories,
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Add(ItemFormViewModel item)
        {
            itemService.AddNewItemInDB(item);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            var item = this.itemService.GetById<Item>(id);
            SingleItemViewModel model = new SingleItemViewModel
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                Size = item.Size,
                Colors = item.Colors,
                CategoryName = item.Category.Name,
                CategoryId = item.Category.Id,
                Type = item.Type,
                Images = item.GetImages
            };
            return View(model);
        }
    }
}
