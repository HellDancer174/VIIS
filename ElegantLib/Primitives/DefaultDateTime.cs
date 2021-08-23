using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElegantLib.Primitives
{
    public class DefaultDateTime
    {
        private readonly DateTime dateTime;

        public DefaultDateTime(DateTime dateTime)
        {
            this.dateTime = dateTime;
        }
        public DefaultDateTime()
        {
            dateTime = new DateTime(1885, 1, 1);
        }

        public DateTime Value => dateTime;
    }
}
