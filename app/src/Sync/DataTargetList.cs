namespace SyncFramework;

public class DataTargetList<TY> : IDataTarget<TY>
{
    public List<TY> Target { get; set; } = new List<TY>();

    public void Write(TY item)
    {
        Target.Add(item);
    }
}
