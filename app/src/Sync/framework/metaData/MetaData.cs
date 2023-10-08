namespace SyncFramework;

public class MetaData<TX, TY>
{
    public IDataTraverse<TX, TY> Traverser = new TraverseNoOp<TX, TY>();
    public MetaDataNode<TX, TY> Root = new MetaDataNode<TX, TY>();
}
