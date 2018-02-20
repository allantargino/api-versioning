using Body.Models;
using Body.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Body.Controllers
{
    [Route("api/[controller]")]
    public class OperationsController : Controller
    {
        // POST api/values
        [HttpPost]
        public object Post([FromBody]VersionedObject value)
        {
            var data = VersioningManager.UnpackVersionedData(value);

            // Do something

            return data;
        }
    }
}
