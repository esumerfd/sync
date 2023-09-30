namespace SyncFramework;

public class TraverseList<TX> : IDataTraverse<TX>
{
    public void Traverse(IDataSource<TX> dataSource, Action<TX> callback)
    {
        foreach (var item in dataSource)
        {
            callback((TX)item);
        }
    }
}

