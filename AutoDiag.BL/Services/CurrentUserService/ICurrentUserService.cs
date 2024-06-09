using AutoDiag.BL.Services.UserSession;

namespace AutoDiag.BL.Services.CurrentUserService;

public interface ICurrentUserService
{
    IUserSession GetCurrentUser();
}
