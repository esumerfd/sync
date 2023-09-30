namespace SyncFramework;

public class MetaDataTest
{
    [Fact]
    public void Should_declare()
    {
        var metaData = new MetaData<int, string>
        {
            Traverse = new TraverseList<int>(),
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
