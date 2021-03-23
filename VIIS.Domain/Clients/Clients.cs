using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Clients
{
    public class Clients
    {
        protected readonly List<Client> clients;

        public Clients(List<Client> clients)
        {
            this.clients = clients;
        }

        public Clients(Clients other): this(other.clients)
        {
        }
        public Clients():this(new List<Client>() { new Client("Виктор", "Игнатьев","Александрович", "4676874"), new Client("Виктор", "Кот", "Александрович", "326549645") , new Client("Виктор", "Игнатов", "Александрович", "4676874") })
        {
        }



        public Client Find(Client item)
        {
            return new AnyClient();
        }
    }
}
