namespace SyncFramework;

public interface IMetaDataNode
{
    (Type, Type) Converter { get; set; }
    Type Source { get; set; }
    Type Target { get; set; }
}

public class MetaDataNode : IMetaDataNode
{
    (Type, Type) IMetaDataNode.Converter { get; set; }
    Type IMetaDataNode.Source { get; set; }
    Type IMetaDataNode.Target { get; set; }
}
