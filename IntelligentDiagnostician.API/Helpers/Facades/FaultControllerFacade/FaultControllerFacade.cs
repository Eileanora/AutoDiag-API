using IntelligentDiagnostician.API.Helpers.PaginationHelper.FaultPaginationHelper;
using IntelligentDiagnostician.BL.Manager.FaultManager;

namespace IntelligentDiagnostician.API.Helpers.Facades.FaultControllerFacade;

public class FaultControllerFacade : IFaultControllerFacade
{
    public IFaultManager FaultManager { get; set; }
    public IFaultPaginationHelper FaultPaginationHelper { get; set; }
    
    public FaultControllerFacade(
        IFaultManager faultManager,
        IFaultPaginationHelper faultPaginationHelper)
    {
        FaultManager = faultManager;
        FaultPaginationHelper = faultPaginationHelper;
    }
}
