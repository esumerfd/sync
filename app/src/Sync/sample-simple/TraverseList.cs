namespace SyncFramework;

public class TraverseList<TX, TY> : IDataTraverse<TX, TY>
{
    public void Traverse(IDataSource<TX> dataSource, IDataTarget<TY> target, Action<TX, IDataTarget<TY>> callback)
    {
        foreach (var item in dataSource)
        {
            callback((TX)item, target);
        }
    }
}

