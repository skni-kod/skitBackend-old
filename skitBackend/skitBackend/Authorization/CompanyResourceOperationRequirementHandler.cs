using Data.Models;
using Microsoft.AspNetCore.Authorization;
using skitBackend.Data.Enums;
using System.Security.Claims;

namespace skitBackend.Authorization
{
    public class CompanyResourceOperationRequirementHandler : AuthorizationHandler<CompanyResourceOperationRequeirement, Company>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CompanyResourceOperationRequeirement requirement, Company resource)
        {
            if (requirement.CompanyResourceOperation == CompanyResourceOperation.Read && resource.IsPublished)
                context.Succeed(requirement);

            var userId = context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return Task.CompletedTask;
            }
            
            if (requirement.CompanyResourceOperation == CompanyResourceOperation.Create)
            {
                context.Succeed(requirement);
            }

            if (resource.CreatedByUserId == int.Parse(userId))
            {
                context.Succeed(requirement);
            }
            
            var roleId = context.User.FindFirst(c => c.Type == ClaimTypes.Role)?.Value;

            if(roleId == null)
            {
                return Task.CompletedTask;
            }

            if (int.Parse(roleId) == (int)UserRoleEnum.Admin || int.Parse(roleId) == (int)UserRoleEnum.Moderator)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
