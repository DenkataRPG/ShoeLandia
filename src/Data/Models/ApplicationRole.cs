namespace ShoeLandia.Data.Models
{
    using System;

    using Microsoft.AspNetCore.Identity;

    public class ApplicationRole : IdentityRole
    {

        public ApplicationRole(string name)
            : base(name)
        {
            this.Id = Guid.NewGuid().ToString();
            this.IsDeleted = false;
        }

        public ApplicationRole()
        {
            this.Id = Guid.NewGuid().ToString();
            this.IsDeleted = false;
        }

        public bool IsDeleted { get; set; }
    }
}
