using IntelligentDiagnostician.API.Helpers.PaginationHelper;
using IntelligentDiagnostician.BL.DTOs.FaultDTOs;
using IntelligentDiagnostician.BL.Manager.FaultManager;
using IntelligentDiagnostician.BL.ResourceParameters;

namespace IntelligentDiagnostician.API.Helpers.Facades.FaultControllerFacade;

public interface IFaultControllerFacade
{
    IFaultManager FaultManager { get; set; }
    IPaginationHelper<FaultDto, FaultsResourceParameters> PaginationHelper { get; set; }
}
