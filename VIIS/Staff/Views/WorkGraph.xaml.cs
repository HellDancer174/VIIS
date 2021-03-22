using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VIIS.App.Staff.ViewModels;

namespace VIIS.App.Staff.Views
{
    /// <summary>
    /// Логика взаимодействия для WorkGraph.xaml
    /// </summary>
    public partial class WorkGraph : Page
    {
        private ViewWorkGraph viewModels;

        public WorkGraph()
        {
            InitializeComponent();
            DataContext = viewModels = new ViewWorkGraph(new ViewModels.WorkGraphViewModels.ViewMastersList(this), this);
        }

        private void Calendar_DisplayModeChanged(object sender, CalendarModeChangedEventArgs e)
        {
            Calendar.DisplayMode = CalendarMode.Year;
        }

        private void Calendar_DisplayDateChanged(object sender, CalendarDateChangedEventArgs e)
        {

        }
    }
}
