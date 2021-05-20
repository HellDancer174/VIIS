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
                new ValidTextBlock("Адрес", addressOfView.ToString(), addressOfView.Safe().Count() != 0).Validate();
                new ValidTextBlock("Паспорт", passportOfView.ToString(), passportOfView.Safe().Count() != 0).Validate();
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
            var corrected = new List<ValidTextBlock>();
            corrected.Add(new ValidTextBlock("Имя мастера", FullName, !(String.IsNullOrEmpty(firstName) || String.IsNullOrEmpty(lastName) || String.IsNullOrEmpty(middleName))));
            corrected.Add(new ValidTextBlock("Телефон", phone, !string.IsNullOrEmpty(phone)));
            corrected.Add(new ValidTextBlock("Дата рождения", birthday.ToShortDateString(), birthday != new DateTime()));
            corrected.ForEach(prop => prop.Validate());
            return new Master(this);
        }

    }
}
