namespace SyncFramework;

public class DataConverterIntString : IDataConverter<int, string>
{
    public string Convert(int value)
    {
        return value.ToString();
    }
}
