using PT_EDII_POS.Application.Features.Account;
using PT_EDII_POS.Domain.Users;

namespace PT_EDII_POS.Infrastructure.Features.Account;

public static class UserHelper
{
    public static User MapToUser(RegisterUserCommand command)
    {
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(command.Password);
        return new User()
        {
            Nama = command.Nama,
            Email = command.Email,
            PasswordHash = passwordHash
        };
    }
}
