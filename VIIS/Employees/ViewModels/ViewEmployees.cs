using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.Employees.Views;
using VIMVVM;

namespace VIIS.App.Employees.ViewModels
{
    public class ViewEmployees : ViewModel<string>
    {
        private readonly ObservableCollection<ViewEmployee> employees;

        public ViewEmployees(ObservableCollection<ViewEmployee> employees)
        {
            this.employees = employees;
            if (employees.Count != 0) Selected = employees.First();
            else Selected = new ViewEmployee();
        }
        public ViewEmployees() : this(new ObservableCollection<ViewEmployee>() { new ViewEmployee(), new ViewEmployee(), new ViewEmployee()})
        {
        }

        public ViewEmployee Selected { get; set; }

        public ObservableCollection<ViewEmployee> Employees => employees;

        public RelayCommand Add => new RelayCommand((obj) => new EmployeeDetail().Show());
        public RelayCommand Change => new RelayCommand((obj) => new EmployeeDetail(Selected).Show());
        public RelayCommand Remove => new RelayCommand((obj) => { Employees.Remove(Selected); Selected = new ViewEmployee(); });

    }
}
