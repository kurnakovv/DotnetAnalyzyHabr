namespace DotnetAnalyzyHabr.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        List<User> users = [];

        var item = users.FirstOrDefault(x => x.Name == "Vasia");

        //var a = item.Name;
    }
}

public class User
{
    public required string Name { get; set; }
}
