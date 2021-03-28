using ElegantLib.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIMVVM;

namespace VIIS.Domain.Customers
{
    public class Clients: VirtualObservableCollection<Client>
    {

        public Clients(List<Client> clients):base(clients)
        {
        }

        public Clients(Clients other): this(other.ToList())
        {
        }
        public Clients():this(new List<Client>() { new Client("Виктор", "Игнатьев","Александрович", "4676874"), new Client("Виктор", "Кот", "Александрович", "326549645") , new Client("Виктор", "Игнатов", "Александрович", "4676874") })
        {
        }

        public virtual async Task AddAsync(Client item)
        {
            Add(item);
            await Task.CompletedTask;
        }

        public virtual async Task Update(Client oldItem, Client item)
        {
            this[IndexOf(oldItem)] = item;
            await Task.CompletedTask;
        }

        public virtual async Task RemoveAsync(Client item)
        {
            Remove(item);
            await Task.CompletedTask;
        }

        public Client Find(Client item)
        {
            return new AnyClient();
        }
    }
}
