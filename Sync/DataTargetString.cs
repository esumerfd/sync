namespace SyncFramework;

public class DataTargetString : IDataTarget<string>
{
    List<string> _targetData = new List<string>();

    public List<string> Value { get { return _targetData; } }

    public void Convert(string value)
    {
        _targetData.Add((string)value);
    }
}
