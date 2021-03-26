using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.Staff.Models;
using VIIS.Domain.Staff;
using VIMVVM;

namespace VIIS.App.Staff.ViewModels
{
    public class ViewNewEmployee : ViewEmployee
    {
        public ViewNewEmployee(Employees masters) : base(masters)
        {
        }

        public override string SaveName => "Добавить";

        public override string EndName => "Отмена";

        public override RelayCommand Save => new RelayCommand(async(obj) =>
        {
            var masters = new MasterOfView(this).Safe();
            if (masters.Count() == 0) return;
            else
            {
                await this.masters.AddAsync(masters.First());
            } 
        });

        public override RelayCommand End => new RelayCommand((obj) =>
        {
        });
    }
}
