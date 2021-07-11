﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VIIS.API.Data.DBObjects;
using VIIS.API.Employees.Models;
using VIIS.API.GlobalModel;
using VIIS.API.JwtBearer.Models;
using VIIS.Domain.Staff;

namespace VIIS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Masters")]
    //[Authorize(AuthenticationSchemes = JwtAuthScheme.scheme)]
    public class MastersController : Controller
    {
        // GET: api/Masters
        [HttpGet]
        public IEnumerable<Master> Get()
        {
            using (var context = new VIISDBContext())
            {
                return new DBEmployees(context);
            }
        }

        // GET: api/Masters/5
        [HttpGet("api/Masters/{id}"/*, Name = "Get"*/)]
        public Master Get(int id)
        {
            return new Master();
        }
        
        // POST: api/Masters
        [HttpPost]
        public ActionResult Post([FromBody]Master value)
        {
            using (var context = new VIISDBContext())
            {
                return Execute(new DBMaster(value, new DBQuery<EmployeesTt>(context.EmployeesTt, context), new DBQuery<PassportsTt>(context.PassportsTt, context),
                    new DBQuery<PersonsTt>(context.PersonsTt, context), new DBQuery<AddressesTt>(context.AddressesTt, context)));
            }
        }

        // PUT: api/Masters/5
        [HttpPut("{id}")]
        public ActionResult Put([FromBody]Master value)
        {
            using (var context = new VIISDBContext())
            {
                return Execute(new ValidMaster(new DBMaster(value, new UpdatableDBQuery<EmployeesTt>(context.EmployeesTt, context), new UpdatableDBQuery<PassportsTt>(context.PassportsTt, context),
                    new UpdatableDBQuery<PersonsTt>(context.PersonsTt, context), new UpdatableDBQuery<AddressesTt>(context.AddressesTt, context))));
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete([FromBody]Master value)
        {
            using (var context = new VIISDBContext())
            {
                return Execute(new ValidMaster(new RemovableDBMaster(value, new RemovableDBQuery<EmployeesTt>(context.EmployeesTt, context), new RemovableDBQuery<PassportsTt>(context.PassportsTt, context),
                    new RemovableDBQuery<PersonsTt>(context.PersonsTt, context), new RemovableDBQuery<AddressesTt>(context.AddressesTt, context))));
            }
        }

        private ActionResult Execute(Master model)
        {
            try
            {
                model.Transfer();
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