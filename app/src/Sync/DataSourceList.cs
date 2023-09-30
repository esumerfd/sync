namespace SyncFramework;

public class DataSourceList<TX> : IDataSource<TX>
{
    List<TX> _sourceData = new List<TX>();

    public List<TX> Source { set { _sourceData = value; } }

    public IEnumerator<TX> GetEnumerator()
    {
        return _sourceData.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

