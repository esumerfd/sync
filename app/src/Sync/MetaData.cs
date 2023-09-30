namespace SyncFramework;

public class MetaData<TX, TY>
{
    public IDataTraverse<TX> Traverse = new TraverseNoOp<TX>();
    public MetaDataNode<TX, TY>? Root;
}
