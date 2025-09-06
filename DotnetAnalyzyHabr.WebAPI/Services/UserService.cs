namespace DotnetAnalyzyHabr.WebAPI.Services;

public class UserService
{
    public string? GetName()
    {
        List<User> users = [];
        var item = users.FirstOrDefault(x => x.Name == "Vasia");
        int a = default;
        return item?.Name;
    }

    public string? M1()
    {
        return GetName();
    }

    public async Task GetAsync(long id)
    {
        await Task.Run(() => { });
    }
}

public class User
{
    public required string Name { get; set; }
}

public interface IUser
{

}
