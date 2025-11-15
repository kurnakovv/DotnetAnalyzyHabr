namespace DotnetAnalyzyHabr.WebAPI.Services;

public class UserService
{
    public required int Age { get; set; }

    public string? GetName()
    {
        //var c = new User() { Name = "Vasia" };
        User c = new()
        {
            Name = "Test"
        };

        List<User> users = [];
        User? item = users.FirstOrDefault(x => x.Name == "Vasia");

        item ??= c;

        ReadOnlySpan<int> x = [1, 2, 3];

        return item.Name;
    }

    public string? M1()
    {
        return GetName();
    }
}

public interface IUserService
{
    Task<string> GetNameAsync();
}

public class User
{
    public string? Name { get; set; }
}

public interface IUser;

public enum Foo
{
    A = 0,
    B = 1,
    C = 2
}
