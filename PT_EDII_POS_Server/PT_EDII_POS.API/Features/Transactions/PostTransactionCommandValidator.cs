using FluentValidation;
using PT_EDII_POS.Application.Transactions;

namespace PT_EDII_POS.API.Features.Transactions;

public class PostTransactionCommandValidator : AbstractValidator<PostTransactionCommand>
{
    public PostTransactionCommandValidator()
    {
        RuleFor(x => x.JumlahItem).GreaterThan(0).WithMessage("Jumlah Item yang akan di jual Harus lebih dari 1");
        RuleFor(x => x.ItemId).NotEmpty();
    }

}
