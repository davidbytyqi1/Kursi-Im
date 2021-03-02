using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursiIm.Business
{
    public class ConvertToBinaryHelper<T>
    {
        public static Tuple<byte[], byte[]> SerializeAndConvert(T before, T after)
        {
            var serializedBefore = JsonConvert.SerializeObject(before);
            var serializedAfter = JsonConvert.SerializeObject(after);

            var beforeByte = Encoding.UTF8.GetBytes(serializedBefore);
            var afterByte = Encoding.UTF8.GetBytes(serializedAfter);

            return new Tuple<byte[], byte[]>(beforeByte, afterByte);
        }

        public static byte[] SerializeAndConvert(T obj)
        {
            var serializedObj = JsonConvert.SerializeObject(obj);

            var objByte = Encoding.UTF8.GetBytes(serializedObj);

            return objByte;
        }
    }
}
