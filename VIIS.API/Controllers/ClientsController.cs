using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VIIS.API.Customers.Models;
using VIIS.API.JwtBearer.Models;
using VIIS.Domain.Customers;

namespace VIIS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Clients")]
    //[Authorize(AuthenticationSchemes = JwtAuthScheme.scheme)]
    public class ClientsController : Controller
    {
        // GET: api/Clients
        [HttpGet]
        public IEnumerable<Client> Get()
        {
            using (var context = new Data.DBObjects.VIISDBContext())
            {
                return new DBClients(context);
            }
        }

        // GET: api/Clients/5
        [HttpGet("api/Clients/{id}"/*, Name = "Get"*/)]
        public Client Get(int id)
        {
            return new Client();
        }
        
        // POST: api/Clients
        [HttpPost]
        public ActionResult Post([FromBody]Client value)
        {
            using (var context = new Data.DBObjects.VIISDBContext())
            {
                var client = new InsertableDBClient(new DBClient(value));
                client.Transfer();
            }
            return Ok();
        }

        // PUT: api/Clients/5
        [HttpPut("{id}")]
        public ActionResult Put([FromBody]Client value)
        {
            try
            {
                var client = new ValidDBClient(new UpdatableDBClient(new DBClient(value)));
                client.Transfer();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return BadRequest(ModelState);
            }
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete([FromBody]Client value)
        {
            try
            {
                var client = new ValidDBClient(new RemovableDBClient(new DBClient(value)));
                client.Transfer();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return BadRequest(ModelState);
            }
            return Ok();
        }
    }
}
