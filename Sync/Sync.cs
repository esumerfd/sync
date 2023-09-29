namespace SyncFramework;

public class Sync<TX, TY>
{
    public static void OneWay(
            IDataSource<TX> source,
            IDataTarget<TY> target,
            //IDataTargetExplorer<TY> targetExplorer,
            IDataConverter<TX, TY> converter)
    {
        new Sync<TX, TY>(source, target, /*targetExplorer,*/ converter).Run();
    }

    IDataSource<TX> _dataSource;
    IDataTarget<TY> _dataTarget;
    //IDataTargetExplorer<TY> _dataTargetExplorer;
    IDataConverter<TX, TY> _dataConverter;

    public Sync(IDataSource<TX> source,
            IDataTarget<TY> target,
            //IDataTargetExplorer<TY> targetExplorer,
            IDataConverter<TX, TY> converter)
    {
        _dataSource = source;
        _dataTarget = target;
        //_dataTargetExplorer = targetExplorer;
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

public interface IDataTraverse<TX>
{
    void Traverse(Action<TX> callback);
}

public class TraverseList<TX> : IDataTraverse<TX>
{
    IDataSource<TX> _dataSource;

    public TraverseList(IDataSource<TX> dataSource)
    {
        _dataSource = dataSource;
    }

    public void Traverse(Action<TX> callback)
    {
        foreach (var item in _dataSource)
        {
            callback((TX)item);
        }
    }
}
