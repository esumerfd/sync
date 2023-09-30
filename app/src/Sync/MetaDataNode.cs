namespace SyncFramework;

public class MetaDataNode<TX, TY>
{
    // Convert from a source item to a target item
    public IDataConverter<TX, TY> Converter { get; set; } = new DataConverterNoOp<TX, TY>();

    // A sequence of source items
    public IDataSource<TX> Source { get; set; } = new DataSourceNoOp<TX>();

    // A sequence of target items.
    public IDataTarget<TY> Target { get; set; } = new DataTargetNoOp<TY>();

    // Recurse to next layer of data structure to sync
    //public MetaDataNode? Node;
}
