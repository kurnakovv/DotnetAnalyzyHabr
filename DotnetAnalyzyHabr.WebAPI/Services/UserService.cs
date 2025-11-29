namespace DotnetAnalyzyHabr.WebAPI.Services;

public enum Foo
{
    A = 0,
    B = 1,
    C = 2,
}

public enum Employee
{
    None = 0,
    Developer = 1,
    Manager = 2,
    // CA1069: The enum member 'Tester' has the same constant value '2' as member 'Manager'
    // Tester = 2,
}

public interface IUserService
{
    Task<string> GetNameAsync();
}

public interface IUser;

public class UserService
{
    public required int Age { get; set; }

    public string? GetName()
    {
        // var c = new User() { Name = "Vasia" };
        User c = new()
        {
            Name = "Test",
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

    public void M(int i, int j)
    {
        if (i != 0)
        {
            return;
        }

        if (j != 0)
        {
            return;
        }

        // Куча логики...

        // if (i != j)
        // {
        //     // Логика записи годового отчёта в БД...
        // }

        // Куча логики...
    }

    // public async Task DeleteAsync(long id, CancellationToken ct)
    // {
    //     await _userApi.DeleteAsync(id);
    //     await _db.Users.Where(u => u.Id == id).ExecuteDeleteAsync();
    // }

    public void M2(int a)
    {
        if (a == 1)
        {
            throw new ArgumentException();
        }

        if (a == 2)
        {
            throw new ArgumentException();
        }

        // if (a == 3)
        // {
        //     throw new ArgumentException();
        // }

        if (a != 3)
        {
            return;
        }

        throw new ArgumentException();
    }
}

public class User
{
    public string? Name { get; set; }
}
