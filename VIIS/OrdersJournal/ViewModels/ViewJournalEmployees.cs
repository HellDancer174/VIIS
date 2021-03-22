using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.OrdersJournal.Models.OrdersDecorators;
using VIIS.Domain.Orders;
using VIMVVM;

namespace VIIS.App.OrdersJournal.ViewModels
{
    public class ViewJournalEmployees: ViewModel<string>
    {
        private readonly WorkDaysPage daysPage;
        public ViewJournalEmployees(List<string> manicure, List<string> pedicure, List<string> masters, WorkDaysPage daysPage) //МБ добавить словарь с мастерами
        {
            Manicure = manicure;
            Pedicure = pedicure;
            Masters = masters;
            this.daysPage = daysPage;
        }
        public ViewJournalEmployees(List<string> manicure, List<string> pedicure, List<string> masters)
        {
            Manicure = manicure;
            Pedicure = pedicure;
            Masters = masters;
            daysPage = new WorkDaysPage(Manicure.Concat(Pedicure).Concat(Masters).ToList());
        }

        public List<string> Manicure { get; }
        public List<string> Pedicure { get; }
        public List<string> Masters { get; }

        private string selectedMaster;
        public string SelectedMaster
        {
            get => selectedMaster;
            set
            {
                selectedMaster = value;
                DaysPage.ChangeMaster(selectedMaster);
            }
        }

        public WorkDaysPage DaysPage => daysPage;

        public void CreateOrder() => daysPage.CreateOrder();
    }
}
