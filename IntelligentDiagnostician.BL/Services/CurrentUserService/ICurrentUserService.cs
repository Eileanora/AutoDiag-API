using IntelligentDiagnostician.BL.Services.UserSession;

namespace IntelligentDiagnostician.BL.Services.CurrentUserService;

public interface ICurrentUserService
{
    IUserSession GetCurrentUser();
}
