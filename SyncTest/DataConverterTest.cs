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
}
