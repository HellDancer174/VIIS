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
    public class OrdersController : DBController
    {
        // GET: api/Orders
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return TryGet<IEnumerable<Order>>(() =>
            {
                using (var context = new VIISDBContext())
                {
                    return new DBOrders(context);
                }
            });

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
            using (var context = new VIISDBContext())
            {
                return Execute(new ValidDBOrder(new AddOrUpdatableTDBOrder(value, 
                    new DBQuery<OrdersTt>(context.OrdersTt, context), new DBQuery<ServicesTt>(context.ServicesTt, context)), context));
            }
        }

        // PUT: api/Orders/5
        [HttpPut]
        public ActionResult Put([FromBody]Order value)
        {
            using (var context = new VIISDBContext())
            {
                return Execute(new ValidatableIDDBOrder(new ValidDBOrder(new AddOrUpdatableTDBOrder(value,
                    new UpdatableDBQuery<OrdersTt>(context.OrdersTt, context), new UpdateServicesDBQuery(context)), context)));
            }
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public ActionResult Delete([FromBody]Order value)
        {
            using (var context = new VIISDBContext())
            {
                return Execute(new ValidatableIDDBOrder(new RemovableTDBOrder(value,
                    new RemovableDBQuery<OrdersTt>(context.OrdersTt, context),
                    new RemovableDBQuery<ServicesTt>(context.ServicesTt, context))));
            }

        }

        //protected override ObjectResult Execute<T>(IDocument document, T OkValue)
        //{
        //    try
        //    {
        //        Transfer(document);
        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError(string.Empty, ex.Message);
        //        if (ex.InnerException != null) ModelState.AddModelError(string.Empty, ex.InnerException.Message);
        //        return BadRequest(ModelState);
        //    }
        //    return Ok(OkValue);
        //}
    }
}
