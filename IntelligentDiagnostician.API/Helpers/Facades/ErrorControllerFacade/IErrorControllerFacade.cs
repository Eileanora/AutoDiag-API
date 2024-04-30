using IntelligentDiagnostician.API.Helpers.PaginationHelper.ErrorPaginationHelper;
using IntelligentDiagnostician.BL.Manager.ErrorManager;

namespace IntelligentDiagnostician.API.Helpers.Facades.ErrorControllerFacade;

public interface IErrorControllerFacade
{
    IErrorManager ErrorManager { get; set; }
    IErrorPaginationHelper ErrorPaginationHelper { get; set; }
}
