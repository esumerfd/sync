namespace SyncFramework;

public interface IDataTraverse<TX>
{
    void Traverse(IDataSource<TX> dataSource, Action<TX> callback);
}

