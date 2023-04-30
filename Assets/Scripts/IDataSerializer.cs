using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public interface IDataSerializer
{
    string SerializeData(Dictionary<string, object> data);
    Dictionary<string, object> DeserializeData(string data);
}

public class JsonDataSerializer : IDataSerializer
{
    public string SerializeData(Dictionary<string, object> data)
    {
        return JsonUtility.ToJson(data);
    }

    public Dictionary<string, object> DeserializeData(string data)
    {
        return JsonUtility.FromJson<Dictionary<string, object>>(data);
    }
}

public class BinaryDataSerializer : IDataSerializer
{
    public string SerializeData(Dictionary<string, object> data)
    {
        BinaryFormatter bf = new BinaryFormatter();
        MemoryStream ms = new MemoryStream();
        bf.Serialize(ms, data);
        byte[] binary = ms.ToArray();
        return Convert.ToBase64String(binary); 
    }

    public Dictionary<string, object> DeserializeData(string data)
    {
        byte[] binary = Convert.FromBase64String(data);

        // Convert binary to dictionary
        BinaryFormatter bf = new BinaryFormatter();
        MemoryStream ms = new MemoryStream(binary);
        return (Dictionary<string, object>)bf.Deserialize(ms);
    }
}