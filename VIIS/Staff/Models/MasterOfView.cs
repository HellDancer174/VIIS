using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VIIS.App.Staff.ViewModels;
using VIIS.Domain.Global;
using VIIS.Domain.Staff;

namespace VIIS.App.Staff.Models
{
    public class MasterOfView: Master
    {
        private readonly ViewEmployee other;
        private readonly AddressOfView addressOfView;
        private readonly PassportOfView passportOfView;

        public MasterOfView(ViewEmployee other) : base(other)
        {
            this.other = other;
            addressOfView = new AddressOfView(other.Address);
            passportOfView = new PassportOfView(other.Passport);
        }

        public IEnumerable<Master> Safe()
        {
            try
            {
                new ValidPropetry("Адрес", addressOfView.ToString(), addressOfView.Safe().Count() == 0).Validate();
                new ValidPropetry("Паспорт", passportOfView.ToString(), passportOfView.Safe().Count() == 0).Validate();
                return new List<Master>() { Master() };
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
                return new List<Master>();
            }
        }

        private Master Master()
        {
            var corrected = new List<ValidPropetry>();
            corrected.Add(new ValidPropetry("Имя мастера", FullName, !(String.IsNullOrEmpty(firstName) || String.IsNullOrEmpty(lastName) || String.IsNullOrEmpty(middleName))));
            corrected.Add(new ValidPropetry("Телефон", phone, !string.IsNullOrEmpty(phone)));
            corrected.Add(new ValidPropetry("Дата рождения", birthday.ToShortDateString(), birthday != new DateTime()));
            corrected.ForEach(prop => prop.Validate());
            return new Master(this);
        }

    }
}
