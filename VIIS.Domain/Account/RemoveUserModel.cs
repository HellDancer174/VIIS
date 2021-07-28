using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Global;

namespace VIIS.Domain.Account
{
    public class RemoveUserModel
    {
        public RemoveUserModel(User currentUser, User deletedUser)
        {
            CurrentUser = currentUser;
            DeletedUser = deletedUser;
        }
        public RemoveUserModel():this(new User(), new User())
        {

        }

        public User CurrentUser { get; set; }
        public User DeletedUser { get; set; }

    }
}
