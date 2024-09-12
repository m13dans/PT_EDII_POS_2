using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCrypt.Net;
using PT_EDII_POS.API.Features.Account;
using PT_EDII_POS.Domain.Users;

namespace PT_EDII_POS.Infrastructure.Account;

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
