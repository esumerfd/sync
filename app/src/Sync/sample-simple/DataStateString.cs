namespace SyncFramework;

public class DataStateString : IDataExists<string>, IDataChanged<string>
{
    List<string> _list;

    public DataStateString(List<string> list)
    {
        _list = list;
    }

    public bool Exists(string item)
    {
        return _list.Contains(item, StringComparer.CurrentCultureIgnoreCase);
    }

    public bool Changed(string odds, string ends)
    {
        return odds.CompareTo(ends) != 0;
    }
}
