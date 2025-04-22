using Microsoft.AspNetCore.Mvc;
using ShoeLandia.Models;
using System.Diagnostics;
using ShoeLandia.Services.Interfaces;
using ShoeLandia.ViewModels.Item;

namespace ShoeLandia.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IItemService _itemService;
        private readonly ICategoryService _categoryService;

        public HomeController(IItemService itemService, ICategoryService categoryService)
        {
            _itemService = itemService;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var queryModel = new AllItemsQueryModel
            {
                CurrentPage = 1,
                ItemsPerPage = 6  
            };

            var serviceModel = await _itemService.All(queryModel);

            ViewBag.Categories = await _categoryService.AllCategoryNamesAsync();

            return View(serviceModel.Items.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Contacts()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
