using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace IntelligentDiagnostician.API.Helpers;

public static class JsonHelper
{
    public static string SerializeWithCustomOptions(object data)
    {
        // var encoderSettings = new TextEncoderSettings();
        // encoderSettings.AllowCharacter('&');
        // encoderSettings.AllowRange(UnicodeRanges.BasicLatin);
        // var options = new JsonSerializerOptions
        // {
        //     Encoder = JavaScriptEncoder.Create(encoderSettings),
        //     WriteIndented = true
        // };
        //
        // return JsonSerializer.Serialize(data, options);
        var options = new JsonSerializerOptions
        {
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
        return JsonSerializer.Serialize(data, options);
    }
}
