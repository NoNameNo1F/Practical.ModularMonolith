namespace AdsManagementAPI.BuildingBlocks.Domain.BusinessRules;

public interface IBusinessRule
{
    bool IsBroken();
    
    string Message { get; }
}