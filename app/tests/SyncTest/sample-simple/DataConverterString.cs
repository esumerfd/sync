namespace SyncFramework;

public class DataConverterString : IDataConverter<string, string>
{
    public string Convert(string value)
    {
        return value;
    }
}
