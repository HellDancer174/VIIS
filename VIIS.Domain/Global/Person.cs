using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIMVVM;

namespace VIIS.Domain.Global
{
    public class Person: Notifier
    {
        protected string firstName;
        protected string lastName;
        protected string middleName;

        public Person(string firstName, string lastName, string middleName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.middleName = middleName;
        }
    }
}
