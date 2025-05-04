using FluentValidation;
using Wypozyczalnia.ViewModels;

public class WypozyczenieViewModelValidator : AbstractValidator<WypozyczenieViewModel>
{
    public WypozyczenieViewModelValidator()
    {
        RuleFor(x => x.Id_klient)
            .GreaterThan(0).WithMessage("Wybierz klienta");

        RuleFor(x => x.Id_sprzetu)
            .GreaterThan(0).WithMessage("Wybierz sprzęt");

        RuleFor(x => x.Data_wypozyczenia)
            .NotEmpty().WithMessage("Data wypożyczenia jest wymagana")
            .LessThanOrEqualTo(DateTime.Today).WithMessage("Nie można wypożyczyć w przyszłości");

        RuleFor(x => x.Data_zwrotu)
            .GreaterThan(x => x.Data_wypozyczenia)
            .When(x => x.Data_zwrotu.HasValue)
            .WithMessage("Data zwrotu musi być późniejsza niż data wypożyczenia");
    }
}
