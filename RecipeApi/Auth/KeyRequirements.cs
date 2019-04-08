using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApi.Auth
{
    public class KeyRequirements: IAuthorizationRequirement
    {
        public PolicyEnum Role { get; private set; }
        public KeyRequirements(PolicyEnum Role)
        {
            this.Role = Role;
        }
    }
}
