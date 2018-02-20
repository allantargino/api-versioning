using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Body.Models;
using Body.Util;
using Microsoft.AspNetCore.Mvc;

namespace Body.Controllers
{
    [Route("api/[controller]")]
    public class OperationsController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/values
        [HttpPost]
        public int Post([FromBody]VersionedObject value)
        {
            var data = VersioningManager.UnpackData(value);

            // Do something
            return data.GetHashCode();
        }
    }
}
