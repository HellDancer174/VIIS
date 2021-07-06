using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VIIS.API.JwtBearer.Models;

namespace VIIS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Masters")]
    [Authorize(AuthenticationSchemes = JwtAuthScheme.scheme)]
    public class MastersController : Controller
    {
        // GET: api/Masters
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Masters/5
        [HttpGet("api/Masters/{id}"/*, Name = "Get"*/)]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Masters
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Masters/5
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
