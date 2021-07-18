using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using VIIS.Domain.Orders;
using Microsoft.AspNetCore.Mvc;
using VIIS.API.Data.DBObjects;
using VIIS.API.Orders;
using VIIS.API.Controllers.Base;
using VIIS.API.GlobalModel;
using ElegantLib;
using Newtonsoft.Json;
using VIIS.Domain.Staff;
using VIIS.API.ServicesDir;

namespace VIIS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Orders")]
    public class OrdersController : Controller
    {
        // GET: api/Orders
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            using (var context = new VIISDBContext())
            {
                return new DBOrders(context);
                //return new[] { new Order(new Master(), new DateTime()) };
            }
            //return new OrdersVM[]{ new OrdersVM(1, new Domain.Customers.Client(), new List<Domain.Services.Service>(), 2, "", new DateTime(), 500) };
        }

        // GET: api/Orders/5
        [HttpGet("api/Orders/{id}"/*, Name = "Get"*/)]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Orders
        [HttpPost]
        public ActionResult Post([FromBody]Order value)
        {
            //var obj = JsonConvert.DeserializeObject<Order>(value);
            using (var context = new VIISDBContext())
            {
                return Execute(new AddOrUpdatableTDBOrder(value, 
                    new DBQuery<OrdersTt>(context.OrdersTt, context), new DBQuery<ServicesTt>(context.ServicesTt, context)));
            }
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public ActionResult Put([FromBody]Order value)
        {
            using (var context = new VIISDBContext())
            {
                return Execute(new AddOrUpdatableTDBOrder(value,
                    new UpdatableDBQuery<OrdersTt>(context.OrdersTt, context), new UpdateServicesDBQuery(context)));
            }
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete([FromBody]Order value)
        {
            using (var context = new VIISDBContext())
            {
                return Execute(new RemovableTDBOrder(value,
                    new RemovableDBQuery<OrdersTt>(context.OrdersTt, context),
                    new RemovableDBQuery<ServicesTt>(context.ServicesTt, context)));
            }

        }

        protected ActionResult Execute(IDocument document)
        {
            try
            {
                document.Transfer();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                if(ex.InnerException != null) ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                return BadRequest(ModelState);
            }
            return Ok();
        }

    }
}
