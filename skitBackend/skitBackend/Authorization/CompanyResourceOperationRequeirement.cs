using Microsoft.AspNetCore.Authorization;

namespace skitBackend.Authorization
{
    public enum CompanyResourceOperation
    {
        Create,
        Read,
        Update,
        Delete
    }
    public class CompanyResourceOperationRequeirement : IAuthorizationRequirement
    {
        public CompanyResourceOperationRequeirement(CompanyResourceOperation resourceOperation)
        {
            CompanyResourceOperation = resourceOperation;
        }
        public CompanyResourceOperation CompanyResourceOperation { get; }
    }
}
