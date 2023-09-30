namespace SyncFramework;

public class Sync<TX, TY>
{
    public static void OneWay(
            IDataSource<TX> source,
            IDataTarget<TY> target,
            IDataConverter<TX, TY> converter)
    {
        new Sync<TX, TY>(source, target, converter).Run();
    }

    MetaData<TX, TY> _metaData = new MetaData<TX,TY>();

    public Sync(MetaData<TX, TY> metaData)
    {
        _metaData = metaData;
    }

    public void OneWay()
    {
    }

    IDataSource<TX> _dataSource = new DataSourceNoOp<TX>();
    IDataTarget<TY> _dataTarget = new DataTargetNoOp<TY>();
    IDataConverter<TX, TY> _dataConverter = new DataConverterNoOp<TX, TY>();

    public Sync(IDataSource<TX> source,
            IDataTarget<TY> target,
            IDataConverter<TX, TY> converter)
    {
        _dataSource = source;
        _dataTarget = target;
        _dataConverter = converter;
    }

    void Run()
    {
        var traverse = new TraverseList<TX>();
        traverse.Traverse(_dataSource, (item) => 
        { 
            var convertedItem = _dataConverter.Convert(item);

            //if (!_dataTargetExplorer.Exists(convertedItem)
                //&& _dataTargetExplorer.Changed(convertedItem))
            //{

                _dataTarget.Write(convertedItem);
            //}
        });
    }

}


