using IntelligentDiagnostician.BL.DTOs.FaultDTOs;
using IntelligentDiagnostician.BL.ResourceParameters;
using Microsoft.AspNetCore.Mvc;

namespace IntelligentDiagnostician.API.Helpers.PaginationHelper.FaultPaginationHelper;

public interface IFaultPaginationHelper
{
    void CreateMetaDataHeader(PagedList<FaultDto> systems,
        FaultsResourceParameters resourceParameters,
        IHeaderDictionary responseHeaders,
        IUrlHelper urlHelper);
    string? CreateErrorResourceUri(
        FaultsResourceParameters resourceParameters,
        string routeName,
        ResourceUriType type,
        IUrlHelper urlHelper);
}
