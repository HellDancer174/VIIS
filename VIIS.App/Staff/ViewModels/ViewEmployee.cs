using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.Staff.ViewModels.EmployeesViewModels;
using VIIS.App.GlobalViewModel;
using VIMVVM;
using VIIS.Domain.Staff.Decorators;
using VIIS.Domain.Staff;
using VIIS.Domain.Staff.ValueClasses;
using VIIS.App.Staff.Models;
using System.Windows;
using VIIS.App.Staff.Views;
using VIMVVM.Detail;

namespace VIIS.App.Staff.ViewModels
{
    public class ViewEmployee : DecoratableMaster, IDetailedViewModel<Master>
    {
        private readonly EmployeesViewModels.ViewEmployeeDetail viewDetail;
        private readonly ViewAddress viewAddress;
        private readonly ViewPassport viewPassport;
        //protected readonly Employees masters;
        private string viewPosition;

        public ViewEmployee(/*Employees masters*/) : this(new Master()/*, masters*/)
        {
        }
        public ViewEmployee(ViewEmployee other): base(other)
        {
            viewDetail = other.viewDetail;
            viewAddress = other.viewAddress;
            viewPassport = other.viewPassport;
            viewPosition = other.viewPosition;
            //masters = other.masters;

        }
        public ViewEmployee(Master other/*, Employees masters*/) : base(other)
        {
            viewDetail = new EmployeesViewModels.ViewEmployeeDetail(detail);
            viewAddress = new ViewAddress(address);
            viewPassport = new ViewPassport(passport);
            viewPosition = position.ToString();
            //this.masters = masters;
        }

        public string Position { get => viewPosition; set => viewPosition = value; }
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
            }
        }
        public string MiddleName
        {
            get { return middleName; }
            set
            {
                middleName = value;
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
            }
        }
        public DateTime BirthDay { get => birthday; set => birthday = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }

        public ViewEmployeeDetail Detail => viewDetail;

        public ViewAddress Address => viewAddress;
        public ViewPassport Passport => viewPassport;

        public Master Model()
        {
            return new Master(masterID, id,firstName, lastName, middleName, Phone, new Position(Position), workDaysList, Address, Passport, Detail, BirthDay, Email);
        }


        //public virtual RelayCommand Save => new RelayCommand(async(obj) => await SaveMethod());

        //protected virtual async Task<bool> SaveMethod()
        //{
        //    address = viewAddress;
        //    passport = viewPassport;
        //    detail = viewDetail;
        //    var masters = new MasterOfView(this).Safe();
        //    if (masters.Count() == 0) return false;
        //    else
        //    {
        //        await this.masters.Update(other, masters.First());
        //        NotifySelector();
        //        return true;
        //    }
        //}

        public void NotifySelector()
        {
            //ChangeProperties(nameof(Position), nameof(BirthDay), nameof(Phone), nameof(Email));
            ChangeProperty(nameof(BirthDay));
            ChangeProperty(nameof(Position));
            ChangeProperty(nameof(Phone));
            ChangeProperty(nameof(Email));
            ChangeProperty(nameof(FullName));
            Detail.NotifySelector();
            Address.NotifySelector();
            Passport.NotifySelector();

        }

        //public virtual RelayCommand End => new RelayCommand(async(obj) => 
        //{
        //    await masters.RemoveAsync(other);
        //});
    }
}
