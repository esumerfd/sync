namespace SyncFramework;

public class DataConverterTest
{
    [Fact]
    public void Should_generate_int_string_converter()
    {
        DataConverter.Register<int, string>(new DataConverterIntString());
        var converter = DataConverter.Factory<int, string>();

        Assert.IsAssignableFrom<IDataConverter<int, string>>(converter);
        Assert.IsType<DataConverterIntString>(converter);

        Assert.Equal("1", converter.Convert(1));
    }

    [Fact]
    public void Should_fail_if_converter_does_exist()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            DataConverter.Factory<Type, Type>();
        });
    }
}
