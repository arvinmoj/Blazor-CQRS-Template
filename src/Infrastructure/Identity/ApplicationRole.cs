using Microsoft.AspNetCore.Identity;
using Application.WebUI.Shared.Authorization;

namespace Application.Infrastructure.Identity;

public class ApplicationRole : IdentityRole
{
    public Permissions Permissions { get; set; }
}
