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
            var corrected = new List<ValidTextBlock>();
            corrected.Add(new ValidTextBlock("Серия", series, !string.IsNullOrEmpty(series)));
            corrected.Add(new ValidTextBlock("Номер", passportID, !string.IsNullOrEmpty(passportID)));
            corrected.Add(new ValidTextBlock("Дата выпуска", issusiesDate.ToShortDateString(), issusiesDate != new DateTime()));
            corrected.Add(new ValidTextBlock("Организация, выдавшая паспорт", organization, !string.IsNullOrEmpty(organization)));
            corrected.ForEach(prop => prop.Validate());
            return new Passport(this);
        }
    }
}
