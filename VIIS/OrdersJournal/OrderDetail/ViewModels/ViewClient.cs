using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.GlobalViewModel;
using VIIS.App.OrdersJournal.OrderDetail.Models;
using VIIS.Domain.Clients;
using VIMVVM;

namespace VIIS.App.OrdersJournal.OrderDetail.ViewModels
{
    public class ViewClient : ViewName, IViewModel<Client>
    {
        private readonly Client model;

        public ViewClient():this(string.Empty, string.Empty, string.Empty, string.Empty)
        {
            Phone = string.Empty;
            model = new Client(string.Empty, string.Empty, string.Empty, string.Empty);
        }

        public ViewClient(string firstName, string middleName, string lastName, string phone) : base(firstName, middleName, lastName)
        {
            Phone = phone;
            model = new Client(firstName, lastName, middleName, phone);
        }
        public ViewClient(Client model)
        {
            this.model = new ViewTransferableClient(model, this);
            this.model.Transfer();
        }
        public void ChangeName(string firstName, string middleName, string lastName, string phone)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Phone = phone;
        }

        public Client Model()
        {
            return new Client(FirstName, LastName, MiddleName, Phone);
        }

        public string Phone { get; set; }
    }
}
