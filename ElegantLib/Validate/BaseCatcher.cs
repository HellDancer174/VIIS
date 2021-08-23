using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElegantLib.Validate
{
    public class BaseCatcher : Catcher<Exception>
    {
        public BaseCatcher(Action execute, Action<Exception> fail) : base(execute, fail)
        {
        }

        public override void Execute()
        {
            try
            {
                execute.Invoke();
            }
            catch (Exception ex)
            {
                fail.Invoke(ex);
            }

        }
    }
}
