namespace PT_EDII_POS.API.Features.Account;

public record RegisterUserResponse(
    string Nama,
    string Email,
    string Password
);

public record LoginUserResponse(
    string Bearer
);