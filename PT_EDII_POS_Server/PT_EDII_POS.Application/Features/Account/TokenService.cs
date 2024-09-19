using PT_EDII_POS.Domain.Users;

namespace PT_EDII_POS.Application.Features.Account;

public class TokenService(ITokenRepoSitory tokenRepo)
{
    public string GenerateJWTToken(User user) =>
        tokenRepo.GenerateJWTToken(user);
}
