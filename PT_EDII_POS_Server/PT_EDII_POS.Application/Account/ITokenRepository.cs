using ErrorOr;
using PT_EDII_POS.API.Features.Account;
using PT_EDII_POS.Domain.Users;

namespace PT_EDII_POS.Application.Account;

public interface ITokenRepoSitory
{
  public string GenerateJWTToken(User user);
}
