using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace KursiIm.Business
{
    public static class HidePasswordFromDeserialization
    {
        public static object Hide(byte[] obj)
        {
            var deserializationObj = JsonConvert.DeserializeObject(Encoding.UTF8.GetString(obj));

            if (deserializationObj == null)
                return null;

            var jObj = JObject.FromObject(deserializationObj);

            var pwdProperty = jObj.Property("Password");
            var saltPwdProperty = jObj.Property("SaltedPassword");
            var refreshTokenProperty = jObj.Property("RefreshToken");

            if (pwdProperty != null)
            {
                pwdProperty.Value = "*****";
            }

            if (saltPwdProperty != null)
            {
                saltPwdProperty.Value = "*****";
            }

            if (refreshTokenProperty != null)
            {
                refreshTokenProperty.Value = "*****";
            }

            return jObj;
        }
    }
}
