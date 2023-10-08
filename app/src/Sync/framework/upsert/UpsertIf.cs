namespace SyncFramework;

public class UpsertIf<TY> : ISyncUpsert<TY>
{
    IDataExists<TY> _existence;
    IDataChanged<TY> _changed;

    public UpsertIf(IDataExists<TY> existence, IDataChanged<TY> changed)
    {
        _existence = existence;
        _changed = changed;
    }

    public void Sync(TY convertedItem, IDataTarget<TY> target, Action<TY> create, Action<TY> update)
    {
        if (!_existence.Exists(convertedItem))
        {
            create(convertedItem);
        }
        else
        {
            var originalItem = target.Get(convertedItem);
            if (_changed.Changed(originalItem, convertedItem))
            {
                update(convertedItem);
            }
        }
    }
}
