using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElegantLib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VIIS.API.Controllers.Base
{
    [Produces("application/json")]
    public class DBController : Controller
    {
        protected ObjectResult Execute<T>(IDocument document, T OkValue)
        {
            try
            {
                document.Transfer();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return BadRequest(ModelState);
            }
            return Ok(OkValue);
        }

        protected ObjectResult Execute(IDocument document) => Execute(document, string.Empty);

    }
}