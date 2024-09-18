namespace AdsManagementAPI.Modules.Auth.Domain.Entities;

public class Privilege
{
    public Guid PrivilegeId { get; set; }
    public string PrivilegeName { get; set; }
    
    public List<Role> Roles { get; set; }
    public List<Officer> Officers { get; set; }
}