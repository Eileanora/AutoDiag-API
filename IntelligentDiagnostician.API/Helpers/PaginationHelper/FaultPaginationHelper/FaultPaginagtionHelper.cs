using FluentValidation;
using IntelligentDiagnostician.BL.DTOs.FaultDTOs;
using IntelligentDiagnostician.BL.ResourceParameters;
using Microsoft.AspNetCore.Mvc;

namespace IntelligentDiagnostician.API.Helpers.PaginationHelper.FaultPaginationHelper;

public class FaultPaginagtionHelper : IFaultPaginationHelper
{
       public void CreateMetaDataHeader(PagedList<FaultDto> systems,
           FaultsResourceParameters resourceParameters,
        IHeaderDictionary responseHeaders,
        IUrlHelper urlHelper)
    {
        string routeName = "GetAllSystems";
        var previousPageLink = systems.HasPrevious ?
            CreateErrorResourceUri(resourceParameters, routeName, ResourceUriType.PreviousPage, urlHelper) : null;

        var nextPageLink = systems.HasNext ?
            CreateErrorResourceUri(resourceParameters, routeName, ResourceUriType.NextPage, urlHelper) : null;

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

    public string? CreateErrorResourceUri(
        FaultsResourceParameters resourceParameters,
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
                        severity = resourceParameters.Severity,
                        problemCode = resourceParameters.ProblemCode,
                        orderBy
                    });
            case ResourceUriType.NextPage:
                return urlHelper?.Link(routeName,
                    new
                    {
                        pageNumber = resourceParameters.PageNumber + 1,
                        pageSize = resourceParameters.PageSize,
                        severity = resourceParameters.Severity,
                        problemCode = resourceParameters.ProblemCode,
                        orderBy
                    });
            default:
                return urlHelper?.Link(routeName,
                    new
                    {
                        pageNumber = resourceParameters.PageNumber,
                        pageSize = resourceParameters.PageSize,
                        severity = resourceParameters.Severity,
                        problemCode = resourceParameters.ProblemCode,
                        orderBy
                    });
        }
    } 
}
