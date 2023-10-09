namespace SyncFramework;

public class MetaDataNode<TX, TY>
{
    // Convert from a source value to a target value
    public IDataConverter<TX, TY> Converter { get; set; } = new DataConverterNoOp<TX, TY>();

    // A sequence of source values.
    public IDataSource<TX> Source { get; set; } = new DataSourceNoOp<TX>();

    // A sequence of target values.
    public IDataTarget<TY> Target { get; set; } = new DataTargetNoOp<TY>();

    // Manage choice if insert/update
    public ISyncUpsert<TY> Upsert { get; set; } = new UpsertIf<TY>(new DataExistsNoOp<TY>(), new DataChangedNoOp<TY>());
}
