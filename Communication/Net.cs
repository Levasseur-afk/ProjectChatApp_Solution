using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Communication
{
    public class Net
    {
        public static void sendMsg(Stream s, String msg)
        {
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(s, msg);
        }

        public static String rcvMsg(Stream s)
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                return (String)bf.Deserialize(s);
            }
            catch (System.IO.IOException)
            {
                return "";
            }
            catch (System.Runtime.Serialization.SerializationException)
            {
                return "";
            }
        }
    }
}
