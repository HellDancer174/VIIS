using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.API.Employees.Models;
using VIIS.Domain.Customers;
using VIIS.Domain.Orders;
using VIIS.Domain.Services;
using VIIS.Domain.Staff;

namespace VIIS.API.Orders
{
    [JsonObject(MemberSerialization.OptIn)]
    public class OrdersVM
    {
        [JsonProperty("order_id")] protected readonly int id;
        [JsonProperty] protected readonly Client person;
        [JsonProperty] protected readonly List<Service> services;
        [JsonProperty] protected readonly int masterID;
        [JsonProperty("order_comment")] protected string comment;
        [JsonProperty] protected DateTime ordersStart;
        [JsonProperty("order_sale")] protected decimal sale;
        //[JsonProperty] protected bool isFinished;

        public OrdersVM(int id, Client person, List<Service> services, int masterID, string comment, DateTime ordersStart, decimal sale/*, bool isFinished*/)
        {
            this.id = id;
            this.person = person;
            this.services = services;
            this.masterID = masterID;
            this.comment = comment;
            this.ordersStart = ordersStart;
            this.sale = sale;
            //this.isFinished = isFinished;
        }

    }
}
