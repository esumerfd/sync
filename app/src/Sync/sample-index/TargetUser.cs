namespace SyncFramework;

public class TargetUser
{
    public string Id = "";
    public string Name = "";

    public override string ToString()
    {
        return $"TargetUser: {Id}, {Name}";
    }
}
