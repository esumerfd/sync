namespace SyncFramework;

public class MetaDataNode<TX, TY>
{
    // Convert from a source item to a target item
    public IDataConverter<TX, TY> Converter { get; set; } = new DataConverterNoOp<TX, TY>();

    // A sequence of source items
    public IDataSource<TX> Source { get; set; } = new DataSourceNoOp<TX>();

    // A sequence of target items.
    public IDataTarget<TY> Target { get; set; } = new DataTargetNoOp<TY>();

    // Does the value being converted already exist in the target.
    public IDataExists<TY> Existence { get; set; } = new DataExistsNoOp<TY>();

    // If it already exists has any of its data changed.
    public IDataChanged<TY> Changed { get; set; } = new DataChangedNoOp<TY>();
}
