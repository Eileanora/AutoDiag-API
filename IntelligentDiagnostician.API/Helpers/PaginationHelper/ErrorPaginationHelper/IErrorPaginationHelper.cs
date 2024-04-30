using IntelligentDiagnostician.BL.DTOs.ErrorDTOs;
using IntelligentDiagnostician.BL.ResourceParameters;
using Microsoft.AspNetCore.Mvc;

namespace IntelligentDiagnostician.API.Helpers.PaginationHelper.ErrorPaginationHelper;

public interface IErrorPaginationHelper
{
    void CreateMetaDataHeader(PagedList<ErrorDto> systems,
        ErrorsResourceParameters resourceParameters,
        IHeaderDictionary responseHeaders,
        IUrlHelper urlHelper);
    string? CreateErrorResourceUri(
        ErrorsResourceParameters resourceParameters,
        string routeName,
        ResourceUriType type,
        IUrlHelper urlHelper);
}
