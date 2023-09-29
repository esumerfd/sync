namespace SyncFramework;

public class SyncTest
{
    [Fact]
    public void Should_sync_a_string()
    {
        var converter = DataConverter.Factory<string, string>();

        var syncSource = new DataSourceList<string>
        {
            Source = new List<string> { "A", "B" },
        };
        var syncTarget = new DataTargetList<string>();

        Sync<string, string>.OneWay(syncSource, syncTarget, converter);

        Assert.Equal(new List<string> { "A", "B" }, syncTarget.Target);
    }

    [Fact]
    public void Should_sync_a_int()
    {
        var converter = DataConverter.Factory<int, int>();

        var syncSource = new DataSourceList<int>
        {
            Source = new List<int> { 1, 2 },
        };
        var syncTarget = new DataTargetList<int>();

        Sync<int, int>.OneWay(syncSource, syncTarget, converter);

        Assert.Equal(new List<int> { 1, 2 }, syncTarget.Target);
    }

    [Fact]
    public void Should_acccept_meta_data_about_sync()
    {
        var metaData = new MetaData
        {
            Traverse = typeof(TraverseList<int>),
            Root = new MetaDataNode
            {
                Converter = (typeof(int), typeof(string)),
                Source = typeof(DataSourceList<int>),
                Target = typeof(DataTargetList<string>),
            }
        };

        var sync = new Sync(metaData);
        sync.OneWay();
    }

    [Fact(Skip="not written yet")]
    public void Should_not_sync_if_target_already_exists()
    {
        var converter = DataConverter.Factory<int, int>();

        var syncSource = new DataSourceList<int>
        {
            Source = new List<int> { 1, 2 },
        };
        var syncTarget = new DataTargetList<int>
        {
            Target = new List<int> { 1 },
        };

        Sync<int, int>.OneWay(syncSource, syncTarget, converter);

        Assert.Equal(new List<int> { 1, 2 }, syncTarget.Target);
    }

    [Fact(Skip="not written yet")]
    public void Should_not_changed_then_do_not_sync()
    {
        var converter = DataConverter.Factory<string, string>();

        var syncSource = new DataSourceList<string>
        {
            Source = new List<string> { "a", "B" },
        };
        var syncTarget = new DataTargetList<string>
        {
            Target = new List<string> { "A", "B" },
        };

        Sync<string, string>.OneWay(syncSource, syncTarget, converter);

        Assert.Equal(new List<string> { "a", "B" }, syncTarget.Target);
    }
}
