using IntelligentDiagnostician.BL.DTOs.FaultDTOs;
using IntelligentDiagnostician.BL.ResourceParameters;
using IntelligentDiagnostician.DataModels.Models;

namespace IntelligentDiagnostician.BL.Utils.Converter;

public static class FaultConverter
{
    public static Fault ToError(this FaultForCreationDto faultForCreationDto)
    {
        return new Fault
        {
            ProblemCode = faultForCreationDto.ProblemCode,
            UserId = faultForCreationDto.UserId.ToString()
        };
    }
    public static FaultDto ToListDto(this Fault fault)
    {
        return new FaultDto
        {
            Id = fault.Id,
            ProblemCode = fault.ProblemCode,
            ProblemDescription = fault.TroubleCode.ProblemDescription,
            Severity = fault.TroubleCode.Severity,
            TroubleCodeLinks = fault.TroubleCode.TroubleCodeLinks
                .Select(s =>s.ToDto()).ToList(),
            CreatedDate = fault.CreatedDate
            
        };
    }
    
    public static PagedList<FaultDto> ToListDto(this PagedList<Fault> errors)
    {
        var count = errors.TotalCount;
        var pageNumber = errors.CurrentPage;
        var pageSize = errors.PageSize;
        var totalPages = errors.TotalPages;
        return new PagedList<FaultDto>(
            errors.Select(s => s.ToListDto()).ToList(),
            count,
            pageNumber,
            pageSize,
            totalPages
        );
    }
}
