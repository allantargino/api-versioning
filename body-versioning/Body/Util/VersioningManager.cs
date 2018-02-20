using Body.Exceptions;
using Body.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Body.Util
{
    public class VersioningManager
    {
        private static IEnumerable<string> AvailableVersions
            => new List<string> { "V1", "V2" };

        private static object CastObjectToVersion(string version, JObject data) //Reflection?
        {
            switch (version)
            {
                case "V1":
                    return data.ToObject<Models.V1.Project>();
                case "V2":
                    return data.ToObject<Models.V2.Project>();
                default:
                    throw new VersionNotSupportedException(version, AvailableVersions);
            }
        }

        private static JObject UnpackData(VersionedObject versionedObject)
        {
            var data = versionedObject.Data;

            if (data == null)
                throw new ArgumentNullException(nameof(data));

            return (JObject)data;
        }

        private static string UnpackVersion(VersionedObject versionedObject)
        {
            var desiredVersion = versionedObject.Version.ToUpper();

            if (!AvailableVersions.Contains(desiredVersion))
                throw new VersionNotSupportedException(desiredVersion, AvailableVersions);

            return desiredVersion;
        }

        public static object UnpackVersionedData(VersionedObject versionedObject)
        {
            string version = UnpackVersion(versionedObject);
            JObject data = UnpackData(versionedObject);

            return CastObjectToVersion(version, data);
        }
    }
}
