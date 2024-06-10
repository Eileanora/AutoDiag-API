using System.Text;
using Microsoft.Extensions.Configuration;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using Newtonsoft.Json;

namespace AutoDiag.BL.Services.MqttServices;

public class MqttService : IMqttService
{
    private readonly IMqttClient _mqttClient;
    private readonly IMessageProcessor _messageProcessor;
    private readonly IConfiguration _configuration; 

    public MqttService(IMqttClient mqttClient, IMessageProcessor messageProcessor , IConfiguration configuration )
    {
        _configuration = configuration; 
        _mqttClient = mqttClient;
        _messageProcessor = messageProcessor;
    }

    public async Task ConnectAsync()
    {
        var options = new MqttClientOptionsBuilder()
            .WithClientId("Client1")
            .WithTcpServer("ba56550c63b34369a905b1bf7dfcb61f.s2.eu.hivemq.cloud", 8883)
            .WithTls(new MqttClientOptionsBuilderTlsParameters
            {
                UseTls = true,
                IgnoreCertificateChainErrors = true,
                IgnoreCertificateRevocationErrors = true,
                AllowUntrustedCertificates = true
            })
           .WithCredentials("ahmedsamir4299", "01060402354aA")
            .WithCleanSession()
            .Build();
        Console.WriteLine("WENT THROUGH CONNECTING");

        _mqttClient.UseConnectedHandler(async e =>
        {
            Console.WriteLine("### CONNECTED WITH SERVER ###");
            await _mqttClient.SubscribeAsync(new MqttTopicFilterBuilder().WithTopic("#").Build());
        });

        _mqttClient.UseApplicationMessageReceivedHandler(async e =>
        {
            // Console.WriteLine("### RECEIVED APPLICATION MESSAGE ###");
            // Console.WriteLine($"+ Topic = {e.ApplicationMessage.Topic}");
            // Console.WriteLine($"+ Payload = {Encoding.UTF8.GetString(e.ApplicationMessage.Payload)}");
            // Console.WriteLine($"+ QoS = {e.ApplicationMessage.QualityOfServiceLevel}");
            // Console.WriteLine($"+ Retain = {e.ApplicationMessage.Retain}");
            // Console.WriteLine();
            var payload = JsonConvert.DeserializeObject<Dictionary<string, string>>(Encoding.UTF8.GetString(e.ApplicationMessage.Payload));
            if (payload is null)
                return;

            await _messageProcessor.ProcessMessage(e.ApplicationMessage.Topic, payload);
        });

        await _mqttClient.ConnectAsync(options);
    }

    public async Task DisconnectAsync()
    {
        await _mqttClient.DisconnectAsync();
    }
}