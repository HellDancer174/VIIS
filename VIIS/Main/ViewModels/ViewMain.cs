using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using VIMVVM;

namespace VIIS.App.Main.ViewModels
{
    public class ViewMain: ViewModel<string>
    {
        private readonly Page journal;
        private readonly Page clients;
        private readonly Page staff;
        private readonly Page finance;
        private readonly Page account;

        public ViewMain(Page journal, Page clients, Page staff, Page finance, Page account)
        {
            this.journal = journal;
            this.clients = clients;
            this.staff = staff;
            this.finance = finance;
            this.account = account;
            Current = journal;
        }

        public Page Current { get; private set; }
    }
}
