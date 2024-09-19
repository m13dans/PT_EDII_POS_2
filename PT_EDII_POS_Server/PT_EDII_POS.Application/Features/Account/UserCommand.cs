namespace PT_EDII_POS.Application.Features.Account;

public record RegisterUserCommand(
  string Nama,
  string Email,
  string Password
);

public record LoginUserCommand(
  string Email,
  string Password
);