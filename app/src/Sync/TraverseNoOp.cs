namespace SyncFramework;

public class TraverseNoOp<TX> : IDataTraverse<TX>
{
    public void Traverse(Action<TX> callback)
    {
    }
}


