namespace SyncFramework;

public class Sync<TX, TY>
{
    public static void OneWay(
            IDataSource<TX> source,
            IDataTarget<TY> target,
            IDataConverter<TX, TY> converter)
    {
        new Sync<TX, TY>(new MetaData<TX, TY>
        {
            Traverser = new TraverseList<TX>(),
            Root = new MetaDataNode<TX, TY>
            {
                Converter = converter,
                Source = source,
                Target = target,
            }
        }).OneWay();
}

    MetaData<TX, TY> _metaData = new MetaData<TX,TY>();

    public Sync(MetaData<TX, TY> metaData)
    {
        _metaData = metaData;
    }

    public void OneWay()
    {
        Run();
    }

    void Run()
    {
        var source = _metaData.Root.Source;
        _metaData.Traverser.Traverse(source, (TX item) =>
        {
            var convertedItem = _metaData.Root.Converter.Convert(item);    
            _metaData.Root.Target.Write(convertedItem);
        });
    }
}
