using ElegantLib;
using ElegantLib.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Global;
using VIIS.Domain.Staff.ValueClasses;
using VIMVVM;

namespace VIIS.Domain.Staff
{
    public class Employees: Repository<Master>
    {

        public Employees(List<Master> masters): base(masters)
        {
        }
        public Employees(Employees other): this(other.ToList())
        {
        }
        public Employees(): this(new List<Master>() { new Master(), new Master("IHj", "Uh", "GF", "4564", new Position(), new WorkDaysList(), new Address(), new Passport(), new EmployeeDetail(DateTime.Now, 2), DateTime.Now, "@gmail")})
        {
        }

        //public virtual async Task AddAsync(Master item)
        //{
        //    base.Add(item);
        //    await Task.CompletedTask;
        //}

        //public virtual async Task Update(Master oldItem, Master item)
        //{
        //    this[IndexOf(oldItem)] = item;
        //    await Task.CompletedTask;
        //}

        //public virtual async Task RemoveAsync(Master item)
        //{
        //    base.Remove(item);
        //    await Task.CompletedTask;
        //}
    }
}
