# SaveSystem
Unity SaveSystem using SOLID principles

Single Responsibility Principle (SRP):
The save system should have a single responsibility of saving and loading data.

Open-Closed Principle (OCP):
The save system should be open for extension but closed for modification. Therefore, we can create a separate class to handle the serialization and deserialization of data to different formats.

Liskov Substitution Principle (LSP):
The save system should allow different implementations of IDataSerializer to be used interchangeably.

Interface Segregation Principle (ISP):
The save system should not depend on methods it does not use. Therefore, we can split IDataSaver into separate interfaces for local and cloud-based saving.

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
        _saver.SaveData(serializedData);
    }

    public Dictionary<string, object> LoadData()
    {
        var serializedData = _saver.LoadData();
        return _serializer.DeserializeData(serializedData);
    }
}

Dependency Inversion Principle (DIP):
The save system should depend on abstractions rather than concretions. Therefore, we can inject the IDataSaver and IDataSerializer interfaces into the SaveSystem constructor, and the ILocalDataSaver and ICloudDataSaver interfaces into their respective implementations.
