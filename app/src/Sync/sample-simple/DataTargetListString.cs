namespace SyncFramework;

public class DataTargetListString : IDataTarget<string>
{
    public List<string> Target { get; set; } = new List<string>();

    public string Get(string item)
    {
        var index = Target.FindIndex(listItem => 
                String.Equals(listItem, item, StringComparison.OrdinalIgnoreCase));
        if (index == -1) throw new KeyNotFoundException();
        return Target[index];
    }

    public void Write(string item)
    {
        Target.Add(item);
    }

    public void Update(string item)
    {
        var index = Target.FindIndex(listItem => 
                String.Equals(listItem, item, StringComparison.OrdinalIgnoreCase));
        if (index == -1) throw new KeyNotFoundException();
        Target[index] = item;
    }
}
