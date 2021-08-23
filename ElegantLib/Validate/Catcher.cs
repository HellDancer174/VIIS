using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElegantLib.Validate
{
    public class Catcher<T> : ICatcher<T> where T:Exception
    {
        protected readonly Action execute;
        protected readonly Action<T> fail;

        public Catcher(Action execute, Action<T> fail)
        {
            this.execute = execute;
            this.fail = fail;
        }

        public virtual void Execute()
        {
            try
            {
                execute.Invoke();
            }
            catch (T ex)
            {
                fail.Invoke(ex);
            }
        }
    }
}
