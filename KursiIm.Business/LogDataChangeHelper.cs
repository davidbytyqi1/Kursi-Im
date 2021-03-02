using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using KursiIm.SharedModel.Logs;

namespace KursiIm.Business
{
    public class LogDataChangeHelper
    {
        private string DeserializeObject(byte[] bytes)
        {
            //BinaryFormatter binForm = new BinaryFormatter();
            //using (MemoryStream memStream = new MemoryStream())
            //{
            //    memStream.Write(bytes, 0, bytes.Length);
            //    memStream.Seek(0, SeekOrigin.Begin);
            //    return (string)binForm.Deserialize(memStream);
            //}
            return Encoding.UTF8.GetString(bytes);
        }
        public List<LogData> GetDeserializeObject(byte[] beforeParameter, byte[] afterParameter)
        {
            if (afterParameter != null)
            {
                List<LogData> logData = new List<LogData>();

                var before = DeserializeObject(beforeParameter);
                var after = DeserializeObject(afterParameter);

                var jObjBefore = (JObject)JsonConvert.DeserializeObject<dynamic>(before);
                var jObjAfter = (JObject)JsonConvert.DeserializeObject<dynamic>(after);

                if (jObjBefore != null || jObjAfter != null)
                {
                    for (int i = 0; i < jObjBefore.Children().Count(); i++)
                    {
                        var propBefore = jObjBefore.Children().ElementAt(i) as JProperty ?? (JProperty)null;
                        var propAfter = jObjAfter != null ? jObjAfter.Children().ElementAt(i) as JProperty : (JProperty)null;
                        logData.Add(new LogData { Column = propAfter?.Name ?? "Undefined", After = propAfter?.Value?.ToString(), Before = propBefore?.Value?.ToString() });
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
                        if (logData[i].Column == "SaltedPassword")
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
            else
            {
                List<LogData> logData = new List<LogData>();
                var before = DeserializeObject(beforeParameter);
                var jObjBefore = (JObject)JsonConvert.DeserializeObject<dynamic>(before);

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
                        if (logData[i].Column == "SaltedPassword")
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
        public bool CompareHash(byte[] first, byte[] second)
        {
            bool result = true;
            for (int i = 0; i < first.Length; i++)
            {
                if (first[i] != second[i])
                {
                    result = false;
                    break;
                }
            }
            return result;
        }
    }
}
