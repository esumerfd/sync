namespace SyncFramework;

public interface IDataConverter<TX, TY>
{
    TY Convert(TX item);
}

public class DataConverter
{
    public static IDataConverter<TX, TY> Factory<TX, TY>()
    {
        return (IDataConverter<TX, TY>)new DataConverterString();
    }
}

public class DataConverterString : IDataConverter<string, string>
{
    public string Convert(string value)
    {
        return value;
    }
}
