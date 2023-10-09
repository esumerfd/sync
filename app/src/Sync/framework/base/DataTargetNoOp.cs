namespace SyncFramework;

public class DataTargetNoOp<TY> : IDataTarget<TY>
{
    public TY Get(TY value)
    {
        return value;
    }

    public void Create(TY value)
    {
    }

    public void Update(TY value)
    {
    }
}
