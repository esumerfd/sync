namespace SyncFramework;

public interface IDataTraverse<TX>
{
    void Traverse(Action<TX> callback);
}

