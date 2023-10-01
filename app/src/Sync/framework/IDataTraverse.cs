namespace SyncFramework;

public interface IDataTraverse<TX, TY>
{
    void Traverse(IDataSource<TX> dataSource, IDataTarget<TY> target, Action<TX, IDataTarget<TY>> callback);
}

