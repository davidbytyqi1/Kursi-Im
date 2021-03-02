using KursiIm.SharedModel.Logs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;


namespace KursiIm.Business
{
    public class ChangeLogHelper
    {
        private string DeserializeObject(byte[] bytes)
        {
            BinaryFormatter binForm = new BinaryFormatter();
            using (MemoryStream memStream = new MemoryStream())
            {
                memStream.Write(bytes, 0, bytes.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                return (string)binForm.Deserialize(memStream);
            }
        }
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
        public List<LogData> GetDeserializeObject(byte[] beforeParameter, byte[] afterParameter)
        {
            var before = JsonConvert.DeserializeObject(Encoding.UTF8.GetString(beforeParameter));
            var after = JsonConvert.DeserializeObject(Encoding.UTF8.GetString(afterParameter));

            if (after != null && before != null)
            {
                var jObjBefore = JObject.FromObject(before);
                var jObjAfter = JObject.FromObject(after);
                List<LogData> logData = new List<LogData>();
         
                //var before = new ChangeLogHelper().DeserializeObject(beforeParameter);
                // var after = new ChangeLogHelper().DeserializeObject(afterParameter);

                
                //var jObjBefore = (JObject)JsonConvert.DeserializeObject<dynamic>(null);
                //var jObjAfter = (JObject)JsonConvert.DeserializeObject<dynamic>(after);

                if (jObjBefore != null)
                {
                    for (int i = 0; i < jObjBefore.Children().Count(); i++)
                    {
                        var propBefore = jObjBefore.Children().ElementAt(i) as JProperty;
                        var propAfter = jObjAfter.Children().ElementAt(i) as JProperty;
                        logData.Add(new LogData { Column = propAfter.Name, After = propAfter.Value.ToString(), Before = propBefore.Value.ToString() });
                    }
                    for (int i = 0; i < logData.Count(); i++)
                    {
                        if (logData[i].Column == "Password")
                        {
                            logData[i].Before = "*****";
                            logData[i].After = "*****";
                        }
                        if (logData[i].Column == "ConfirmPassword")
                        {
                            logData[i].Before = "*****";
                            logData[i].After = "*****";
                        }
                        if (logData[i].Column == "Salt")
                        {
                            logData[i].Before = "*****";
                            logData[i].After = "*****";
                        }
                    }
                }
                else
                {
                    logData.Add(new LogData { Column = "Njoftim", Before = "Gabim gjatë deserializimit", After = "Gabim gjatë deserializimit" });
                }
                return logData;
            }
            else if(after != null && before == null)
            {
                List<LogData> logData = new List<LogData>();
                var jObjAfter = JObject.FromObject(after);

                //var before = new ChangeLogHelper().DeserializeObject(beforeParameter);
                //var jObjBefore = (JObject)JsonConvert.DeserializeObject<dynamic>(before);

                if (jObjAfter != null)
                {
                    for (int i = 0; i < jObjAfter.Children().Count(); i++)
                    {
                        var propAfter = jObjAfter.Children().ElementAt(i) as JProperty;
                        logData.Add(new LogData { Column = propAfter.Name, Before = "Inserted", After = propAfter.Value.ToString() });
                    }
                    for (int i = 0; i < logData.Count(); i++)
                    {
                        if (logData[i].Column == "Password")
                        {
                            logData[i].Before = "*****";
                            logData[i].After = "*****";
                        }
                        if (logData[i].Column == "ConfirmPassword")
                        {
                            logData[i].Before = "*****";
                            logData[i].After = "*****";
                        }
                        if (logData[i].Column == "Salt")
                        {
                            logData[i].Before = "*****";
                            logData[i].After = "*****";
                        }
                    }
                }
                else
                {
                    logData.Add(new LogData { Column = "Njoftim", Before = "Gabim gjatë 'deserializimit'", After = "Gabim gjatë 'deserializimit'" });
                }
                return logData;
            }
            else
            {
                List<LogData> logData = new List<LogData>();
                var jObjBefore = JObject.FromObject(before);
              
                //var before = new ChangeLogHelper().DeserializeObject(beforeParameter);
                //var jObjBefore = (JObject)JsonConvert.DeserializeObject<dynamic>(before);

                if (jObjBefore != null)
                {
                    for (int i = 0; i < jObjBefore.Children().Count(); i++)
                    {
                        var propBefore = jObjBefore.Children().ElementAt(i) as JProperty;
                        logData.Add(new LogData { Column = propBefore.Name, Before = propBefore.Value.ToString(), After = "Deleted" });
                    }
                    for (int i = 0; i < logData.Count(); i++)
                    {
                        if (logData[i].Column == "Password")
                        {
                            logData[i].Before = "*****";
                            logData[i].After = "*****";
                        }
                        if (logData[i].Column == "ConfirmPassword")
                        {
                            logData[i].Before = "*****";
                            logData[i].After = "*****";
                        }
                        if (logData[i].Column == "Salt")
                        {
                            logData[i].Before = "*****";
                            logData[i].After = "*****";
                        }
                    }
                }
                else
                {
                    logData.Add(new LogData { Column = "Njoftim", Before = "Gabim gjatë 'deserializimit'", After = "Gabim gjatë 'deserializimit'" });
                }
                return logData;
            }
        }
    }
}
