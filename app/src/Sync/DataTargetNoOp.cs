namespace SyncFramework;

public class DataTargetNoOp<TY> : IDataTarget<TY>
{
    public void Write(TY item)
    {
    }
}
