namespace SyncFramework;

public class DataSource<T> : IDataSource<T>
{
    List<T> _sourceData = new List<T>();

    public List<T> Source { set { _sourceData = value; } }

    public IEnumerator GetEnumerator()
    {
        return (IEnumerator)_sourceData.GetEnumerator();
    }
}

