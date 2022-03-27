using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tracker.API.Features.Tasks.Models;
using Tracker.API.Features.Tasks.Queries;

namespace Tracker.API.Features.Tasks
{
    public class TasksController : ApiController
    {
        [HttpGet]
        [Route("{userId}")]
        public async Task<ActionResult<IEnumerable<TaskResponseModel>>> GetUserTasks(string userId)
        {
            var query = new GetUserTasksQuery { UserId = userId };
            var result = await this.Mediator.Send(query);
            return Ok(result);
        }
    }
}