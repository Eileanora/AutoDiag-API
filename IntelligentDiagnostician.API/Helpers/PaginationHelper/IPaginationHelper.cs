using IntelligentDiagnostician.BL.ResourceParameters;
using Microsoft.AspNetCore.Mvc;

namespace IntelligentDiagnostician.API.Helpers.PaginationHelper;

public interface IPaginationHelper<TDto, TResourceParameters>
    where TDto : class
    where TResourceParameters : BaseResourceParameters
{
    void CreateMetaDataHeader(PagedList<TDto> items,
        TResourceParameters resourceParameters,
        IHeaderDictionary responseHeaders,
        IUrlHelper urlHelper,
        string routeName);

    string? CreateResourceUri(
        TResourceParameters resourceParameters,
        string routeName,
        ResourceUriType type,
        IUrlHelper urlHelper);
}
