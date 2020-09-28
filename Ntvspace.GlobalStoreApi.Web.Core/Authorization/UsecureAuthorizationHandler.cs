using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace Ntvspace.GlobalStoreApi.Web.Core.Authorization
{
  public class UsecureAuthorizationHandler : AuthorizationHandler<UsecureAuthorizationRequirement>
  {
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UsecureAuthorizationRequirement requirement)
    {
      if(!context.User.Identity.IsAuthenticated)
      {
        context.Fail();
        return Task.CompletedTask;
      }

      context.Succeed(requirement);
      return Task.CompletedTask;
    }
  }
}
