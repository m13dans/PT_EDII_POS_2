using ErrorOr;

namespace PT_EDII_POS.Application.Features.Account;
public class UserService(IUserRepoSitory repo)
{
    public async Task<ErrorOr<Created>> RegisterUser(RegisterUserCommand command)
    {
        var result = await repo.RegisterUser(command);
        return result;
    }

    public async Task<ErrorOr<LoginUserResponse>> LoginUser(LoginUserCommand command)
    {
        var result = await repo.LoginUser(command);
        return result;
    }

    public ErrorOr<Success> Logout()
    {
        return Result.Success;
    }
}