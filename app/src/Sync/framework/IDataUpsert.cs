namespace SyncFramework;

public interface ISyncUpsert<TY>
{
    void Sync(TY convertedItem, IDataTarget<TY> target, Action create, Action changed);
}
