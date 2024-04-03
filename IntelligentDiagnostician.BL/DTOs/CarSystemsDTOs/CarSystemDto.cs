using IntelligentDiagnostician.BL.DTOs.SensorDTOs;


namespace IntelligentDiagnostician.BL.DTOs.CarSystemsDTOs;

// [JsonConverter(typeof(MicrosoftOrderedPropertiesConverter<CarSystemDto>))]
public class CarSystemDto : BaseDto.BaseDto
{
    public int Id { get; set; }
    public string CarSystemName { get; set; } = string.Empty;
    public ICollection<SensorDto>? Sensors { get; set; }
}
