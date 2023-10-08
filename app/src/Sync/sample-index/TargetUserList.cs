namespace SyncFramework;

public class TargetUserList : IDataTarget<TargetUser>
{
    public List<TargetUser> UserList { get; set; } = new List<TargetUser>();

    public TargetUserList(List<TargetUser> list)
    {
        UserList = list;
    }

    public TargetUser Get(TargetUser targetUser)
    {
        var index = UserList.FindIndex(listUser => listUser?.Id.Equals(targetUser.Id) ?? false );
        if (index == -1) throw new KeyNotFoundException();
        return UserList[index];
    }

    public void Write(TargetUser targetUser)
    {
        UserList.Add(targetUser);
    }

    public void Update(TargetUser targetUser)
    {
        var index = UserList.FindIndex(listUser => listUser?.Id.Equals(targetUser.Id) ?? false );
        if (index > -1)
        {
            UserList[index] = targetUser;
        }
    }
}
