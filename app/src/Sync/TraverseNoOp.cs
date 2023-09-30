namespace SyncFramework;

public class TraverseNoOp<TX> : IDataTraverse<TX>
{
    public void Traverse(IDataSource<TX> dataSource, Action<TX> callback)
    {
    }
}
