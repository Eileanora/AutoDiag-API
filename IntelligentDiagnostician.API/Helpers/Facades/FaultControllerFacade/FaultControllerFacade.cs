using IntelligentDiagnostician.API.Helpers.PaginationHelper;
using IntelligentDiagnostician.BL.DTOs.FaultDTOs;
using IntelligentDiagnostician.BL.Manager.FaultManager;
using IntelligentDiagnostician.BL.ResourceParameters;

namespace IntelligentDiagnostician.API.Helpers.Facades.FaultControllerFacade;

public class FaultControllerFacade : IFaultControllerFacade
{
    public IFaultManager FaultManager { get; set; }
    public IPaginationHelper<FaultDto, FaultsResourceParameters> PaginationHelper { get; set; }

    public FaultControllerFacade(
        IFaultManager faultManager,
        IPaginationHelper<FaultDto, FaultsResourceParameters> faultPaginationHelper)
    {
        FaultManager = faultManager;
        PaginationHelper = faultPaginationHelper;
    }
}
