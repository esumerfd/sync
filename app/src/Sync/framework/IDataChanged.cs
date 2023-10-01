namespace SyncFramework;

public interface IDataChanged<TY>
{
    public bool Changed(TY odds, TY ends);
}
