namespace SyncFramework;

public interface IDataExists<TY>
{
    public bool Exists(TY item);
}
