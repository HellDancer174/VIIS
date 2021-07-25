using ElegantLib;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.API.Data;
using VIIS.Domain.Global;

namespace VIIS.API.GlobalModel
{
    public class DBUser : User
    {
        private readonly User other;
        protected readonly UserManager<ApplicationUser> userManager;

        public DBUser(User other, UserManager<ApplicationUser> userManager) : base(other)
        {
            this.other = other;
            this.userManager = userManager;
        }
        public DBUser(ApplicationUser entity, UserManager<ApplicationUser> userManager) :this(new User(entity.UserName, entity.Email), userManager)
        {
        }

        public override async Task TransferAsync()
        {
            await Task.CompletedTask;
        }
    }
}
