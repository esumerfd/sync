namespace SyncFramework;

public class TargetUserExists : IDataExists<TargetUser>
{
    List<TargetUser> _targetUsers;

    public TargetUserExists(List<TargetUser> targetUsers)
    {
        _targetUsers = targetUsers;
    }

    public bool Exists(TargetUser targetUser)
    {
        return _targetUsers.Exists(user => user.Id.ToString() == targetUser.Id);
    }
}
