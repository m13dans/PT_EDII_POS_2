using ErrorOr;
using PT_EDII_POS.API.Features.Account;
using PT_EDII_POS.Domain.Users;

namespace PT_EDII_POS.Application.Account;

public interface IUserRepoSitory
{
  public Task<ErrorOr<Created>> RegisterUser(RegisterUserCommand command);
  public Task<ErrorOr<LoginUserResponse>> LoginUser(LoginUserCommand command);
  public Task<User?> FindUserByEmail(string email);
}
