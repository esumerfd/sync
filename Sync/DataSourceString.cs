namespace SyncFramework;

public class DataSourceString : IDataSource<string>
{
    List<string> _sourceData = new List<string>();

    public List<string> Source { set { _sourceData = value; } }

    public IEnumerator GetEnumerator()
    {
        return (IEnumerator)_sourceData.GetEnumerator();
    }
}

