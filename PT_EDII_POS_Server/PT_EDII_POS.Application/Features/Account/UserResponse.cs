namespace PT_EDII_POS.Application.Features.Account;

public record RegisterUserResponse(
    string Nama,
    string Email,
    string Password
);

public record LoginUserResponse(
    string Bearer
);