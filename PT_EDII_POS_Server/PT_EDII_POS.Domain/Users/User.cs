namespace PT_EDII_POS.Domain.Users;

public class User
{
    public int Id { get; set; }
    public required string Nama { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
}
