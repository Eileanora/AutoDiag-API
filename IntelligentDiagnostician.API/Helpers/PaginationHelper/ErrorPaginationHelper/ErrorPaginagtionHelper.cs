using FluentValidation;
using IntelligentDiagnostician.BL.DTOs.ErrorDTOs;
using IntelligentDiagnostician.BL.ResourceParameters;
using Microsoft.AspNetCore.Mvc;

namespace IntelligentDiagnostician.API.Helpers.PaginationHelper.ErrorPaginationHelper;

public class ErrorPaginagtionHelper : IErrorPaginationHelper
{
       public void CreateMetaDataHeader(PagedList<ErrorDto> systems,
           ErrorsResourceParameters resourceParameters,
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
        ErrorsResourceParameters resourceParameters,
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
