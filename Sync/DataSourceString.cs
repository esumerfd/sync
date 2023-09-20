namespace SyncFramework;

public class DataSource<TX> : IDataSource<TX>
{
    List<TX> _sourceData = new List<TX>();

    public List<TX> Source { set { _sourceData = value; } }

    public IEnumerator GetEnumerator()
    {
        return (IEnumerator)_sourceData.GetEnumerator();
    }
}

