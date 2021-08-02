using System;
using System.Collections.Generic;

namespace VIIS.API.Data.DBObjects
{
    public partial class TransactionsTt
    {
        private DateTime? _date;

        public TransactionsTt(int id, string name, decimal sale, DateTime date)
        {
            Id = id;
            Name = name;
            Sale = sale;
            Date = date;
        }

        public TransactionsTt()
        {

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Sale { get; set; }
        public DateTime? Date
        {
            get => _date;
            set
            {
                if (!value.HasValue) _date = new DateTime(1900, 01, 01);
                else _date = value;
            }
        }

    }
}
