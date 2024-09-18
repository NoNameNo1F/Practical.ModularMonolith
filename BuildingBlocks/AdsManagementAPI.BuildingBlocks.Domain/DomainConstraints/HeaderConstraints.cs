namespace AdsManagementAPI.BuildingBlocks.Domain.DomainConstraints;

public class HeaderConstraints
{
    public const string XPagination = "X-Pagination";
   
    public static readonly string[] AllowedExtensions = { "jpg", "jpeg", "png", "pdf", "txt" };
    public static readonly string[] AllowedContentTypes = { "image/jpeg", "image/png", "application/pdf", "text/plain" };
    public static readonly string[] AllowedExtensionsForCsvImport = { "csv" };
    public static readonly string[] AllowedContentTypesForCsvImport = { "text/csv" };
    public const string TokenType = "type";
}