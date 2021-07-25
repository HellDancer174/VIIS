using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using VIIS.API.Data;
using VIIS.Domain.Global;

namespace VIIS.API.GlobalModel
{
    public class RemovableDBUser : DBUser
    {
        public RemovableDBUser(User other, UserManager<ApplicationUser> userManager) : base(other, userManager)
        {
        }

        public override async Task TransferAsync()
        {
            var user = await userManager.FindByEmailAsync(email);
            var result = await userManager.DeleteAsync(user);
            if (result.Succeeded) await Task.CompletedTask;
            else throw new InvalidOperationException();
        }
    }
}
