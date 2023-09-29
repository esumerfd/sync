namespace SyncFramework;

public interface IDataConverter<TX, TY>
{
    TY Convert(TX item);
}

public class DataConverter
{
    static Dictionary<object, object> _converters = new Dictionary<object, object>
    {
        [(typeof(string), typeof(string))] = new DataConverterString(),
        [(typeof(int), typeof(int))]       = new DataConverterInt(),
        [(typeof(int), typeof(string))]    = new DataConverterIntString(),
        [(typeof(string), typeof(int))]    = new DataConverterStringInt(),
    };

    public static IDataConverter<TX, TY> Factory<TX, TY>()
    {
        return (IDataConverter<TX, TY>)_converters[(typeof(TX), typeof(TY))];
    }
}

public class DataConverterString : IDataConverter<string, string>
{
    public string Convert(string value)
    {
        return value;
    }
}

public class DataConverterInt : IDataConverter<int, int>
{
    public int Convert(int value)
    {
        return value;
    }
}

public class DataConverterIntString : IDataConverter<int, string>
{
    public string Convert(int value)
    {
        return value.ToString();
    }
}

public class DataConverterStringInt : IDataConverter<string, int>
{
    public int Convert(string value)
    {
        return int.Parse(value);
    }
}
