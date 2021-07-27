using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VIIS.API.Controllers.Base;
using VIIS.API.Data.DBObjects;
using VIIS.API.GlobalModel;
using VIIS.API.ServicesDir;
using VIIS.Domain.Services;

namespace VIIS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/ServiceValue")]
    public class ServiceValueController : DBController
    {
        // GET: api/ServiceValue
        [HttpGet]
        public IEnumerable<ServiceValue> Get()
        {
            return TryGet<IEnumerable<ServiceValue>>(() =>
            {
                using (var context = new VIISDBContext())
                {
                    return new DBServiceValueList(context);
                }
            });
        }

        // GET: api/ServiceValue/5
        [HttpGet("api/ServiceValue/{id}"/*, Name = "Get"*/)]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/ServiceValue
        [HttpPost]
        public ActionResult Post([FromBody]ServiceValue value)
        {
            using (var context = new VIISDBContext())
            {
                return Execute(new DBServiceValue(value, new DBQuery<ServiceValuesTs>(context.ServiceValuesTs, context)));
            }

        }

        // PUT: api/ServiceValue/5
        [HttpPut]
        public ActionResult Put([FromBody]ServiceValue value)
        {
            using (var context = new VIISDBContext())
            {
                return Execute(new ValidServiceValue(new DBServiceValue(value, new UpdatableDBQuery<ServiceValuesTs>(context.ServiceValuesTs, context))));
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public ActionResult Delete([FromBody]ServiceValue value)
        {
            using (var context = new VIISDBContext())
            {
                return Execute(new ValidServiceValue(new DBServiceValue(value, new RemovableDBQuery<ServiceValuesTs>(context.ServiceValuesTs, context))));
            }

        }
    }
}
