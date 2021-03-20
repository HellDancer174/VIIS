using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.GlobalViewModel;
using VIIS.App.OrdersJournal.OrderDetail.Models;
using VIIS.Domain.Clients;

namespace VIIS.App.OrdersJournal.OrderDetail.ViewModels
{
    public class ClientName : ViewName
    {
        private readonly Client model;

        public ClientName():this(string.Empty, string.Empty, string.Empty)
        {
            model = new Client(string.Empty, string.Empty, string.Empty);
        }

        public ClientName(string firstName, string middleName, string lastName) : base(firstName, middleName, lastName)
        {
            model = new Client(firstName, lastName, middleName);
        }
        public ClientName(Client model)
        {
            this.model = new ViewTransferableClient(model, this);
            model.Transfer();
        }
        public void ChangeName(string firstName, string middleName, string lastName)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }
    }
}
