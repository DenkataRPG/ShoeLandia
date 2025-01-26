using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoeLandia.Data.Common.Models;

namespace ShoeLandia.Data.Models
{
    public class Cart : BaseDeletableModel<string>
    {
        public Cart()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Items = new HashSet<Item>();
        }
        public int TotalPrice { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        
        
    }
}
