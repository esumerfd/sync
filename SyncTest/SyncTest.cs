namespace SyncFramework;

public class SyncTest
{
    [Fact]
    public void Should_sync_a_string()
    {
        var converter = DataConverter.Factory<string, string>();

        var syncSource = new DataSource<string>
        {
            Source = new List<string> { "A", "B" },
        };
        var syncTarget = new DataTarget<string>();

        Sync<string, string>.OneWay(syncSource, syncTarget, converter);

        Assert.Equal(new List<string> { "A", "B" }, syncTarget.Value);
    }

    [Fact(Skip = "not yet")]
    public void Should_sync_a_int()
    {
        var converter = DataConverter.Factory<int, int>();

        var syncSource = new DataSource<int>
        {
            Source = new List<int> { 1, 2 },
        };
        var syncTarget = new DataTarget<int>();

        Sync<int, int>.OneWay(syncSource, syncTarget, converter);

        Assert.Equal(new List<int> { 1, 2 }, syncTarget.Value);
    }
}
