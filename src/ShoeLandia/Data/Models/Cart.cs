using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeLandia.Data.Models
{
    public class Cart 
    {
        public Cart()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Items = new List<Item>();
        }

        
        public string Id  { get; set; }
        public bool IsDeleted { get; set; }
        public int TotalPrice { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        
        
    }
}
