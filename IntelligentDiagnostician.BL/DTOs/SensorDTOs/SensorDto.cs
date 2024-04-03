using System.Text.Json.Serialization;
using IntelligentDiagnostician.BL.Utils.OrderedPropertiesJson;

namespace IntelligentDiagnostician.BL.DTOs.SensorDTOs;

// [JsonConverter(typeof(MicrosoftOrderedPropertiesConverter<SensorDto>))]
public class SensorDto : BaseDto.BaseDto
{
    public int Id { get; set; }
    public string SensorName { get; set; } = string.Empty;
    public int? CarSystemId { get; set; }
    public string? CarSystemName { get; set; }

}
