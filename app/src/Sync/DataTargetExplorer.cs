namespace SyncFramework;

public class DataTargetExplorerString : IDataTargetExplorer<string>
{
    public bool Exists(string item)
    {
        return true; // Target.Contains(item);
    }

    public bool Changed(string item)
    {
        return true;
    }
}
