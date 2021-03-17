using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIMVVM;

namespace VIIS.App.GlobalViewModel
{
    public class ViewName: ViewModel<string>
    {
        public ViewName(string firstName, string middleName, string lastName)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }
        public ViewName(): this(string.Empty, string.Empty, string.Empty)
        {
        }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public virtual string FullName => String.Format("{0} {1} {2}", LastName, FirstName, MiddleName);

    }
}
