using ElegantLib.Validate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VIIS.App.Account.Models
{
    public class WindowCatcher<T> : Catcher<T> where T : Exception
    {
        public WindowCatcher(Action execute) : base(execute, (ex)=> MessageBox.Show(ex.Message))
        {
        }
    }
}
