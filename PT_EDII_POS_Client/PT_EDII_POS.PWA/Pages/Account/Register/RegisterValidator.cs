using FluentValidation;

namespace PT_EDII_POS.PWA.Pages.Account.Register;

public class RegisterValidator : AbstractValidator<RegisterModel>
{
    public RegisterValidator()
    {
        RuleFor(x => x.Nama).NotEmpty().WithMessage("Nama harus di isi").MaximumLength(256).WithMessage("Maksimal 256 karakter");

        /* RuleFor(x => x.Email)
            .MustAsync(async (x, c) =>
            {
                User? user = await userRepo.FindUserByEmail(x);
                return user is null;
            }).WithMessage("Email sudah digunakan"); */

        RuleFor(x => x.Email).NotEmpty().WithMessage("Email harus di isi")
            .EmailAddress()
            .WithMessage("Masukan alamat email yang benar.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password harus di isi.")
            .MinimumLength(6).WithMessage("Password minimal 6 karakter.")
            .MaximumLength(20).WithMessage("Password maksimal 20 karakter.")
            .Matches(@"[A-Z]").WithMessage("Password memiliki setidaknya satu huruf kapital.")
            .Matches(@"[a-z]").WithMessage("Password memiliki setidaknya satu huruf kecil.")
            .Matches(@"[0-9]").WithMessage("Password memiliki setidaknya satu angka.")
            .Matches(@"[\W]").WithMessage("Password memiliki setidaknya satu karakter spesial (!.@ dll..).");
    }

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
            {
                var result = await ValidateAsync(ValidationContext<RegisterModel>.CreateWithOptions((RegisterModel)model, x => x.IncludeProperties(propertyName)));
                if (result.IsValid)
                    return [];
                return result.Errors.Select(e => e.ErrorMessage);
            };
}

