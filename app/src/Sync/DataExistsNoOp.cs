namespace SyncFramework;

public class DataExistsNoOp<TY> : IDataExists<TY>
{
    public bool Exists(TY item)
    {
        return false;
    }
}
