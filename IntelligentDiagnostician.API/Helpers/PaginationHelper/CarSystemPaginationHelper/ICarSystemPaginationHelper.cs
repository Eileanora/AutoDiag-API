using IntelligentDiagnostician.BL.DTOs.CarSystemsDTOs;
using IntelligentDiagnostician.BL.ResourceParameters;
using Microsoft.AspNetCore.Mvc;

namespace IntelligentDiagnostician.API.Helpers.PaginationHelper.CarSystemPaginationHelper;

public interface ICarSystemPaginationHelper
{
    void CreateMetaDataHeader(PagedList<CarSystemDto> systems,
        CarSystemsResourceParameters resourceParameters,
        IHeaderDictionary responseHeaders,
        IUrlHelper urlHelper);
    string? CreateCarSystemResourceUri(
        CarSystemsResourceParameters resourceParameters,
        string routeName,
        ResourceUriType type,
        IUrlHelper urlHelper);
}