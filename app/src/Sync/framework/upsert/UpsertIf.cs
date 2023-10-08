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

    public void Sync(TY convertedItem, IDataTarget<TY> target, Action create, Action changed)
    {
        if (!_existence.Exists(convertedItem))
        {
            create();
        }
        else
        {
            var originalItem = target.Get(convertedItem);
            if (_changed.Changed(originalItem, convertedItem))
            {
                changed();
            }
        }
    }
}
