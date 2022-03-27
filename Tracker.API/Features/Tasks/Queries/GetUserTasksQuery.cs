using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tracker.API.Features.Tasks.Models;
using Tracker.DAL;

namespace Tracker.API.Features.Tasks.Queries
{
    public class GetUserTasksQuery : IRequest<IEnumerable<TaskResponseModel>>
    {
        public string UserId { get; set; }
    }

    public class GetUserTasksQueryHandler
        : IRequestHandler<GetUserTasksQuery, IEnumerable<TaskResponseModel>>
    {
        private readonly ApplicationDbContext _context;

        public GetUserTasksQueryHandler(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<TaskResponseModel>> Handle(
            GetUserTasksQuery request,
            CancellationToken cancellationToken
        )
        {
            return await this._context.Tasks.Where(x => x.AssigneeId == request.UserId)
                .Select(x => new TaskResponseModel(x))
                .ToListAsync(cancellationToken);
        }
    }

    public class GetUserTasksQueryValidator : AbstractValidator<GetUserTasksQuery>
    {
        public GetUserTasksQueryValidator()
        {
            RuleFor(x => x.UserId)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .Matches(@"\A\S+\z");
        }
    }
}