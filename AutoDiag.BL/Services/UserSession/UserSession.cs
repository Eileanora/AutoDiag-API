namespace AutoDiag.BL.Services.UserSession;

public class UserSession : IUserSession
{
    public Guid UserId { get; set; }
    public bool IsAuthenticated { get; set; }
}
