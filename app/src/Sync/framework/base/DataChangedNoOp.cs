namespace SyncFramework;

public class DataChangedNoOp<TY> : IDataChanged<TY>
{
    public bool Changed(TY sourceValue, TY targetValue)
    {
        return true;
    }
}
