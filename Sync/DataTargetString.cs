namespace SyncFramework;

public class DataTarget<T> : IDataTarget<T>
{
    List<T> _targetData = new List<T>();

    public List<T> Value { get { return _targetData; } }

    public void Convert(T value)
    {
        _targetData.Add((T)value);
    }
}
