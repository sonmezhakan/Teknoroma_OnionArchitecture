namespace Teknoroma.Application.Security.JWTHelpers
{
    public interface IJwtService
    {
        Task<string> GetJwtToken(Guid Id, string userName);
    }
}
