using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VIIS.API.Data.DBObjects;
using Microsoft.EntityFrameworkCore;
using VIIS.API.Employees.Models;
using VIIS.Domain.Finance;
using ElegantLib;
using VIIS.API.Finance;
using VIIS.API.GlobalModel;

namespace VIIS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/MasterCash")]
    public class MasterCashController : Controller
    {
        // GET: api/MasterCash
        [HttpGet]
        public IEnumerable<MasterCash> Get()
        {
            using (var context = new VIISDBContext())
            {
                var masters = context.EmployeesTt.Include(master => master.Person).ThenInclude(person => person.Address)
                    .Include(master => master.Passport)
                    .Include(master => master.WorkDaysTt).ToArray();
                return context.MastersCashTt.Select(cash => new MasterCash(new DBMaster(masters.Single(master => master.Id == cash.MasterId)), cash.StartDate, cash.FinishDate, cash.Value)).ToArray();
            }
        }

        // GET: api/MasterCash/5
        [HttpGet("api/MasterCash/{id}"/*, Name = "Get"*/)]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/MasterCash
        [HttpPost]
        public ObjectResult Post([FromBody]MasterCash value)
        {
            using (var context = new VIISDBContext())
            {
                return Execute(new ValidDBMasterCash(new DBMasterCash(value, context.MastersCashTt, new DBQuery<MastersCashTt>(context.MastersCashTt, context)), (id) => true));
            }
        }

        [HttpPost("MasterCashList")]
        public ObjectResult Post([FromBody]IEnumerable<MasterCash> value)
        {
            using (var context = new VIISDBContext())
            {
                return Execute(new DBMasterCashList(value
                    .Select(cash => new ValidDBMasterCash(new DBMasterCash(cash, context.MastersCashTt, new DBQuery<MastersCashTt>(context.MastersCashTt, context)), (id) => true))
                    .ToArray()));
            }
        }

        // PUT: api/MasterCash/5
        [HttpPut]
        public ObjectResult Put([FromBody]UpdateMasterCashViewModel value)
        {
            var deleteResult = Delete(value.OldMasterCash);
            if (deleteResult.StatusCode != Ok().StatusCode) return deleteResult;
            var postResult = Post(value.NewMasterCash);
            if (postResult.StatusCode != Ok().StatusCode)
            {
                Post(value.OldMasterCash);
                return postResult;
            }
            else return postResult;
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public ObjectResult Delete([FromBody]MasterCash value)
        {
            using (var context = new VIISDBContext())
            {
                return Execute(new DBMasterCash(value, context.MastersCashTt, new RemovableDBQuery<MastersCashTt>(context.MastersCashTt, context)));
            }
        }

        protected ObjectResult Execute(IDocument document)
        {
            try
            {
                document.Transfer();
            }
            catch(ArgumentException ex)
            {
                return Created("", ex.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return BadRequest(ModelState);
            }
            return Ok(string.Empty);
        }
    }
}
