using ShoeLandia.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeLandia.Data.Models
{
    public class Image : BaseModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string ItemId { get; set; }
        public virtual Item Item { get; set; }

        public string RemoteImageUrl { get; set; }
        public  string AddedByUserId { get; set; }
        public  ApplicationUser AddedByUser { get; set; }
    }
}
