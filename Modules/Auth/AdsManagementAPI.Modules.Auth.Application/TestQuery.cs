using AdsManagementAPI.Modules.Auth.Application.Contracts;

namespace AdsManagementAPI.Modules.Auth.Application;

public class TestQuery : QueryBase<string>
{
    public string Name { get; }

    public TestQuery(string name)
    {
        Name = name;
    }
}