using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace SO.Domain.Identity
{
    public class Role : IdentityRole<long>
    {
        public List<UserRole> UserRoles { get; set; }
    }
}