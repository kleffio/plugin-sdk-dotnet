using Grpc.Core;
using Kleff.Plugins.V1;

namespace Kleff.Plugin.Sdk.Internal;

internal sealed class HealthBridge : PluginHealth.PluginHealthBase
{
    private readonly KleffPlugin _p;
    public HealthBridge(KleffPlugin p) => _p = p;

    public override Task<HealthResponse> Health(HealthRequest req, ServerCallContext ctx) =>
        _p.HealthAsync(req, ctx);

    public override Task<GetCapabilitiesResponse> GetCapabilities(GetCapabilitiesRequest req, ServerCallContext ctx)
    {
        var r = new GetCapabilitiesResponse();
        r.Capabilities.AddRange(_p.GetCapabilities());
        return Task.FromResult(r);
    }
}

internal sealed class UIManifestBridge : UIManifestService.UIManifestServiceBase
{
    private readonly KleffPlugin _p;
    public UIManifestBridge(KleffPlugin p) => _p = p;

    public override Task<GetUIManifestResponse> GetUIManifest(GetUIManifestRequest req, ServerCallContext ctx) =>
        _p.GetUIManifestAsync(req, ctx);
}

internal sealed class APIMiddlewareBridge : APIMiddleware.APIMiddlewareBase
{
    private readonly KleffPlugin _p;
    public APIMiddlewareBridge(KleffPlugin p) => _p = p;

    public override Task<MiddlewareResponse> OnRequest(MiddlewareRequest req, ServerCallContext ctx) =>
        _p.OnRequestAsync(req, ctx);
}

internal sealed class APIRoutesBridge : APIRoutes.APIRoutesBase
{
    private readonly KleffPlugin _p;
    public APIRoutesBridge(KleffPlugin p) => _p = p;

    public override Task<GetRoutesResponse> GetRoutes(GetRoutesRequest req, ServerCallContext ctx) =>
        _p.GetRoutesAsync(req, ctx);

    public override Task<HandleResponse> Handle(HandleRequest req, ServerCallContext ctx) =>
        _p.HandleAsync(req, ctx);
}

internal sealed class IdentityProviderBridge : IdentityProvider.IdentityProviderBase
{
    private readonly KleffPlugin _p;
    public IdentityProviderBridge(KleffPlugin p) => _p = p;

    public override Task<LoginResponse> Login(LoginRequest req, ServerCallContext ctx) =>
        _p.LoginAsync(req, ctx);
    public override Task<RegisterResponse> Register(RegisterRequest req, ServerCallContext ctx) =>
        _p.RegisterAsync(req, ctx);
    public override Task<GetUserResponse> GetUser(GetUserRequest req, ServerCallContext ctx) =>
        _p.GetUserAsync(req, ctx);
    public override Task<ValidateTokenResponse> ValidateToken(ValidateTokenRequest req, ServerCallContext ctx) =>
        _p.ValidateTokenAsync(req, ctx);
    public override Task<GetOIDCConfigResponse> GetOIDCConfig(GetOIDCConfigRequest req, ServerCallContext ctx) =>
        _p.GetOIDCConfigAsync(req, ctx);
    public override Task<RefreshTokenResponse> RefreshToken(RefreshTokenRequest req, ServerCallContext ctx) =>
        _p.RefreshTokenAsync(req, ctx);
    public override Task<HealthResponse> Health(HealthRequest req, ServerCallContext ctx) =>
        _p.HealthAsync(req, ctx);
}

internal sealed class IdentityFrameworkBridge : IdentityFramework.IdentityFrameworkBase
{
    private readonly KleffPlugin _p;
    public IdentityFrameworkBridge(KleffPlugin p) => _p = p;

    public override Task<CreateUserResponse> CreateUser(CreateUserRequest req, ServerCallContext ctx) =>
        _p.CreateUserAsync(req, ctx);
    public override Task<UpdateUserResponse> UpdateUser(UpdateUserRequest req, ServerCallContext ctx) =>
        _p.UpdateUserAsync(req, ctx);
    public override Task<DeleteUserResponse> DeleteUser(DeleteUserRequest req, ServerCallContext ctx) =>
        _p.DeleteUserAsync(req, ctx);
    public override Task<ListUsersResponse> ListUsers(ListUsersRequest req, ServerCallContext ctx) =>
        _p.ListUsersAsync(req, ctx);
    public override Task<SearchUsersResponse> SearchUsers(SearchUsersRequest req, ServerCallContext ctx) =>
        _p.SearchUsersAsync(req, ctx);
    public override Task<AssignRoleResponse> AssignRole(AssignRoleRequest req, ServerCallContext ctx) =>
        _p.AssignRoleAsync(req, ctx);
    public override Task<RevokeRoleResponse> RevokeRole(RevokeRoleRequest req, ServerCallContext ctx) =>
        _p.RevokeRoleAsync(req, ctx);
    public override Task<ListRolesResponse> ListRoles(ListRolesRequest req, ServerCallContext ctx) =>
        _p.ListRolesAsync(req, ctx);
    public override Task<ListSessionsResponse> ListSessions(ListSessionsRequest req, ServerCallContext ctx) =>
        _p.ListSessionsAsync(req, ctx);
    public override Task<RevokeSessionResponse> RevokeSession(RevokeSessionRequest req, ServerCallContext ctx) =>
        _p.RevokeSessionAsync(req, ctx);
    public override Task<ChangePasswordResponse> ChangePassword(ChangePasswordRequest req, ServerCallContext ctx) =>
        _p.ChangePasswordAsync(req, ctx);
    public override Task<EnsureAdminResponse> EnsureAdmin(EnsureAdminRequest req, ServerCallContext ctx) =>
        _p.EnsureAdminAsync(req, ctx);
    public override Task<HealthResponse> Health(HealthRequest req, ServerCallContext ctx) =>
        _p.HealthAsync(req, ctx);
}
