using IntelligentDiagnostician.BL.DTOs.SensorDTOs;
using IntelligentDiagnostician.BL.ResourceParameters;
using Microsoft.AspNetCore.Mvc;

namespace IntelligentDiagnostician.API.Helpers.PaginationHelper;

public interface ISensorPaginationHelper
{
    void CreateMetaDataHeader(
        PagedList<SensorDto> systems,
        SensorsResourceParameters resourceParameters,
        IHeaderDictionary responseHeaders,
        IUrlHelper urlHelper);
    string? CreateSensorResourceUri(
        SensorsResourceParameters resourceParameters,
        string routeName,
        ResourceUriType type,
        IUrlHelper urlHelper);
}
