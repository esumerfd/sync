namespace SyncFramework;

public class SourceUser
{
    public int Id = 0;
    public string Name = "";

    public override string ToString()
    {
        return $"SourceUser: {Id}, {Name}";
    }
}

