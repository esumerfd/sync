namespace SyncFramework;

public class MetaDataTest
{
    [Fact]
    public void Should_declare()
    {
        var metaData = new MetaData<int, string>
        {
            Traverser = new TraverseList<int, string>(),
            Root = new MetaDataNode<int, string>
            {
                Converter = DataConverter.Factory<int, string>(),
                Source = new DataSourceList<int>(),
                Target = new DataTargetList<string>(),
                
                //Node = new MetaDataNode<int, int>(),
            }
        };
    }
}
