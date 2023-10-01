namespace SyncFramework;

public class DataConverterTest
{
    [Fact]
    public void Should_generate_string_converter()
    {
        var converter = DataConverter.Factory<string, string>();

        Assert.IsAssignableFrom<IDataConverter<string, string>>(converter);
        Assert.IsType<DataConverterString>(converter);
    }

    [Fact]
    public void Should_generate_int_converter()
    {
        var converter = DataConverter.Factory<int, int>();

        Assert.IsAssignableFrom<IDataConverter<int, int>>(converter);
        Assert.IsType<DataConverterInt>(converter);
    }

    [Fact]
    public void Should_generate_int_string_converter()
    {
        var converter = DataConverter.Factory<int, string>();

        Assert.IsAssignableFrom<IDataConverter<int, string>>(converter);
        Assert.IsType<DataConverterIntString>(converter);

        Assert.Equal("1", converter.Convert(1));
    }

    [Fact]
    public void Should_generate_string_int_converter()
    {
        var converter = DataConverter.Factory<string, int>();

        Assert.IsAssignableFrom<IDataConverter<string, int>>(converter);
        Assert.IsType<DataConverterStringInt>(converter);

        Assert.Equal(1, converter.Convert("1"));
    }
}
