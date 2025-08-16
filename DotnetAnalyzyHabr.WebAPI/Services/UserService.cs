namespace DotnetAnalyzyHabr.WebAPI.Services;

public class UserService
{
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
}

public class User
{
    public required string Name { get; set; }
}
