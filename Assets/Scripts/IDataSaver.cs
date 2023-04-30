using System.Collections.Generic;

public interface IDataSaver
{
    void SaveData(Dictionary<string, object> data);
    Dictionary<string, object> LoadData();
}
