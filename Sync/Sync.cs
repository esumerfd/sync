namespace SyncFramework;

public class Sync<TX, TY>
{
    public static void OneWay(IDataSource<TX> source, IDataTarget<TY> target, IDataConverter<TX, TY> converter)
    {
        new Sync<TX, TY>(source, target, converter).Run();
    }

    IDataSource<TX> _dataSource;
    IDataTarget<TY> _dataTarget;
    IDataConverter<TX, TY> _dataConverter;

    public Sync(IDataSource<TX> source, IDataTarget<TY> target, IDataConverter<TX, TY> converter)
    {
        _dataSource = source;
        _dataTarget = target;
        _dataConverter = converter;
    }

    void Run()
    {
        Traverse(_dataSource, (item) => 
        { 
            var convertedItem = _dataConverter.Convert(item);
            _dataTarget.Write(convertedItem);
        });
    }

    void Traverse(IDataSource<TX> source, Action<TX> callback)
    {
        foreach (var item in _dataSource)
        {
            callback((TX)item);
        }
    }
}
