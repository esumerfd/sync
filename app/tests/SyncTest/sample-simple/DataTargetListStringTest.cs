namespace SyncFramework;

public class DataTargetListStringTest
{
    [Fact]
    public void Should_add_an_item()
    {
        var target = new DataTargetListString();
        target.Create("a");

        Assert.Contains("a", target.Target);
    }

    [Fact]
    public void Should_throw_if_get_doesnt_find_item()
    {
        var target = new DataTargetListString();
        target.Create("a");

        Assert.Throws<KeyNotFoundException>(() =>
        {
            target.Get("X");
        });
    }

    [Theory]
    [InlineData("a")]
    [InlineData("A")]
    public void Should_get_an_item(string value)
    {
        var target = new DataTargetListString();
        target.Create("a");

        Assert.Equal("a", target.Get(value));
    }

    [Fact]
    public void Should_update_item()
    {
        var target = new DataTargetListString();
        target.Create("a");

        target.Update("A");

        Assert.Contains("A", target.Target);
    }

    [Fact]
    public void Should_throw_if_can_not_update_item()
    {
        var target = new DataTargetListString();

        Assert.Throws<KeyNotFoundException>(() => target.Update("A"));
    }
}
