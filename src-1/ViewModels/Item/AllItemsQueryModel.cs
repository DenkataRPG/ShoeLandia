using System.ComponentModel.DataAnnotations;
using ShoeLandia.Views.Item.Enums;
using static ShoeLandia.Common.GeneralApplicationConstants;

namespace ShoeLandia.ViewModels.Item
{
    public class AllItemsQueryModel
    {
        public AllItemsQueryModel()
        {
            CurrentPage = DefaultPage;
            ItemsPerPage = EntitiesPerPage;

            Categories = new HashSet<string>();
            Items = new HashSet<ItemInListViewModel>();
        }

        public string? Category { get; set; }

        [Display(Name = "Search by word")]
        public string? SearchString { get; set; }

        [Display(Name = "Sort Items By")]
        public ItemsSorting ItemsSorting { get; set; }

        public int CurrentPage { get; set; }

        [Display(Name = "Show Items On Page")]
        public int ItemsPerPage { get; set; }

        public int TotalItems { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public IEnumerable<ItemInListViewModel> Items { get; set; }
    }
}
