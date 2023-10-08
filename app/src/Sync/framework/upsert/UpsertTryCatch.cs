namespace SyncFramework;

public class UpsertTryCatch<TY> : ISyncUpsert<TY>
{
    IDataExists<TY> _existence;
    IDataChanged<TY> _changed;

    public UpsertTryCatch()
    {
        _existence = new DataExistsNoOp<TY>();
        _changed = new DataChangedNoOp<TY>();
    }

    public UpsertTryCatch(IDataExists<TY> existence, IDataChanged<TY> changed)
    {
        _existence = existence;
        _changed = changed;
    }

    public void Sync(TY value, IDataTarget<TY> target, Action<TY> create, Action<TY> update)
    {
        try
        {
            if (!_existence.Exists(value))
            {
                create(value);
            }
        }
        catch (UpsertValueExistsException)
        {
            var originalValue = target.Get(value);
            if (_changed.Changed(originalValue, value))
            {
                update(value);
            }
        }
    }
}
