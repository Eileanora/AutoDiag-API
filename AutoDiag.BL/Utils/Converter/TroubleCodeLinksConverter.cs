using AutoDiag.BL.DTOs.TroubleCodeDTOs;
using AutoDiag.DataModels.Models;

namespace AutoDiag.BL.Utils.Converter;

public static class TroubleCodeLinksConverter
{
    public static TroubleCodeLinkDto ToDto(this TroubleCodeLink troubleCodeLink)
    {
        if (troubleCodeLink == null)
            throw new Exception("TroubleCodeLink is null.");
        return new TroubleCodeLinkDto
        {
            Id = troubleCodeLink.Id,
            Title = troubleCodeLink.Title,
            Link = troubleCodeLink.Link,
        };
    }
}
