namespace SyncFramework;

public class DataTarget<TY> : IDataTarget<TY>
{
    List<TY> _targetData = new List<TY>();

    public List<TY> Value { get { return _targetData; } }

    public void Write(TY item)
    {
        _targetData.Add(item);
    }
}
