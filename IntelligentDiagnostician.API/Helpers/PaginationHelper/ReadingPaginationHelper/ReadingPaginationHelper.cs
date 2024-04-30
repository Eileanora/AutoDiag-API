using System.Text.Json;
using IntelligentDiagnostician.BL.DTOs.ReadingDTOs;
using IntelligentDiagnostician.BL.ResourceParameters;
using Microsoft.AspNetCore.Mvc;

namespace IntelligentDiagnostician.API.Helpers.PaginationHelper.ReadingPaginationHelper;

public class ReadingPaginationHelper : IReadingPaginationHelper
{
    public void CreateMetaDataHeader(
        PagedList<ReadingDto> systems,
        ReadingResourceParameters resourceParameters,
        IHeaderDictionary responseHeaders,
        IUrlHelper urlHelper)
    {
        string routeName = "GetAllReadings";
        var previousPageLink = systems.HasPrevious ?
            CreateReadingResourceUri(resourceParameters, routeName, ResourceUriType.PreviousPage, urlHelper) : null;
        
        var nextPageLink = systems.HasNext ?
            CreateReadingResourceUri(resourceParameters, routeName, ResourceUriType.NextPage, urlHelper) : null;
        
        var paginationMetadata = new
        {
            totalCount = systems.TotalCount,
            pageSize = systems.PageSize,
            currentPage = systems.CurrentPage,
            totalPages = systems.TotalPages,
            previousPageLink,
            nextPageLink
        };
        
        responseHeaders.Append("X-Pagination",
            JsonHelper.SerializeWithCustomOptions(paginationMetadata));
    }

    public string? CreateReadingResourceUri(
        ReadingResourceParameters resourceParameters,
        string routeName,
        ResourceUriType type,
        IUrlHelper urlHelper)
    {
        var orderBy = resourceParameters.OrderBy == "CreatedDate desc" ? null : resourceParameters.OrderBy;
        switch (type)
        {
            case ResourceUriType.PreviousPage:
                return urlHelper?.Link(routeName,
                    new
                    {
                        pageNumber = resourceParameters.PageNumber - 1,
                        pageSize = resourceParameters.PageSize,
                        orderBy
                    });
            case ResourceUriType.NextPage:
                return urlHelper?.Link(routeName,
                    new
                    {
                        pageNumber = resourceParameters.PageNumber + 1,
                        pageSize = resourceParameters.PageSize,
                        orderBy
                    });
            default:
                return urlHelper?.Link(routeName,
                    new
                    {
                        pageNumber = resourceParameters.PageNumber,
                        pageSize = resourceParameters.PageSize,
                        orderBy
                    });
        }
    }
}
