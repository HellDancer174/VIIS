using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIMVVM;

namespace VIIS.App.OrdersJournal.ViewModels
{
    public class Staff: ViewModel<string>
    {
        private readonly WorkDaysPage daysPage;

        public Staff(List<string> manicure, List<string> pedicure, List<string> masters, WorkDaysPage daysPage) //МБ добавить словарь с мастерами
        {
            Manicure = manicure;
            Pedicure = pedicure;
            Masters = masters;
            this.daysPage = daysPage;
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
                DaysPage.ChangePage(selectedMaster);
            }
        }

        public WorkDaysPage DaysPage => daysPage;
    }
}
