using System.Collections.Generic;
using UnityEngine;

public class SaveSystem
{
    private readonly IDataSaver _saver;
    private readonly IDataSerializer _serializer;

    public SaveSystem(IDataSaver saver, IDataSerializer serializer)
    {
        _saver = saver;
        _serializer = serializer;
    }

    public void SaveData(Dictionary<string, object> data)
    {
        var serializedData = _serializer.SerializeData(data);
        Dictionary<string, object> container = JsonUtility.FromJson<Dictionary<string, object>>(serializedData);
        _saver.SaveData(container);
    }

    public Dictionary<string, object> LoadData()
    {
        var serializedData = _saver.LoadData();
        string jsonString = JsonUtility.ToJson(serializedData);
        return _serializer.DeserializeData(jsonString);
    }
}