namespace SyncFramework;

public interface IDataTarget<T>
{
    void Convert(T item);
}

