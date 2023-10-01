namespace SyncFramework;

public class DataStateInt : IDataExists<int>, IDataChanged<int>
{
    List<int> _list;

    public DataStateInt(List<int> list)
    {
        _list = list;
    }

    public bool Exists(int item)
    {
        return _list.Contains(item);
    }

    public bool Changed(int odds, int ends)
    {
        return odds.CompareTo(ends) != 0;
    }
}
