using FluentValidation;

namespace PlainClasses.Services.Platoon.Application.Commands.DeletePlatoon
{
    public class DeletePlatoonCommandValidator : AbstractValidator<DeletePlatoonCommand>
    {
        public DeletePlatoonCommandValidator()
        {
            RuleFor(x => x.PlatoonId)
                .NotEmpty()
                .WithMessage("Id is empty.");
        }
    }
}