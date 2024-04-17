namespace IntelligentDiagnostician.BL.Services.UserSession;

public interface IUserSession
{
    Guid UserId { get; set; }

    bool IsAuthenticated { get; set; }
}
