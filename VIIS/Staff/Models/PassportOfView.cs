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
    public class PassportOfView : Passport
    {
        private readonly ViewPassport other;

        public PassportOfView(ViewPassport other) : base(other)
        {
            this.other = other;
        }

        public virtual IEnumerable<Passport> Safe()
        {
            try
            {
                return new List<Passport>() { Passport() };
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.ToString());
                return new List<Passport>();
            }
        }

        private Passport Passport()
        {
            var corrected = new List<ValidPropetry>();
            corrected.Add(new ValidPropetry("Серия", series, !string.IsNullOrEmpty(series)));
            corrected.Add(new ValidPropetry("Номер", passportID, !string.IsNullOrEmpty(passportID)));
            corrected.Add(new ValidPropetry("Дата выпуска", issusiesDate.ToShortDateString(), issusiesDate != new DateTime()));
            corrected.Add(new ValidPropetry("Организация, выдавшая паспорт", organization, !string.IsNullOrEmpty(organization)));
            corrected.ForEach(prop => prop.Validate());
            return new Passport(this);
        }
    }
}
