namespace SyncFramework;

public class DataStateStringTest
{
    [Theory]
    [InlineData(true, "a")]
    [InlineData(true, "A")]
    [InlineData(false, "b")]
    [InlineData(false, "B")]
    public void Should_exist(bool expectExists, string value)
    {
        var state = new DataStateString(new List<string> { "a" });

        Assert.Equal(expectExists, state.Exists(value));
    }

    [Fact]
    public void Should_change()
    {
        var state = new DataStateString(new List<string> { "a" });

        Assert.True(state.Changed("a", "b"));
        Assert.False(state.Changed("a", "a"));
    }
}
