namespace SyncFramework;

public class MetaDataTest
{
    [Fact]
    public void Should_declare()
    {
        var metaData = new MetaData
        {
            Traverse = typeof(TraverseList<int>),
            Root = new MetaDataNode
            {
                Converter = (typeof(int), typeof(string)),
                Source = typeof(DataSourceList<int>),
                Target = typeof(DataTargetList<string>),
                
                Node = new MetaDataNode(),
            }
        };
    }
}
