namespace SyncFramework;

public class DataSourceNoOp<TX> : IDataSource<TX>
{
    public IEnumerator<TX> GetEnumerator()
    {
        return (IEnumerator<TX>)Enumerable.Empty<TX>();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

