using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using ValidationException = Tracker.API.Infrastructure.Exceptions.ValidationException;

namespace Tracker.API.Infrastructure.PipelineBehaviours
{
    public class RequestValidationBehaviour<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public RequestValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            this._validators = validators;
        }

        public Task<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next
        )
        {
            var context = new ValidationContext<TRequest>(request);

            var failures = this._validators.Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Any())
            {
                throw new ValidationException(failures);
            }

            return next();
        }
    }
}