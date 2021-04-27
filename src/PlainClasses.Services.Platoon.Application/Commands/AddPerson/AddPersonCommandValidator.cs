using FluentValidation;

namespace PlainClasses.Services.Platoon.Application.Commands.AddPerson
{
    public class AddPersonCommandValidator : AbstractValidator<AddPersonCommand>
    {
        public AddPersonCommandValidator()
        {
            RuleFor(x => x.PlatoonId)
                .NotEmpty()
                .WithMessage("PlatoonId is empty.");
           
            RuleFor(x => x.PersonId)
                .NotEmpty()
                .WithMessage("PersonId is empty.");
        }
    }
}