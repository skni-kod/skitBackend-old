using Data.Models;
using Microsoft.AspNetCore.Authorization;
using skitBackend.Data.Enums;
using System.Security.Claims;

namespace skitBackend.Authorization
{
    public class UserResourceOperationRequirementHandler : AuthorizationHandler<UserResourceOperationRequirement, User>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserResourceOperationRequirement requirement, User user)
        {
            if (requirement.UserResourceOperation == UserResourceOperation.Read)
            {
                context.Succeed(requirement);
            }

            if(!int.TryParse(context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value, out int loggedUserId))
            {
                return Task.CompletedTask;
            }

            if (user.Id == loggedUserId)
            {
                context.Succeed(requirement);
            }

            if(!int.TryParse(context.User.FindFirst(c => c.Type == ClaimTypes.Role)?.Value, out int role))
            {
                return Task.CompletedTask;
            }

            if (role == (int)UserRoleEnum.Admin)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
