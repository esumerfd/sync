namespace SyncFramework;

public class DataTargetList<TY> : IDataTarget<TY>
{
    public List<TY> Target { get; set; } = new List<TY>();

    public DataTargetList()
    {
    }

    public DataTargetList(List<TY> list)
    {
        Target = list;
    }

    public TY Get(TY item)
    {
        var index = Target.FindIndex(listItem => listItem?.Equals(item) ?? false);
        if (index == -1) throw new KeyNotFoundException();
        return Target[index];
    }

    public void Write(TY item)
    {
        Target.Add(item);
    }

    public void Update(TY item)
    {
        var index = Target.FindIndex(listItem => listItem?.Equals(item) ?? false);
        if (index > -1)
        {
            Target[index] = item;
        }
    }
}
