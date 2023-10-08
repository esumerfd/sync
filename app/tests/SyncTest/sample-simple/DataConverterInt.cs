namespace SyncFramework;

public class DataConverterInt : IDataConverter<int, int>
{
    public int Convert(int value)
    {
        return value;
    }
}
