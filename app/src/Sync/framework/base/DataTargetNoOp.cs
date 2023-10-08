namespace SyncFramework;

public class DataTargetNoOp<TY> : IDataTarget<TY>
{
    public TY Get(TY item)
    {
        return item;
    }

    public void Write(TY item)
    {
    }

    public void Update(TY item)
    {
    }
}
