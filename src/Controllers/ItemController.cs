using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShoeLandia.Data.Models;
using ShoeLandia.Services.Filter;
using ShoeLandia.Services.Interfaces;
using ShoeLandia.ViewModels.Item;

namespace ShoeLandia.Controllers
{
    public class ItemController : BaseController
    {
        private readonly IItemService itemService;
        private readonly ICategoryService categoryService;
        private readonly UserManager<ApplicationUser> _userManager;
        public ItemController(IItemService itemService, ICategoryService categoryService, UserManager<ApplicationUser> userManager)
        {
            this.itemService = itemService;
            this.categoryService = categoryService;
            this._userManager = userManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery] AllItemsQueryModel queryModel)
        {
            AllItemsFilteredAndPagedServiceModel serviceModel =
                await itemService.All(queryModel);

            queryModel.Items = serviceModel.Items;
            queryModel.TotalItems = serviceModel.TotalItemsCount;
            queryModel.Categories = await categoryService.AllCategoryNamesAsync();

            return View(queryModel);
        }

        [Authorize(Roles="Admin")]
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

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Add(ItemFormViewModel item)
        {
            var userId = this.GetUserId();

            this.itemService.AddNewItemInDB(item, userId);
            return RedirectToAction("All", "Item");
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
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var categoriesItems = this.categoryService.GetAllAsKeyValuePairs().ToList();
            var userId = this.GetUserId();

            ItemFormViewModel model = await this.itemService.GetItemForEditByIdAsync(id, categoriesItems, userId);

            return View(model);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(string id, ItemFormViewModel model)
        {
            var categoriesItems = this.categoryService.GetAllAsKeyValuePairs().ToList();
            var userId = this.GetUserId();

            await this.itemService.EditItemAsync(model, id, categoriesItems,userId);

            return RedirectToAction("Details", "Item", new{id});
        }
        [Authorize(Roles = "Admin")]   
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            string userId = this.GetUserId();

            try
            {
                await this.itemService.DeleteAsync(id,userId);
            }
            catch (Exception)
            {
                return this.Forbid();
            }

            return this.RedirectToAction("All", "Item");
        }

    }
}
