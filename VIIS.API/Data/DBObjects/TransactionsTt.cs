using System;
using System.Collections.Generic;

namespace VIIS.API.Data.DBObjects
{
    public partial class TransactionsTt
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Sale { get; set; }
    }
}
