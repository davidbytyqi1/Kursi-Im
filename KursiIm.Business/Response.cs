using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using KursiIm.SharedModel.General;

namespace KursiIm.Business
{
    public class Response<T> //where T : class
    {
        public int Status { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<T> Data { get; set; }

        public Response()
        {
        }

        public Response(PublicResultStatusCodes status)
        {
            Status = (int)status;
        }

        public Response(PublicResultStatusCodes status, IList<T> data)
        {
            Status = (int)status;
            Data = data;
        }

        public Response(PublicResultStatusCodes status, T data)
        {
            Status = (int)status;
            Data = new List<T>() { data };
        }
    }
}
