namespace IntelligentDiagnostician.BL.Services.UserSession;

public class UserSession : IUserSession
{
    public Guid UserId { get; set; }
    public string LoginName { get; set; } = string.Empty;
    public bool IsAuthenticated { get; set; }
}
