namespace SyncFramework;

public class DataChangedNoOp<TY> : IDataChanged<TY>
{
    public bool Changed(TY odds, TY ends)
    {
        return true;
    }
}
