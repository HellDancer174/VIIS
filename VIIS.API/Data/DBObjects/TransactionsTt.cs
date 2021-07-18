using System;
using System.Collections.Generic;

namespace VIIS.API.Data.DBObjects
{
    public partial class TransactionsTt
    {
        public TransactionsTt(int id, string name, decimal sale)
        {
            Id = id;
            Name = name;
            Sale = sale;
        }

        public TransactionsTt()
        {

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Sale { get; set; }
    }
}
