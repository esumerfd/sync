namespace SyncFramework;

public class TraverseNoOp<TX, TY> : IDataTraverse<TX, TY>
{
    public void Traverse(IDataSource<TX> dataSource, IDataTarget<TY> target, Action<TX, IDataTarget<TY>> callback)
    {
    }
}
