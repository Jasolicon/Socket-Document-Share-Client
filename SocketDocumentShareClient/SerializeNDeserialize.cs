using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SocketDocumentShareClient
{
    public class SerializeNDeserialize
    {
        public static byte[] Serialize(object data)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream rems = new MemoryStream();
            formatter.Serialize(rems, data);
            //rems.Seek(0, SeekOrigin.Begin);
            return rems.GetBuffer();
        }
        public static object Deserialize(byte[] data)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream rems = new MemoryStream(data);
            //rems.Seek(0, SeekOrigin.Begin);
            data = null;
            return formatter.Deserialize(rems);
        }
    }
}
