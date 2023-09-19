namespace SyncFramework;

public class SyncTest
{
    [Fact]
    public void Should_sync_a_string()
    {
        var syncSource = new DataSourceString
        {
            Source = new List<string> { "A" },
            //compare = new StringCompare(),
        };
        var syncTarget = new DataTargetString
        {
            //target = new List<DataSourceString>(),
        };

        Sync<string>.OneWay(syncSource, syncTarget);

        Console.WriteLine($"Target: {syncTarget.Value}");

        Assert.Equal(new List<string> { "A" }, syncTarget.Value);
    }
}
