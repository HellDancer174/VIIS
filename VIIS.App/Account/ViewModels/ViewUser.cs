using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Global;
using VIMVVM.Detail;

namespace VIIS.App.Account.ViewModels
{
    public class ViewUser: User, IDetailedViewModel<User>
    {
        public ViewUser(User other) : base(other)
        {
        }

        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }

        public event PropertyChangedEventHandler PropertyChanged;

        public User Model()
        {
            return new User(Name, Email);
        }

        public void NotifySelector()
        {
            
        }
    }
}
