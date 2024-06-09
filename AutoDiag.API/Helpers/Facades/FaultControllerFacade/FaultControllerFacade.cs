using AutoDiag.API.Helpers.PaginationHelper;
using AutoDiag.BL.DTOs.FaultDTOs;
using AutoDiag.BL.Manager.FaultManager;
using AutoDiag.BL.ResourceParameters;

namespace AutoDiag.API.Helpers.Facades.FaultControllerFacade;

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
