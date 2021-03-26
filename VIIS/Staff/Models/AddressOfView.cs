using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VIIS.App.Staff.ViewModels.EmployeesViewModels;
using VIIS.Domain.Global;
using VIIS.Domain.Staff.ValueClasses;

namespace VIIS.App.Staff.Models
{
    public class AddressOfView : Address
    {
        private readonly ViewAddress other;

        public AddressOfView(ViewAddress other) : base(other)
        {
            this.other = other;
        }

        public virtual IEnumerable<Address> Safe()
        {
            try
            {
                return new List<Address>() { Address() };
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.ToString());
                return new List<Address>(); 
            }
        }

        private Address Address()
        {
            var corrected = new List<ValidPropetry>();
            corrected.Add(new ValidPropetry("Почтовый индекс", index.ToString(), index > 0));
            corrected.Add(new ValidPropetry("Город", city, !string.IsNullOrEmpty(city)));
            corrected.Add(new ValidPropetry("Улица", street, !string.IsNullOrEmpty(street)));
            corrected.Add(new ValidPropetry("Дом", house, string.IsNullOrEmpty(house)));
            corrected.Add(new ValidPropetry("Квартира", flat, string.IsNullOrEmpty(flat)));
            corrected.ForEach(property => property.Validate());
            return new Address(this);
        }
    }
}
