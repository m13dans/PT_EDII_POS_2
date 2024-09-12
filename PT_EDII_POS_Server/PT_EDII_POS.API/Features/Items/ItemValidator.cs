using FluentValidation;
using static PT_EDII_POS.API.Features.Items.ImageValidatorHelper;

namespace PT_EDII_POS.API.Features.Items;

public class CreateItemValidator : AbstractValidator<CreateItemCommand>
{
    public CreateItemValidator()
    {
        RuleFor(x => x.NamaBarang).MinimumLength(3).MaximumLength(256);
        RuleFor(x => x.StokAwal).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Kategori).MinimumLength(3).MaximumLength(256);
        RuleFor(x => x.Gambar)
            .Must(ValidateImageSize)
            .WithMessage("Gambar harus kurang dari 2 Mb");
        RuleFor(x => x.Gambar)
            .Must(ValidateImageExtension)
            .WithMessage("Harus berupa gambar .jpg / .png");
    }
}
public class UpdateItemValidator : AbstractValidator<UpdateItemCommand>
{
    public UpdateItemValidator()
    {
        RuleFor(x => x.NamaBarang).MinimumLength(3).MaximumLength(256);
        RuleFor(x => x.StokAwal).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Kategori).MinimumLength(3).MaximumLength(256);
        RuleFor(x => x.Gambar)
            .Must(ValidateImageSize)
            .WithMessage("Gambar harus kurang dari 2 Mb");
        RuleFor(x => x.Gambar)
            .Must(ValidateImageExtension)
            .WithMessage("Harus berupa gambar .jpg / .png");
    }
}
