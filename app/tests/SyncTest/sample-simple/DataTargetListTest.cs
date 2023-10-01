namespace SyncFramework;

public class DataTargetListTest
{
    [Fact]
    public void Should_add_an_item()
    {
        var target = new DataTargetList<string>();
        target.Write("a");

        Assert.Contains("a", target.Target);
    }

    [Fact]
    public void Should_throw_if_item_doesnt_exist()
    {
        var target = new DataTargetList<string>();

        Assert.Throws<KeyNotFoundException>(() => target.Get("A"));
    }

    [Fact]
    public void Should_get_an_item()
    {
        var target = new DataTargetList<string>();
        target.Write("a");

        Assert.Equal("a", target.Get("a"));
    }
}
