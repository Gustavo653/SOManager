using Microsoft.AspNetCore.Identity;
using System;

namespace SO.Domain.Identity
{
    public class UserRole : IdentityUserRole<long>
    {
        public User User { get; set; }
        public Role Role { get; set; }
    }
}