namespace SyncFramework;

public class MetaDataNode
{
    // Convert from a source item to a target item
    public (Type, Type) Converter { get; set; }

    // A sequence of source items
    public Type Source { get; set; }

    // A sequence of target items.
    public Type Target { get; set; }

    // Recurse to next layer of data structure to sync
    public MetaDataNode Node;
}
