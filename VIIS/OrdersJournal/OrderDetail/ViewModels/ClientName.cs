using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.GlobalViewModel;

namespace VIIS.App.OrdersJournal.OrderDetail.ViewModels
{
    public class ClientName : ViewName
    {
        public ClientName():this(string.Empty, string.Empty, string.Empty)
        {
        }

        public ClientName(string firstName, string middleName, string lastName) : base(firstName, middleName, lastName)
        {
        }
    }
}
