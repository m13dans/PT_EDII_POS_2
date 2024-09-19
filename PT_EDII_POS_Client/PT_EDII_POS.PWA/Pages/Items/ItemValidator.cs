using FluentValidation;
namespace PT_EDII_POS.PWA.Pages.Items;

public class ItemValidator : AbstractValidator<ItemModel>
{
    public ItemValidator()
    {
        RuleFor(x => x.NamaBarang).NotEmpty().WithMessage("Nama barang harus di isi").MaximumLength(256).WithMessage("Maksimal 256 karakter");

        RuleFor(x => x.Kategori).NotEmpty().WithMessage("Kategori harus di isi").MaximumLength(256).WithMessage("Maksimal 256 karakter");

        RuleFor(x => x.Harga).GreaterThan(0).WithMessage("Harga lebih dari 0")
            .NotEmpty().WithMessage("Harga harus di isi.");

        RuleFor(x => x.StokAwal).GreaterThan(0).WithMessage("Stok Awal lebih dari 0")
            .NotEmpty().WithMessage("Stok harus di isi.");
    }

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
            {
                var result = await ValidateAsync(ValidationContext<ItemModel>.CreateWithOptions((ItemModel)model, x => x.IncludeProperties(propertyName)));
                if (result.IsValid)
                    return [];
                return result.Errors.Select(e => e.ErrorMessage);
            };
}

