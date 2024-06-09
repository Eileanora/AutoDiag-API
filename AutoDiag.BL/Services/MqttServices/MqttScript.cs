// using MQTTnet.Client.Options;
// using MQTTnet;
// using Newtonsoft.Json;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;
// using AutoDiag.DAL.Context;
// using MQTTnet.Client;
// using AutoDiag.DataModels.Models;
//
// namespace AutoDiag.DAL.Services.MqttServices;
//
// public class MqttScript
// {
//     public static async Task Mqtt()
//     {
//         var factory = new MqttFactory();
//         var client = factory.CreateMqttClient();
//
//         var options = new MqttClientOptionsBuilder()
//             .WithClientId("Client1")
//             .WithTcpServer("ba56550c63b34369a905b1bf7dfcb61f.s2.eu.hivemq.cloud", 8883)
//             .WithTls()
//             .WithCredentials("ahmedsamir4299", "01060402354aA")
//             .Build();
//
//         var dbContext = new AppDbContext();
//
//         client.UseConnectedHandler(async e =>
//         {
//             Console.WriteLine("Connected to HiveMQ Cloud.");
//             await client.SubscribeAsync(new MqttTopicFilterBuilder().WithTopic("1").Build());
//         });
//
//         client.UseApplicationMessageReceivedHandler(async e =>
//         {
//             var message = JsonConvert.DeserializeObject<Dictionary<string, string>>(Encoding.UTF8.GetString(e.ApplicationMessage.Payload));
//             Console.WriteLine("payload recieved");
//             if (message != null && message.ContainsKey("system"))
//             {
//                 // add a check to check if message contents are valid here
//                 foreach (var parameter in message.Keys)
//                 {
//                     // Create a new Record
//                     var record = new Reading
//                     {
//                         ReadingValue = int.Parse(message[parameter]),
//                         UserId = int.Parse(e.ApplicationMessage.Topic),
//                         SensorId = int.Parse(parameter),
//                         CreatedDate = DateTime.UtcNow
//                     };
//                     dbContext.Add(record);
//                 }
//             }
//             else if (message != null && message.ContainsKey("error"))
//             {
//                 // Create a new Error
//                 var error = new Error
//                 {
//                     Description = message["value"],
//                     UserId = int.Parse(e.ApplicationMessage.Topic),
//                     CreatedDate = DateTime.UtcNow
//                 };
//
//                 dbContext.Add(error);
//             }
//             await dbContext.SaveChangesAsync();
//         });
//
//         await client.ConnectAsync(options);
//
//         // Console.ReadLine();
//
//         await client.DisconnectAsync();
//     }
//     //static CarSystem xDSerializationJsonSring(string  JsonContent) 
//     //{
//     //    CarSystem systemCar = null;
//     //    systemCar = JsonConvert.DeserializeObject<CarSystem>(JsonContent);
//     //    return systemCar; 
//     //}
//     static T DeserializeJsonString<T>(string jsonContent)
//     {
//         return JsonConvert.DeserializeObject<T>(jsonContent);
//     }
// }