﻿using System.Security.Claims;
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

        [Authorize]
        [HttpPost]
        public IActionResult Add(ItemFormViewModel item)
        {
            var userId = this.GetUserId();

            this.itemService.AddNewItemInDB(item, userId);
            return RedirectToAction("All", "Item");
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var categoriesItems = this.categoryService.GetAllAsKeyValuePairs().ToList();
            var userId = this.GetUserId();

            ItemFormViewModel model = await this.itemService.GetItemForEditByIdAsync(id, categoriesItems, userId);

            return View(model);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(string id, ItemFormViewModel model)
        {
            var categoriesItems = this.categoryService.GetAllAsKeyValuePairs().ToList();
            var userId = this.GetUserId();

            await this.itemService.EditItemAsync(model, id, categoriesItems,userId);

            return RedirectToAction("Details", "Item", new{id});
        }
        [Authorize]
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
