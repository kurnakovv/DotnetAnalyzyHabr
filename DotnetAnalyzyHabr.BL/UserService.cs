namespace DotnetAnalyzyHabr.BL;

public class UserService
{
    [Obsolete("Use X instead of this method")]
    public string? GetName()
    {
        List<User> users = [];
        User? item = users.FirstOrDefault(x => x.Name == "Vasia");
        return item?.Name;
    }

    public string? M1()
    {
        return GetName();
    }

    public async Task Get(long id)
    {
        await Task.Run(() => { });
    }
}

public class User
{
    public required string Name { get; set; }
}
