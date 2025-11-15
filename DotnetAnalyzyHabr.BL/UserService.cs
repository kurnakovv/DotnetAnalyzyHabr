namespace DotnetAnalyzyHabr.BL;

public class UserService
{
    //[Obsolete("Use X instead of this method")]
    public string? GetName()
    {
        List<User> users = [];
        User? item = users.FirstOrDefault(x => x.Name == "Vasia");
        //return item.Name;
        return item?.Name;
    }

    //[Obsolete]
    public string? M1(
    //bool a, bool b
    )
    {
        //using MemoryStream stream = new();
        //stream.CopyTo(stream);
        //for (int i = 0; i >= 10; i++)
        //{
        //    for (int j = 0; j >= i; i++)
        //    {

        //    }
        //}
        //if (a = !b)
        //{

        //}
        //new List<int>() { 1, 2, 3 }.Where(x => new List<int>().Any(x => x == 1)).ToList();
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
