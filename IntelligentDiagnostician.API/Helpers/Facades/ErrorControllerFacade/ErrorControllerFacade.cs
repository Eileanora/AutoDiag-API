using IntelligentDiagnostician.API.Helpers.PaginationHelper.ErrorPaginationHelper;
using IntelligentDiagnostician.BL.Manager.ErrorManager;

namespace IntelligentDiagnostician.API.Helpers.Facades.ErrorControllerFacade;

public class ErrorControllerFacade : IErrorControllerFacade
{
    public IErrorManager ErrorManager { get; set; }
    public IErrorPaginationHelper ErrorPaginationHelper { get; set; }
    
    public ErrorControllerFacade(
        IErrorManager errorManager,
        IErrorPaginationHelper errorPaginationHelper)
    {
        ErrorManager = errorManager;
        ErrorPaginationHelper = errorPaginationHelper;
    }
}
