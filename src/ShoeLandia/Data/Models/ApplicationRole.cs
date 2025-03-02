﻿namespace ShoeLandia.Data.Models
{
    using System;

    using Microsoft.AspNetCore.Identity;

    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole()
            : this(null)
        {
        }

        public ApplicationRole(string name)
            : base(name)
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
