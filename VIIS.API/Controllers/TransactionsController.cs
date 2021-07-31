using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VIIS.API.Controllers.Base;
using VIIS.API.Data.DBObjects;
using VIIS.API.Finance;
using VIIS.API.GlobalModel;
using VIIS.API.JwtBearer.Models;
using VIIS.Domain.Finance;

namespace VIIS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Transactions")]
    [Authorize(AuthenticationSchemes = AuthSchemes.JwtScheme)]
    public class TransactionsController : DBController
    {
        // GET: api/Transactions
        [HttpGet]
        public IEnumerable<Transaction> Get()
        {
            using (var context = new VIISDBContext())
            {
                return context.TransactionsTt.Select(entity => new DBTransaction(entity) as Transaction).ToArray();
            }
        }

        // GET: api/Transactions/5
        [HttpGet("api/Transactions/{id}"/*, Name = "Get"*/)]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Transactions
        [HttpPost]
        public ActionResult Post([FromBody]Transaction value)
        {
            using (var context = new VIISDBContext())
            {
                return Execute(new DBTransaction(value, new DBQuery<TransactionsTt>(context.TransactionsTt, context)));
            }

        }

        // PUT: api/Transactions/5
        [HttpPut]
        public ActionResult Put([FromBody]Transaction value)
        {
            using (var context = new VIISDBContext())
            {
                return Execute(new ValidDBTransaction(new DBTransaction(value, new UpdatableDBQuery<TransactionsTt>(context.TransactionsTt, context)), (id) => id > 0));
            }

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public ActionResult Delete([FromBody]Transaction value)
        {
            using (var context = new VIISDBContext())
            {
                return Execute(new ValidDBTransaction(new DBTransaction(value, new RemovableDBQuery<TransactionsTt>(context.TransactionsTt, context)), (id) => id > 0));
            }
        }
    }
}
