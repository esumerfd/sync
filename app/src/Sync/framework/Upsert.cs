namespace SyncFramework;

public class Upsert<TY>
{
    IDataExists<TY> _existence;
    IDataChanged<TY> _changed;

    public Upsert(IDataExists<TY> existence, IDataChanged<TY> changed)
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