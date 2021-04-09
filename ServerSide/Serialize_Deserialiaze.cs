using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace ServerSide
{
    class Serialize_Deserialize
    {
        public static void SerializeUsers(Dictionary<string, string> dicoUsers)
        {
            FileStream fs = new FileStream(@"C:\temp\users.out", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, dicoUsers); // for any object
            fs.Close();
        }
        public static Dictionary<string, string> DeserializeUsers()
        {
            FileStream fs = new FileStream(@"C:\temp\users.out", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            Dictionary<string, string> dicoUsers = (Dictionary<string, string>)bf.Deserialize(fs);
            fs.Close();
            return dicoUsers;
        }
    }
}
