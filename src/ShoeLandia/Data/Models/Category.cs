using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeLandia.Data.Models
{
    public class Category 
    {
        public Category()
        {
            this.Items = new List<Item>();
        }

        public int Id  { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
