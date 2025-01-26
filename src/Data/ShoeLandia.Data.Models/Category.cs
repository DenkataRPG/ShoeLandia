using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoeLandia.Data.Common.Models;

namespace ShoeLandia.Data.Models
{
    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.Items = new HashSet<Item>();
        }
        public string Name { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
