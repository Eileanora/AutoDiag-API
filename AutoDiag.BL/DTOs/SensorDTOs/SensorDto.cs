﻿using System.Text.Json.Serialization;
using AutoDiag.BL.Helpers.OrderedPropertiesJson;

namespace AutoDiag.BL.DTOs.SensorDTOs;

// [JsonConverter(typeof(MicrosoftOrderedPropertiesConverter<SensorDto>))]
public class SensorDto
{
    public int Id { get; set; }
    public string SensorName { get; set; } = string.Empty;
    public float? MinValue { get; set; }
    public float? MaxValue { get; set; }
    public float? AvgValue { get; set; }
    public string? Unit { get; set; }
}
