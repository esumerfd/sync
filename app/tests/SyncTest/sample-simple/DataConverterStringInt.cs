namespace SyncFramework;

public class DataConverterStringInt : IDataConverter<string, int>
{
    public int Convert(string value)
    {
        return int.Parse(value);
    }
}
