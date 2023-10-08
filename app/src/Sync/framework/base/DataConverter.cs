namespace SyncFramework;

public interface IDataConverter<TX, TY>
{
    TY Convert(TX item);
}

public class DataConverter
{
    static Dictionary<object, object> _converters = new Dictionary<object, object>();

    public static void Register<TX, TY>(IDataConverter<TX, TY> converter)
    {
        _converters.Add((typeof(TX), typeof(TY)), converter);
    }

    public static IDataConverter<TX, TY> Factory<TX, TY>()
    {
        var found = _converters.TryGetValue((typeof(TX), typeof(TY)), out object? converter);
        if (!found || converter == null)
        {
            throw new ArgumentException($"No converter of type IDataConverter<{typeof(TX)}, {typeof(TY)}>");
        }

        return (IDataConverter<TX,TY>)converter;
    }
}

public class DataConverterNoOp<TX, TY> : IDataConverter<TX, TY>
{
    public TY Convert(TX value)
    {
        return (TY)System.Convert.ChangeType(value, typeof(TY))!;
    }
}
