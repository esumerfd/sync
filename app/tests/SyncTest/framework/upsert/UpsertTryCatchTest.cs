namespace SyncFramework;

public class UpsertTryCatchTest
{
    [Fact]
    public void Should_create()
    {
        var target = new DataTargetList<string>();

        var valueCreated = "";

        var upsert = new UpsertTryCatch<string>(new ValueExists(false), new ValueChanged(false));
        upsert.Sync("a", target, (createValue) => valueCreated = createValue, (updateValue) => {});

        Assert.Equal("a", valueCreated);
    }

    [Fact]
    public void Should_update_changed()
    {
        var target = new DataTargetList<string>(new List<string> { "a" });

        var valueUpdated = "";

        var upsert = new UpsertTryCatch<string>(new ValueExists(true), new ValueChanged(true));
        upsert.Sync("a", target, (createValue) => {}, (updateValue) => valueUpdated = updateValue);

        Assert.Equal("a", valueUpdated);
    }

    [Fact]
    public void Should_update_not_changed()
    {
        var target = new DataTargetList<string>(new List<string> { "a" });

        var valueUpdated = "";

        var upsert = new UpsertTryCatch<string>(new ValueExists(true), new ValueChanged(false));
        upsert.Sync("a", target, (createValue) => {}, (updateValue) => valueUpdated = updateValue);

        Assert.Equal("", valueUpdated);
    }

    class ValueExists : IDataExists<string>
    {
        bool _exists = false;

        public ValueExists(bool exists)
        {
            _exists = exists;
        }

        public bool Exists(string value)
        {
            if (_exists) throw new UpsertValueExistsException();
            return false;
        }
    }

    class ValueChanged : IDataChanged<string>
    {
        bool _hasChanged = false;

        public ValueChanged(bool hasChanged)
        {
            _hasChanged = hasChanged;
        }

        public bool Changed(string odds, string ends)
        {
            return _hasChanged;
        }
    }
}

