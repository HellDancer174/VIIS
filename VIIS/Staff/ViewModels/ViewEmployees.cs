using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.Staff.Views;
using VIIS.Domain.Staff;
using VIIS.Domain.Staff.Decorators;
using VIMVVM;

namespace VIIS.App.Staff.ViewModels
{
    public class ViewEmployees : EmployeesDecorator
    {
        private readonly ObservableCollection<ViewEmployee> employees;
        private ViewEmployee selectedMaster;

        public ViewEmployees() : this(new Employees())
        {
        }

        public ViewEmployees(Employees other) : base(other)
        {
            employees = new ObservableCollection<ViewEmployee>(other.Select(master => new ViewEmployee(master, this)).ToArray());
            if (employees.Count != 0) Selected = employees.First();
            else Selected = new ViewEmployee(this);
        }

        public ViewEmployee Selected { get => selectedMaster; set => selectedMaster = value; }

        public ObservableCollection<ViewEmployee> Employees => employees;

        public RelayCommand AddCommand => new RelayCommand((obj) => new ViewEmployeeOfWindow(new ViewNewEmployee(this)));
        public RelayCommand ChangeCommand => new RelayCommand((obj) => new ViewEmployeeOfWindow(Selected));
        public RelayCommand RemoveCommand => new RelayCommand(async(obj) => 
        {
            await RemoveAsync(Selected);
        });

        public override Task AddAsync(Master item)
        {
            employees.Add(new ViewEmployee(item, this));
            ChangeProperty(nameof(Employees));
            return base.AddAsync(item);
        }

        public override Task RemoveAsync(Master item)
        {
            Employees.Remove(new ViewEmployee(item, this));
            ChangeProperty(nameof(Selected));
            ChangeProperty(nameof(Employees));
            return base.RemoveAsync(item);
        }

        public override Task Update(Master oldItem, Master item)
        {
            //var newItem = new ViewEmployee(item, this);
            //employees[employees.IndexOf(new ViewEmployee(oldItem, this))] = newItem;
            ChangeProperty(nameof(Employees));
            //newItem.NotifySelector();
            return base.Update(oldItem, item);
        }
    }
}
