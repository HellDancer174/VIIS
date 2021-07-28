using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VIIS.App.OrdersJournal.ViewModels;
using VIIS.App.Staff.ViewModels.WorkGraphViewModels;
using VIIS.App.Staff.Views;
using VIIS.Domain.Staff;
using VIMVVM;

namespace VIIS.App.Staff.ViewModels
{
    public class ViewWorkGraph: Notifier
    {
        private DateTime current;
        private readonly IJournal journal;

        public ViewWorkGraph(ViewMastersList mastersList, DateTime current, IJournal journal)
        {
            this.MastersList = mastersList;
            this.current = current;
            this.journal = journal;
        }
        public ViewWorkGraph(Employees masters, DateTime current, IJournal journal) : this(new ViewMastersList(masters, current), current, journal)
        {
        }


        public ViewMastersList MastersList { get; private set; }

        public DateTime Current
        {
            get => current;
            set
            {
                current = value;
                MastersList.ChangeMonth(current);
            }
        }

        public RelayCommand Save => new RelayCommand(async(obj) => 
        {
            try
            {
                await MastersList.SaveMonth();
                await MastersList.UpdataCollection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Current = current;
            MessageBox.Show(String.Format("Обновлен график работы на {0}", MastersList.CurrentMonth));
            journal.ChangeStaff(MastersList);
        });
    }
}
