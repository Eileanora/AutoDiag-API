using System.Runtime.InteropServices.JavaScript;
using IntelligentDiagnostician.BL.DTOs.ErrorDTOs;
using IntelligentDiagnostician.BL.ResourceParameters;
using IntelligentDiagnostician.DataModels.Models;

namespace IntelligentDiagnostician.BL.Utils.Converter;

public static class ErrorConverter
{
    public static Error ToError(this ErrorForCreationDto errorForCreationDto)
    {
        return new Error
        {
            ProblemCode = errorForCreationDto.ProblemCode,
            UserId = errorForCreationDto.UserId.ToString()
        };
    }
    public static ErrorDto ToListDto(this Error error)
    {
        return new ErrorDto
        {
            Id = error.Id,
            ProblemCode = error.ProblemCode,
            ProblemDescription = error.TroubleCode.ProblemDescription,
            Severity = error.TroubleCode.Severity,
            TroubleCodeLinks = error.TroubleCode.TroubleCodeLinks
                .Select(s =>s.ToDto()).ToList(),
            CreatedDate = error.CreatedDate
            
        };
    }
    
    public static PagedList<ErrorDto> ToListDto(this PagedList<Error> errors)
    {
        var count = errors.TotalCount;
        var pageNumber = errors.CurrentPage;
        var pageSize = errors.PageSize;
        var totalPages = errors.TotalPages;
        return new PagedList<ErrorDto>(
            errors.Select(s => s.ToListDto()).ToList(),
            count,
            pageNumber,
            pageSize,
            totalPages
        );
    }
}
