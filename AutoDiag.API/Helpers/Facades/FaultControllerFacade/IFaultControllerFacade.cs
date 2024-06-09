using AutoDiag.API.Helpers.PaginationHelper;
using AutoDiag.BL.DTOs.FaultDTOs;
using AutoDiag.BL.Manager.FaultManager;
using AutoDiag.BL.ResourceParameters;

namespace AutoDiag.API.Helpers.Facades.FaultControllerFacade;

public interface IFaultControllerFacade
{
    IFaultManager FaultManager { get; set; }
    IPaginationHelper<FaultDto, FaultsResourceParameters> PaginationHelper { get; set; }
}
