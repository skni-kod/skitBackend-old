using Data.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace skitBackend.Authorization
{
    public class CompanyResourceOperationRequirementHandler : AuthorizationHandler<CompanyResourceOperationRequeirement, Company>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CompanyResourceOperationRequeirement requirement, Company resource)
        {
            var roleId = context.User.FindFirst(c => c.Type == ClaimTypes.Role).Value;
            if (int.Parse(roleId) == 3 || int.Parse(roleId) == 2)
            {
                context.Succeed(requirement);
            }

            if (requirement.CompanyResourceOperation == CompanyResourceOperation.Read ||
                requirement.CompanyResourceOperation == CompanyResourceOperation.Create) 
            {
                context.Succeed(requirement);
            }

            var userId = context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;
            if (resource.CreatedByUserId == int.Parse(userId))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
