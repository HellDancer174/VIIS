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
        protected void Transfer(IDocument document) => document.Transfer();

        protected virtual ObjectResult Execute<T>(IDocument document, T OkValue)
        {
            try
            {
                Transfer(document);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                if (ex.InnerException != null) ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                return BadRequest(ModelState);
            }
            return Ok(OkValue);
        }

        protected ObjectResult Execute(IDocument document) => Execute(document, string.Empty);

        protected T TryGet<T>(Func<T> get)
        {
            try
            {
                return get.Invoke();
            }
            catch (Exception)
            {
                return default(T);
            }
        }

    }
}