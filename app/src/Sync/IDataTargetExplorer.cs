namespace SyncFramework;

public interface IDataTargetExplorer<TY>
{
    public bool Exists(TY item);
    public bool Changed(TY item);
}
