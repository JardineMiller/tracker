using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Tracker.API.Infrastructure.Exceptions.Identity;
using Tracker.DAL;
using Tracker.DAL.Models.Entities;

namespace Tracker.API.Features.Identity.Commands
{
    public class RegisterUserCommand : IRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }

    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
    {
        private readonly UserManager<User> _userManager;

        public RegisterUserCommandHandler(UserManager<User> userManager)
        {
            this._userManager = userManager;
        }

        public async Task<Unit> Handle(
            RegisterUserCommand request,
            CancellationToken cancellationToken
        )
        {
            var user = new User
            {
                Email = request.Email,
                UserName = request.Username
            };

            var result = await this._userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded) throw new UserRegisterException(result.Errors);

            return Unit.Value;
        }

        public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
        {
            public RegisterUserCommandValidator()
            {
                RuleFor(r => r.Username)
                    .NotEmpty()
                    .NotNull();

                RuleFor(r => r.Password)
                    .NotEmpty()
                    .NotNull()
                    .MinimumLength(ValidationConstants.User.MinimumPasswordLength);

                RuleFor(r => r.Email)
                    .NotEmpty()
                    .NotNull();
            }
        }
    }
}