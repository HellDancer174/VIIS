using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.GlobalViewModel;
using VIIS.App.Staff.ViewModels.EmployeesViewModels;
using VIIS.Domain.Customers;
using VIIS.Domain.Customers.Decorators;
using VIMVVM;

namespace VIIS.App.Customers.ViewModels
{
    public class ViewClient : ClientDecorator
    {
        private readonly ViewAddress viewAddress;
        protected readonly ViewClients clients;
        protected string saveName;
        protected string endName;

        public ViewClient(Client other, ViewClients clients, string saveName, string endName) : base(other)
        {
            Name = new ViewName(firstName, middleName, lastName);
            viewAddress = new ViewAddress(address);
            this.clients = clients;
            this.saveName = saveName;
            this.endName = endName;
        }
        public ViewClient(Client other, ViewClients clients): this(other, clients, "Сохранить", "Удалить")
        {

        }
        public ViewClient(ViewClient viewClient):this(viewClient.other, viewClient.clients, viewClient.saveName, viewClient.endName)
        {
        }
        public ViewClient(ViewClients clients):this(new Client(), clients)
        {
        }

        public ViewName Name { get; set; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }


        public ViewAddress Address => viewAddress;
        public string FullAddress => address.ToString();
        public string Comment { get => comment; set => comment = value; }

        public virtual string SaveName => saveName;
        public virtual string EndName => endName;

        public virtual RelayCommand Save => new RelayCommand(async(obj) => await clients.Update(other, new Client(this)));
        public virtual RelayCommand End => new RelayCommand(async (obj) => await clients.RemoveAsync(other));
    }
}
