using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIMVVM;

namespace VIIS.Domain.Staff.ValueClasses
{
    public class Passport: Notifier
    {
        protected int id;
        protected string series;
        protected string passportID;
        protected DateTime issusiesDate;
        protected string organization;

        public Passport(int id, string seria, string passportID, DateTime date, string organization)
        {
            this.id = id;
            series = seria;
            this.passportID = passportID;
            issusiesDate = date;
            this.organization = organization;
        }
        public Passport(string seria, string passportID, DateTime date, string organization):
            this(0, seria, passportID, date, organization)
        {
        }
        public Passport(Passport other): this(other.id, other.series, other.passportID, other.issusiesDate, other.organization)
        {
        }
        public Passport() : this("0000", "000000", DateTime.Now, "")
        {
        }

        public override string ToString()
        {
            return String.Format("Серия: {0}, номер: {1}, дата выпуска: {2}, организация: {3}", series, passportID, issusiesDate, organization);
        }
    }
}
