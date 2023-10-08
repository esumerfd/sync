namespace SyncFramework;

public interface ISyncUpsert<TY>
{
    void Sync(TY convertedItem, IDataTarget<TY> target, Action<TY> create, Action<TY> update);
}
