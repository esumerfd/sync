namespace SyncFramework;

public class TraverseList<TX> : IDataTraverse<TX>
{
    IDataSource<TX> _dataSource;

    public TraverseList(IDataSource<TX> dataSource)
    {
        _dataSource = dataSource;
    }

    public void Traverse(Action<TX> callback)
    {
        foreach (var item in _dataSource)
        {
            callback((TX)item);
        }
    }
}

