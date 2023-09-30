namespace SyncFramework;

public class MetaData<TX, TY>
{
    public IDataTraverse<TX> Traverser = new TraverseNoOp<TX>();
    public MetaDataNode<TX, TY> Root = new MetaDataNode<TX, TY>();
}
