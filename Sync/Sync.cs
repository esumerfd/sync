namespace SyncFramework;

public class Sync<T>
{
    public static void OneWay(IDataSource<T> source, IDataTarget<T> target)
    {
        new Sync<T>(source, target).Run();
    }

    IDataSource<T> _dataSource;
    IDataTarget<T> _dataTarget;

    public Sync(IDataSource<T> source, IDataTarget<T> target)
    {
        _dataSource = source;
        _dataTarget = target;
    }

    void Run()
    {
        Traverse(_dataSource, (item) => 
        { 
            _dataTarget.Convert(item);
        });
    }

    void Traverse(IDataSource<T> source, Action<T> callback)
    {
        foreach (var item in _dataSource)
        {
            callback((T)item);
        }
    }

    bool IsDifferent(IDataSource<T> source, IDataTarget<T> target)
    {
        return true;
    }
}
