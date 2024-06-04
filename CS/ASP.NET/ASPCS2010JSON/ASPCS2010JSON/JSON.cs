using System;

//Add reference to System.Runtime.Serialization
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;

// Json Serialization and Deserialization Class
public class Json
{
    // Json Serialization
    public static string JsonSerialize<T>(T t)
    {
        DataContractJsonSerializer Serializer = new DataContractJsonSerializer(typeof(T));
        MemoryStream Memory = new MemoryStream();
        Serializer.WriteObject(Memory, t);
        string s = Encoding.UTF8.GetString(Memory.ToArray());
        Memory.Close();
        return s;
    }

    // Json Deserialization
    public static T JsonDeserialize<T>(string s)
    {
        DataContractJsonSerializer Serializer = new DataContractJsonSerializer(typeof(T));
        MemoryStream Memory = new MemoryStream(Encoding.UTF8.GetBytes(s));
        T t = (T)Serializer.ReadObject(Memory);
        return t;
    }
}