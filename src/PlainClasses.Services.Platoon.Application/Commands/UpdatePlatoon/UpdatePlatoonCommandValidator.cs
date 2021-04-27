using FluentValidation;

namespace PlainClasses.Services.Platoon.Application.Commands.UpdatePlatoon
{
    public class UpdatePlatoonCommandValidator : AbstractValidator<UpdatePlatoonCommand>
    {
        public UpdatePlatoonCommandValidator()
        {
            RuleFor(x => x.Commander)
                .NotEmpty()
                .WithMessage("Commander is empty.");
        }
    }
}