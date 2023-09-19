namespace SyncFramework;

public class SyncTest
{
    [Fact]
    public void Should_sync_a_string()
    {
        var syncSource = new DataSource<string>
        {
            Source = new List<string> { "A", "B" },
        };
        var syncTarget = new DataTarget<string>();

        Sync<string>.OneWay(syncSource, syncTarget);

        Assert.Equal(new List<string> { "A", "B" }, syncTarget.Value);
    }

    [Fact]
    public void Should_sync_a_int()
    {
        var syncSource = new DataSource<int>
        {
            Source = new List<int> { 1, 2 },
        };
        var syncTarget = new DataTarget<int>();

        Sync<int>.OneWay(syncSource, syncTarget);

        Assert.Equal(new List<int> { 1, 2 }, syncTarget.Value);
    }
}
