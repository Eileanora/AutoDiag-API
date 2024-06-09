using System.Text.Json.Serialization;
using AutoDiag.BL.DTOs.SensorDTOs;


namespace AutoDiag.BL.DTOs.CarSystemsDTOs;

// [JsonConverter(typeof(MicrosoftOrderedPropertiesConverter<CarSystemDto>))]
public class CarSystemDto
{
    public int Id { get; set; }
    public string CarSystemName { get; set; } = string.Empty;
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ICollection<SensorDto>? Sensors { get; set; }
}
