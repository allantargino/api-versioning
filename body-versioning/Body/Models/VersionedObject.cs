using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Body.Models
{
    public class VersionedObject
    {
        public string Version { get; set; }
        public object Data { get; set; }
    }
}
