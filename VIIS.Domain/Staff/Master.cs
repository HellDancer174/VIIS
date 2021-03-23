using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Clients;
using VIIS.Domain.Staff.ValueClasses;

namespace VIIS.Domain.Staff
{
    public class Master : Client, IEquatable<Master>, IEquatable<Position>
    {
        private readonly Position position;
        private readonly WorkDaysList workDaysList;

        public Master(Master other) : base(other)
        {
            position = other.position;
            workDaysList = other.workDaysList;
        }

        public Master(string firstName, string lastName, string middleName, string phone, Position position, WorkDaysList workDaysList) : base(firstName, lastName, middleName, phone)
        {
            this.position = position;
            this.workDaysList = workDaysList;
        }
        public Master(): this("Валентина", "Игнатьева", "Иониктовна", "", new Position(), new WorkDaysList())
        {
        }

        public bool IsWork(DateTime date)
        {
            return workDaysList.IsWorkDay(date.Date);
        }


        public bool Equals(Master other)
        {
            return base.Equals(other);
        }

        public bool Equals(Position other) => position.Equals(other);
    }
}
