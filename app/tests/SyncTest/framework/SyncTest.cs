namespace SyncFramework;

public class SyncTest
{
    public class OneWaySingleLevel
    {
        [Fact]
        public void Should_sync_a_string()
        {
            var converter = DataConverter.Factory<string, string>();

            var syncSource = new DataSourceList<string>
            {
                Source = new List<string> { "A", "B" },
            };
            var syncTarget = new DataTargetList<string>();

            Sync<string, string>.OneWay(syncSource, syncTarget, converter);

            Assert.Equal(new List<string> { "A", "B" }, syncTarget.Target);
        }

        [Fact]
        public void Should_sync_a_int()
        {
            var converter = DataConverter.Factory<int, int>();

            var syncSource = new DataSourceList<int>
            {
                Source = new List<int> { 1, 2 },
            };
            var syncTarget = new DataTargetList<int>();

            Sync<int, int>.OneWay(syncSource, syncTarget, converter);

            Assert.Equal(new List<int> { 1, 2 }, syncTarget.Target);
        }
    }

    public class OneWayMetaData
    {
        [Fact]
        public void Should_acccept_meta_data_about_sync()
        {
            var syncSource = new DataSourceList<int> { Source = new List<int> { 1, 2 } };
            var syncTarget = new DataTargetList<string>();

            var metaData = new MetaData<int, string>
            {
                Traverser = new TraverseList<int, string>(),
                Root = new MetaDataNode<int, string>
                {
                    Converter = DataConverter.Factory<int, string>(),
                    Source = syncSource,
                    Target = syncTarget,
                }
            };

            var sync = new Sync<int, string>(metaData);
            sync.OneWay();

            Assert.Equal(new List<string> { "1", "2" }, syncTarget.Target);
        }

        [Fact]
        public void Should_not_sync_if_target_already_exists_for_insert_flow()
        {
            var syncSource = new DataSourceList<int> { Source = new List<int> { 1, 2 } };
            var syncTarget = new DataTargetList<string> { Target = new List<string> { "1" }};

            var metaData = new MetaData<int, string>
            {
                Traverser = new TraverseList<int, string>(),
                Root = new MetaDataNode<int, string>
                {
                    Converter = DataConverter.Factory<int, string>(),
                    Source = syncSource,
                    Target = syncTarget,
                    Existence = new DataStateString(syncTarget.Target),
                    Changed = new DataStateString(syncTarget.Target),
                }
            };

            var sync = new Sync<int, string>(metaData);
            sync.OneWay();

            Assert.Equal(new List<string> { "1", "2" }, syncTarget.Target);
        }

        [Fact]
        public void Should_sync_if_exists_but_has_changed_for_update_flow()
        {
            var syncSource = new DataSourceList<string> { Source = new List<string> { "a", "B" } };
            var syncTarget = new DataTargetListString { Target = new List<string> { "A", "B" }};

            var metaData = new MetaData<string, string>
            {
                Traverser = new TraverseList<string, string>(),
                Root = new MetaDataNode<string, string>
                {
                    Converter = DataConverter.Factory<string, string>(),
                    Source = syncSource,
                    Target = syncTarget,
                    Existence = new DataStateString(syncTarget.Target),
                    Changed = new DataStateString(syncTarget.Target),
                }
            };

            var sync = new Sync<string, string>(metaData);
            sync.OneWay();

            Assert.Equal(new List<string> { "a", "B" }, syncTarget.Target);
        } 

        [Fact]
        public void Should_throw_if_get_fails_to_find_item_in_target()
        {
            var syncSource = new DataSourceList<string> { Source = new List<string> { "a", "B" } };
            var syncTarget = new DataTargetList<string> { Target = new List<string> { "A", "B" }};

            var metaData = new MetaData<string, string>
            {
                Traverser = new TraverseList<string, string>(),
                Root = new MetaDataNode<string, string>
                {
                    Converter = DataConverter.Factory<string, string>(),
                    Source = syncSource,
                    Target = syncTarget,
                    Existence = new DataStateString(syncTarget.Target),
                    Changed = new DataStateString(syncTarget.Target),
                }
            };

            var sync = new Sync<string, string>(metaData);

            Assert.Throws<KeyNotFoundException>(() =>
            {
                sync.OneWay();
            });
        } 
    }

    public class OneWayIndexed
    {
        [Fact]
        public void Should_use_an_index_to_get_target_data()
        {
            var syncSource = new List<SourceUser>
            {
                new SourceUser { Id = 1, Name = "Bernie" },
                new SourceUser { Id = 2, Name = "Rosy" },
            };

            var syncTarget = new List<TargetUser>
            {
                new TargetUser { Id = "one", Name = "Charlie" },
                new TargetUser { Id = "two", Name = "Rosy" },
            };

            var metaData = new MetaData<SourceUser, TargetUser>
            {
                Traverser = new TraverseList<SourceUser, TargetUser>(),
                Root = new MetaDataNode<SourceUser, TargetUser>
                {
                    Converter = DataConverter.Factory<SourceUser, TargetUser>(),
                    Source = new DataSourceList<SourceUser>(syncSource),
                    Target = new DataTargetList<TargetUser>(syncTarget),
                }
            };

            var sync = new Sync<SourceUser, TargetUser>(metaData);
            sync.OneWay();

            Assert.Equal("Charlie", syncTarget[0].Name);
        }
    }

    public class OneWayRecursive
    {
        [Fact(Skip = "dont know how to mange two types yet")]
        public void Should_sync_two_layers_with_same_type()
        {
            var syncSourceString =  new List<string> { "a", "b" };
            var syncTargetString =  new List<string>();

            var syncSourceInt =  new List<int> { 1, 2 };
            var syncTargetInt =  new List<int>();

            var metaData = new MetaData<string, string>
            {
                Traverser = new TraverseList<string, string>(),
                Root = new MetaDataNode<string, string>
                {
                    Converter = DataConverter.Factory<string, string>(),
                    Source = new DataSourceList<string>(syncSourceString),
                    Target = new DataTargetList<string>(syncTargetString),
                    Existence = new DataStateString(syncTargetString),
                    Changed = new DataStateString(syncTargetString),
                }
            };

            var sync = new Sync<string, string>(metaData);
            sync.OneWay();

            Assert.Equal(new List<string> { "a", "b" }, syncTargetString);
            Assert.Equal(new List<int> { 1, 2 }, syncTargetInt);
        } 
    }
}
