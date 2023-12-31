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
            Traverser = new TraverseList<TX, TY>(),
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
        var traverser = _metaData.Traverser;

        var rootSource = _metaData.Root.Source;
        var rootTarget = _metaData.Root.Target;
        var converter = _metaData.Root.Converter;
        var upsert = _metaData.Root.Upsert;

        traverser.Traverse(rootSource, rootTarget, (TX item, IDataTarget<TY> target) =>
        {
            var audit = $"item({item?.GetType().Name}): ";

            var convertedItem = converter.Convert(item);    

            audit += $"converted({converter.GetType().Name}), ";

            upsert.Sync(convertedItem, rootTarget, 
                create: (createValue) =>
                {
                    audit += $"exists(true), ";
                    target.Create(createValue);
                    audit += "written, ";
                }, 
                update: (updateValue) =>
                {
                    audit += $"exists(false), ";
                    target.Update(updateValue);
                    audit += "updated";
                }
            );

            Console.WriteLine($"Audit: {audit}");
        });
    }
}
