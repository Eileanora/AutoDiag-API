using IntelligentDiagnostician.API.Helpers.PaginationHelper.FaultPaginationHelper;
using IntelligentDiagnostician.BL.Manager.FaultManager;

namespace IntelligentDiagnostician.API.Helpers.Facades.FaultControllerFacade;

public interface IFaultControllerFacade
{
    IFaultManager FaultManager { get; set; }
    IFaultPaginationHelper FaultPaginationHelper { get; set; }
}
