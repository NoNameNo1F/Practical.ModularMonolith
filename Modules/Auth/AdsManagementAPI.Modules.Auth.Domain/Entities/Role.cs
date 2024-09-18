namespace AdsManagementAPI.Modules.Auth.Domain.Entities;

public class Role
{
    public Guid RoleId { get; set; }
    public string RoleName { get; set; }
    
    public Officer Officer { get; set; }
    public List<Privilege> Privileges { get; set; }
}