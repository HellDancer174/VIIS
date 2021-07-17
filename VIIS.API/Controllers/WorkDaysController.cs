using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VIIS.API.Controllers.Base;
using VIIS.API.Data.DBObjects;
using VIIS.API.Employees;
using VIIS.API.Employees.Models;
using VIIS.Domain.Staff;

namespace VIIS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/WorkDays")]
    public class WorkDaysController : DBController
    {
        // GET: api/WorkDays
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/WorkDays/5
        [HttpGet("api/WorkDays/{id}"/*, Name = "Get"*/)]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/WorkDays
        [HttpPost]
        public ActionResult Post([FromBody]WorkDaysViewModel workDaysViewModel)//у WorkDaysLista в parameterless конструкторе есть DateTime.Now поэтому добавляется еще и текущая дата.
        {
            using (var context = new VIISDBContext())
            {
                DBWorkDaysMasters document = new DBWorkDaysMasters(workDaysViewModel.Masters.Select(master => new DBWorkDaysMaster(master, context, workDaysViewModel.Month)).ToArray());
                var actionResult = Execute(document);
                if (actionResult == Ok() && !document.IsSuccess) return Ok(document.FailedMessage());
                else return actionResult;
            }
        }
        
        // PUT: api/WorkDays/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        
    }
}
