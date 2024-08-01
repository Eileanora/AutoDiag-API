using AutoDiag.API.Helpers.JsonHelpers;
using AutoDiag.BL.ResourceParameters;
using Microsoft.AspNetCore.Mvc;

namespace AutoDiag.API.Helpers.PaginationHelper;

public class PaginationHelper<TDto, TResourceParameters> : IPaginationHelper<TDto, TResourceParameters>
    where TDto : class
    where TResourceParameters : BaseResourceParameters
{
    public void CreateMetaDataHeader(PagedList<TDto> items,
        TResourceParameters resourceParameters,
        IHeaderDictionary responseHeaders,
        IUrlHelper urlHelper,
        string routeName)
    {
        var previousPageLink = items.HasPrevious ?
            CreateResourceUri(resourceParameters, routeName, ResourceUriType.PreviousPage, urlHelper) : null;

        var nextPageLink = items.HasNext ?
            CreateResourceUri(resourceParameters, routeName, ResourceUriType.NextPage, urlHelper) : null;

        var paginationMetadata = new
        {
            totalCount = items.TotalCount,
            pageSize = items.PageSize,
            currentPage = items.CurrentPage,
            totalPages = items.TotalPages,
            previousPageLink,
            nextPageLink
        };
        responseHeaders.Append("X-Pagination",
            JsonHelper.SerializeWithCustomOptions(paginationMetadata));
    }


    public string? CreateResourceUri(
        TResourceParameters resourceParameters,
        string routeName,
        ResourceUriType type,
        IUrlHelper urlHelper)
    {
        var orderBy = resourceParameters.OrderBy;
        var pageNumber = resourceParameters.PageNumber;
        if (type == ResourceUriType.PreviousPage)
        {
            pageNumber--;
        }
        else if (type == ResourceUriType.NextPage)
        {
            pageNumber++;
        }

        var queryParameters = new Dictionary<string, object>
        {
            { "pageNumber", pageNumber },
            { "pageSize", resourceParameters.PageSize },
            // { "orderBy", orderBy }
        };

        foreach (var prop in typeof(TResourceParameters).GetProperties())
        {
            if (prop.GetValue(resourceParameters) is string value && !string.IsNullOrEmpty(value))
            {
                queryParameters.Add(prop.Name, value);
            }
        }

        return urlHelper?.Link(routeName, queryParameters);
    }

}