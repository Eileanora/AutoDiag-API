using IntelligentDiagnostician.BL.DTOs.SensorDTOs;
using IntelligentDiagnostician.BL.ResourceParameters;
using Microsoft.AspNetCore.Mvc;

namespace IntelligentDiagnostician.API.Helpers.PaginationHelper;

public class SensorPaginationHelper : ISensorPaginationHelper
{
    public void CreateMetaDataHeader(PagedList<SensorDto> sensors,
        SensorsResourceParameters resourceParameters,
        IHeaderDictionary responseHeaders,
        IUrlHelper urlHelper)
    {
        string routeName = "GetAllSensors";
        var previousPageLink = sensors.HasPrevious ?
            CreateSensorResourceUri(resourceParameters, routeName, ResourceUriType.PreviousPage, urlHelper) : null;

        var nextPageLink = sensors.HasNext ?
            CreateSensorResourceUri(resourceParameters, routeName, ResourceUriType.NextPage, urlHelper) : null;

        var paginationMetadata = new
        {
            totalCount = sensors.TotalCount,
            pageSize = sensors.PageSize,
            currentPage = sensors.CurrentPage,
            totalPages = sensors.TotalPages,
            previousPageLink,
            nextPageLink
        };
        responseHeaders.Append("X-Pagination",
            JsonHelper.SerializeWithCustomOptions(paginationMetadata));
    }

    public string? CreateSensorResourceUri(
        SensorsResourceParameters resourceParameters,
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
                        sensorName = resourceParameters.SensorName,
                        searchQuery = resourceParameters.SearchQuery,
                    });
            case ResourceUriType.NextPage:
                return urlHelper?.Link(routeName,
                    new
                    {
                        pageNumber = resourceParameters.PageNumber + 1,
                        pageSize = resourceParameters.PageSize,
                        sensorName = resourceParameters.SensorName,
                        // searchQuery = resourceParameters.SearchQuery
                    });
            default:
                return urlHelper?.Link(routeName,
                    new
                    {
                        pageNumber = resourceParameters.PageNumber,
                        pageSize = resourceParameters.PageSize,
                        sensorName = resourceParameters.SensorName,
                        searchQuery = resourceParameters.SearchQuery
                    });
        }
    }
}
