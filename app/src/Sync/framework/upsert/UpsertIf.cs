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

    public void Sync(TY value, IDataTarget<TY> target, Action<TY> create, Action<TY> update)
    {
        if (!_existence.Exists(value))
        {
            create(value);
        }
        else
        {
            var originalValue = target.Get(value);
            if (_changed.Changed(originalValue, value))
            {
                update(value);
            }
        }
    }
}
