using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Customers;
using VIIS.Domain.Staff.ValueClasses;

namespace VIIS.Domain.Staff
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Master : Client, IEquatable<Master>, IEquatable<Position>
    {
        [JsonProperty] protected int masterID;
        [JsonProperty] protected Position position;
        [JsonProperty] protected WorkDaysList workDaysList;
        [JsonProperty] protected Passport passport;
        [JsonProperty] protected EmployeeDetail detail;
        [JsonProperty] protected DateTime birthday;

        public Master(Master other) : 
            this(other.masterID, other.id, other.firstName, other.lastName, other.middleName, other.phone, other.position, other.workDaysList, other.address, other.passport, other.detail, other.birthday, other.email)
        {
        }

        public Master(int id, int clientID, string firstName, string lastName, string middleName, string phone, Position position, WorkDaysList workDaysList, Address address, Passport passport, EmployeeDetail detail, DateTime birthday, string email) :
            this(id, position, workDaysList, passport, detail, birthday, new Client(clientID, firstName, lastName, middleName, phone, email, address, ""))
        {
        }
        public Master(int id, Position position, WorkDaysList workDaysList, Passport passport, EmployeeDetail detail, DateTime birthday, Client client):
            base(client)
        {
            masterID = id;
            this.position = position;
            this.workDaysList = workDaysList;
            this.passport = passport;
            this.detail = detail;
            this.birthday = birthday;
        }

        public Master(string firstName, string lastName, string middleName, string phone, Position position, WorkDaysList workDaysList, Address address, Passport passport, EmployeeDetail detail, DateTime birthday, string email):
            base(new Client(firstName, lastName, middleName, phone, email, address, ""))
        {
            this.position = position;
            this.workDaysList = workDaysList;
            this.passport = passport;
            this.detail = detail;
            this.birthday = birthday;
        }
        public Master(): this("Валентина", "Игнатьева", "Иониктовна", "", new Position(), new WorkDaysList(), new Address(), new Passport(), new EmployeeDetail(), DateTime.Now.Date, "@mail")
        {
        }

        public bool IsWork(DateTime date)
        {
            return workDaysList.IsWorkDay(date.Date);
        }


        public override bool IsIncomplete => (base.IsIncomplete && !String.IsNullOrEmpty(phone)) || position.IsEmpty;
        

        public bool Equals(Master other)
        {
            return masterID == other.masterID;
            //return base.Equals(other) && Equals(other.position);
        }

        public bool Equals(Position other) => position.Equals(other);

        public override bool Equals(object obj)
        {
            var master = obj as Master;
            if (master == null) return false;
            else return Equals(master);
        }

        public override int GetHashCode()
        {
            return masterID.GetHashCode();
            //var hashCode = 480875773;
            //hashCode = hashCode * -1521134295 + firstName.GetHashCode();
            //hashCode = hashCode * -1521134295 + lastName.GetHashCode();
            //hashCode = hashCode * -1521134295 + middleName.GetHashCode();
            //return hashCode;
        }
    }
}
