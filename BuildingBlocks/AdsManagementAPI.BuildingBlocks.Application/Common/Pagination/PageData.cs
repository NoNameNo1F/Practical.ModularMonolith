namespace AdsManagementAPI.BuildingBlocks.Application.Common.Pagination;

public class PageData
{
    public int PageNumber { get; set; }
    
    public int PageSize { get; set; }
    
    public int TotalPages { get; set; }
    
    public int TotalCount { get; set; }

    public bool HasPrevious => PageNumber > 0;

    public bool HasNext => PageNumber < TotalPages;

    public PageData(int count, int pageNumber, int pageSize)
    {
        TotalCount = count;
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
    }
}