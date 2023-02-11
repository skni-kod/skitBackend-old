using Microsoft.AspNetCore.Authorization;

namespace skitBackend.Authorization
{
    public enum ResourceOperation
    {
        Create,
        Read,
        Update,
        Delete
    }
    public class ResourceOperationRequeirement : IAuthorizationRequirement
    {
        public ResourceOperationRequeirement(ResourceOperation resourceOperation)
        {
            ResourceOperation = resourceOperation;
        }
        public ResourceOperation ResourceOperation { get; }
    }
}
