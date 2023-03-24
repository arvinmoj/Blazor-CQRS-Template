using Application.Application.Common.Services.Identity;
using Application.WebUI.Shared.AccessControl;
using Application.WebUI.Shared.Authorization;

namespace Application.Application.AccessControl.Queries;

public record GetAccessControlQuery() : IRequest<AccessControlVm>;

public class GetAccessControlQueryHandler : IRequestHandler<GetAccessControlQuery, AccessControlVm>
{
    private readonly IIdentityService _identityService;

    public GetAccessControlQueryHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<AccessControlVm> Handle(GetAccessControlQuery request, CancellationToken cancellationToken)
    {
        var permissions = new List<Permissions>();
        foreach (var permission in PermissionsProvider.GetAll())
        {
            if (permission == Permissions.None) continue;

            permissions.Add(permission);
        }

        var roles = await _identityService.GetRolesAsync(cancellationToken);

        var result = new AccessControlVm(roles, permissions);

        return result;
    }
}
