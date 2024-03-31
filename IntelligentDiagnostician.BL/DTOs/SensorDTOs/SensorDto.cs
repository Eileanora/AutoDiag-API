using System.Text.Json.Serialization;
using IntelligentDiagnostician.BL.DTOs.Auditable;
using IntelligentDiagnostician.BL.Utils.OrderedPropertiesJson;

namespace IntelligentDiagnostician.BL.DTOs.SensorDTOs;

// [JsonConverter(typeof(MicrosoftOrderedPropertiesConverter<SensorDto>))]
public class SensorDto : SensorBaseDto , IAuditable
{
    public int Id { get; set; }
    public string? CarSystemName { get; set; }
    public int? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public int? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
}
