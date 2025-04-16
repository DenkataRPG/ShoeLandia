using Microsoft.AspNetCore.Identity;

namespace ShoeLandia.Data.Models
{
    public class ApplicationUser : IdentityUser<string>
    { 
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.Items = new HashSet<Item>();
        }


        //Soft delete
        public bool IsDeleted { get; set; }
        public virtual ICollection<Item> Items { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
    }
}
