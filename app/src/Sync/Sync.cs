namespace SyncFramework;

public class Sync
{
    MetaData _metaData;

    public Sync(MetaData metaData)
    {
        _metaData = metaData;
    }

    public void OneWay()
    {
    }
}
 
public class Sync<TX, TY>
{
    public static void OneWay(
            IDataSource<TX> source,
            IDataTarget<TY> target,
            IDataConverter<TX, TY> converter)
    {
        new Sync<TX, TY>(source, target, converter).Run();
    }

    IDataSource<TX> _dataSource;
    IDataTarget<TY> _dataTarget;
    IDataConverter<TX, TY> _dataConverter;

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
        var traverse = new TraverseList<TX>(_dataSource);
        traverse.Traverse((item) => 
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


