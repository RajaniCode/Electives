using System;

//Add reference to System.Runtime.Serialization
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

// Json Serialization and Deserialization Class
public class JsonForGenericCollections<T>
{ 
    // Json Serialization
    public static string JsonSerialize(T t)
    {         
        DataContractJsonSerializer Serializer = new DataContractJsonSerializer(typeof(T));

        MemoryStream Memory = new MemoryStream();
        Serializer.WriteObject(Memory, t);
        
        string Encode = Encoding.UTF8.GetString(Memory.ToArray());
        Memory.Close();

        //Replace Json Date String                                         
        string Pattern = @"\\/Date\((\d+)\+\d+\)\\/";        
        MatchEvaluator Evaluator = new MatchEvaluator(ConvertJsonDateTimeToDateTimeString);
        
        Regex Reg = new Regex(Pattern);
        Encode = Reg.Replace(Encode, Evaluator);
        return Encode;
    }

    // Json Deserialization
    public static T JsonDeserialize(string s)
    {
        //Convert "yyyy-MM-dd HH:mm:ss" String as "\/Date(1319266795390+0800)\/"
        string Pattern = @"\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2}";
        MatchEvaluator Evaluator = new MatchEvaluator(ConvertDateTimeStringToJsonDateTime);
        
        Regex Reg = new Regex(Pattern);
        s = Reg.Replace(s, Evaluator);
        
        DataContractJsonSerializer Serializer = new DataContractJsonSerializer(typeof(T));
        MemoryStream Memory = new MemoryStream(Encoding.UTF8.GetBytes(s));
       
        T t = (T)Serializer.ReadObject(Memory);
        return t;
    }

    // Convert Json Serialized DateTime(1319266795390+0800) as String
    private static string ConvertJsonDateTimeToDateTimeString(Match m)
    {
        string Result = string.Empty;
        DateTime DT = new DateTime(1970, 1, 1);
        DT = DT.AddMilliseconds(long.Parse(m.Groups[1].Value));
        DT = DT.ToLocalTime();
        Result = DT.ToString("yyyy-MM-dd HH:mm:ss");
        return Result;
    }

    // Convert DateTime String as Json Time
    private static string ConvertDateTimeStringToJsonDateTime(Match m)
    {
        string Result = string.Empty;
        DateTime DT = DateTime.Parse(m.Groups[0].Value);
        DT = DT.ToUniversalTime();
        TimeSpan TS = DT - DateTime.Parse("1970-01-01");
        Result = string.Format("\\/Date({0}+0800)\\/", TS.TotalMilliseconds);
        return Result;
    }
}