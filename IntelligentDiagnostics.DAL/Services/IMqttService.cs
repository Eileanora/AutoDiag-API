using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentDiagnostics.DAL.Services
{
    public interface IMqttService
    {
        Task ConnectAsync();
        Task DisconnectAsync();
    }
}
