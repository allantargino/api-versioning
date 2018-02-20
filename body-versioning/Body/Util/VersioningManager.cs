using Body.Exceptions;
using Body.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Body.Util
{
    public class VersioningManager
    {
        private static IEnumerable<string> AvailableVersions
            => new List<string>{"V1", "V2", "V3"}; //Use Reflection?

        public static object UnpackData(VersionedObject versionedObject)
        {
            var desiredVersion = versionedObject.Version.ToUpper();

            if (!AvailableVersions.Contains(desiredVersion))
                throw new VersionNotSupportedException(desiredVersion, AvailableVersions);

            var data = versionedObject.Data;

            if (data == null)
                throw new ArgumentNullException(nameof(data));

            return data;
        }
    }
}
