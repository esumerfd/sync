namespace SyncFramework;

public class UserConverter : IDataConverter<SourceUser, TargetUser>
{
    public TargetUser Convert(SourceUser value)
    {
        return new TargetUser
        {
            Id = $"{value.Id}",
            Name = value.Name,
        };
    }
}
