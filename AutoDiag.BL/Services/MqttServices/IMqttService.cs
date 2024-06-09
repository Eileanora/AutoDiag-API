using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDiag.BL.Services.MqttServices;

public interface IMqttService
{
    Task ConnectAsync();
    Task DisconnectAsync();
}