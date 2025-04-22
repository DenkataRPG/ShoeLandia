using System.ComponentModel.DataAnnotations;
using ShoeLandia.Views.Item.Enums;
using static ShoeLandia.Common.GeneralApplicationConstants;

namespace ShoeLandia.ViewModels.Item
{
    public class AllItemsQueryModel
    {
        public const int ItemsPerPageDefault = 3;

        public string? Category { get; set; }

        [Display(Name = "Search by text")]
        public string? SearchString { get; set; }

        [Display(Name = "Sort by")]
        public ItemsSorting ItemsSorting { get; set; }

        [Display(Name = "Show")]
        public int ItemsPerPage { get; set; } = ItemsPerPageDefault;

        public int CurrentPage { get; set; } = 1;

        public int TotalItems { get; set; }

        public IEnumerable<string> Categories { get; set; } = new List<string>();

        public IEnumerable<ItemInListViewModel> Items { get; set; } = new List<ItemInListViewModel>();
    }
}
