using PT_EDII_POS.Domain.Users;

namespace PT_EDII_POS.Application.Features.Account;

public interface ITokenRepoSitory
{
    public string GenerateJWTToken(User user);
}
