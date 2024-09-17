using AdsManagementAPI.BuildingBlocks.Domain;

namespace AdsManagementAPI.Modules.Auth.Domain.Entities;

public class Officer : Entity
{
    public Guid OfficerId { get; set; }
    public string? FullName { get; set; }
    public DateTime DoB { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? PasswordHash { get; set; }
    public int WardId { get; set; }
}