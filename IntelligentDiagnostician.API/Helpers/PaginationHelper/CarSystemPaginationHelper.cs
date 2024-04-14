using IntelligentDiagnostician.BL.DTOs.CarSystemsDTOs;
using IntelligentDiagnostician.BL.ResourceParameters;
using Microsoft.AspNetCore.Mvc;

namespace IntelligentDiagnostician.API.Helpers.PaginationHelper;

public class CarSystemPaginationHelper : ICarSystemPaginationHelper
{
    public void CreateMetaDataHeader(PagedList<CarSystemDto> systems,
        CarSystemsResourceParameters resourceParameters,
        IHeaderDictionary responseHeaders,
        IUrlHelper urlHelper)
    {
        string routeName = "GetAllSystems";
        var previousPageLink = systems.HasPrevious ?
            CreateCarSystemResourceUri(resourceParameters, routeName, ResourceUriType.PreviousPage, urlHelper) : null;

        var nextPageLink = systems.HasNext ?
            CreateCarSystemResourceUri(resourceParameters, routeName, ResourceUriType.NextPage, urlHelper) : null;

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

    public string? CreateCarSystemResourceUri(
        CarSystemsResourceParameters resourceParameters,
        string routeName,
        ResourceUriType type,
        IUrlHelper urlHelper)
    {
        switch (type)
        {
            case ResourceUriType.PreviousPage:
                return urlHelper?.Link(routeName,
                    new
                    {
                        pageNumber = resourceParameters.PageNumber - 1,
                        pageSize = resourceParameters.PageSize,
                        carSystemName = resourceParameters.CarSystemName,
                        searchQuery = resourceParameters.SearchQuery,
                    });
            case ResourceUriType.NextPage:
                return urlHelper?.Link(routeName,
                    new
                    {
                        pageNumber = resourceParameters.PageNumber + 1,
                        pageSize = resourceParameters.PageSize,
                        carSystemName = resourceParameters.CarSystemName,
                        // searchQuery = resourceParameters.SearchQuery
                    });
            default:
                return urlHelper?.Link(routeName,
                    new
                    {
                        pageNumber = resourceParameters.PageNumber,
                        pageSize = resourceParameters.PageSize,
                        carSystemName = resourceParameters.CarSystemName,
                        searchQuery = resourceParameters.SearchQuery
                    });
        }
    }
}