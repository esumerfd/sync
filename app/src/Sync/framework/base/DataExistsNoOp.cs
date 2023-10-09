namespace SyncFramework;

public class DataExistsNoOp<TY> : IDataExists<TY>
{
    public bool Exists(TY value)
    {
        return false;
    }
}
