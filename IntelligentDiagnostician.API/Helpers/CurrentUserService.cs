using System.Security.Claims;
using IntelligentDiagnostician.BL.Services.CurrentUserService;
using IntelligentDiagnostician.BL.Services.UserSession;
using Microsoft.AspNetCore.Http;

namespace IntelligentDiagnostician.API.Helpers;


public class CurrentUserService(IHttpContextAccessor contextAccessor) : ICurrentUserService
{
    public IUserSession GetCurrentUser()
    {
        if (contextAccessor?.HttpContext == null)
            return new UserSession();
        
        if (contextAccessor.HttpContext.User.Identity is { IsAuthenticated: false })
            return new UserSession();
        
        var currentUser = new UserSession
        {
            IsAuthenticated = contextAccessor.HttpContext.User.Identity != null && contextAccessor.HttpContext.User.Identity.IsAuthenticated,
            
            UserId = Guid.Parse(contextAccessor.HttpContext.User
                                    .FindFirstValue(ClaimTypes.Sid)
                                ?? Guid.Empty.ToString()),
        };
        return currentUser;
    }
}
