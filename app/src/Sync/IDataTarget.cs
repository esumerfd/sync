namespace SyncFramework;

/**
 * IDataTarget
 *
 * Encapsulates the mappings from a source to a target. It is not contain
 * any mappings but depegates to the processes that Sync relies on.
 */
public interface IDataTarget<TY>
{
    public TY Get(TY item);
    public void Write(TY item);
    public void Update(TY item);
}

