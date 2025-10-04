namespace DotnetAnalyzyHabr.BL;

public class UserService
{
    //[Obsolete("Use X instead of this method")]
    public string? GetName()
    {
        List<User> users = [];
        User? item = users.FirstOrDefault(x => x.Name == "Vasia");
        return item.Name;
    }

    //[Obsolete]
    public string? M1()
    {
        return GetName();
    }

    public static async Task GetAsync()
    {
        await Task.Run(() => { });
    }
}

public class User
{
    public required string Name { get; set; }
}
