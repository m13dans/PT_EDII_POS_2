using System.CodeDom.Compiler;
using ErrorOr;
using Microsoft.EntityFrameworkCore;
using PT_EDII_POS.API.Features.Account;
using PT_EDII_POS.Application.Account;
using PT_EDII_POS.Domain.Users;
using PT_EDII_POS.Infrastructure.DataContext;
using static PT_EDII_POS.Infrastructure.Account.UserHelper;

namespace PT_EDII_POS.Infrastructure.Account;

public class UserRepository(
    AppDbContext dbContext,
    TokenRepository tokenRepository) : IUserRepoSitory
{
    public async Task<ErrorOr<Created>> RegisterUser(RegisterUserCommand command)
    {
        User? userExist = await FindUserByEmail(command.Email);
        if (userExist is not null)
            return Error.Conflict("User.AlreadyExist");

        User user = MapToUser(command);
        var result = await dbContext.Users.AddAsync(user);
        await dbContext.SaveChangesAsync();
        return Result.Created;
    }

    public async Task<ErrorOr<LoginUserResponse>> LoginUser(LoginUserCommand command)
    {
        User? user = await FindUserByEmail(command.Email);
        if (user is null)
            return Error.NotFound(description: "Wrong Email or Password");

        string passwordHash = user.PasswordHash;

        var verify = BCrypt.Net.BCrypt.Verify(command.Password, passwordHash);
        if (!verify)
            return Error.Failure(description: "Wrong Email or Password");

        var jwt = tokenRepository.GenerateJWTToken(user);
        return new LoginUserResponse(jwt);
    }

    public async Task<User?> FindUserByEmail(string email)
    {
        User? result = await dbContext.Users
            .SingleOrDefaultAsync(u => u.Email == email);
        return result;
    }
}
