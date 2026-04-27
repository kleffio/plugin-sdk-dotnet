using Grpc.Core;
using Kleff.Plugins.V1;

namespace Kleff.Plugin.Sdk;

public abstract class KleffPlugin
{
    public abstract string Name { get; }
    public abstract string Version { get; }
    public abstract IReadOnlyList<string> GetCapabilities();

    // Health — default: healthy. Override to add custom checks.
    public virtual Task<HealthResponse> HealthAsync(HealthRequest req, ServerCallContext ctx) =>
        Task.FromResult(new HealthResponse { Status = HealthResponse.Types.Status.Healthy });

    // ui.manifest
    public virtual Task<GetUIManifestResponse> GetUIManifestAsync(GetUIManifestRequest req, ServerCallContext ctx) =>
        throw new RpcException(new Status(StatusCode.Unimplemented, "ui.manifest not implemented"));

    // api.middleware
    public virtual Task<MiddlewareResponse> OnRequestAsync(MiddlewareRequest req, ServerCallContext ctx) =>
        throw new RpcException(new Status(StatusCode.Unimplemented, "api.middleware not implemented"));

    // api.routes
    public virtual Task<GetRoutesResponse> GetRoutesAsync(GetRoutesRequest req, ServerCallContext ctx) =>
        throw new RpcException(new Status(StatusCode.Unimplemented, "api.routes not implemented"));

    public virtual Task<HandleResponse> HandleAsync(HandleRequest req, ServerCallContext ctx) =>
        throw new RpcException(new Status(StatusCode.Unimplemented, "api.routes not implemented"));

    // identity.provider
    public virtual Task<LoginResponse> LoginAsync(LoginRequest req, ServerCallContext ctx) =>
        throw new RpcException(new Status(StatusCode.Unimplemented, "identity.provider not implemented"));

    public virtual Task<RegisterResponse> RegisterAsync(RegisterRequest req, ServerCallContext ctx) =>
        throw new RpcException(new Status(StatusCode.Unimplemented, "identity.provider not implemented"));

    public virtual Task<GetUserResponse> GetUserAsync(GetUserRequest req, ServerCallContext ctx) =>
        throw new RpcException(new Status(StatusCode.Unimplemented, "identity.provider not implemented"));

    public virtual Task<ValidateTokenResponse> ValidateTokenAsync(ValidateTokenRequest req, ServerCallContext ctx) =>
        throw new RpcException(new Status(StatusCode.Unimplemented, "identity.provider not implemented"));

    public virtual Task<GetOIDCConfigResponse> GetOIDCConfigAsync(GetOIDCConfigRequest req, ServerCallContext ctx) =>
        throw new RpcException(new Status(StatusCode.Unimplemented, "identity.provider not implemented"));

    public virtual Task<RefreshTokenResponse> RefreshTokenAsync(RefreshTokenRequest req, ServerCallContext ctx) =>
        throw new RpcException(new Status(StatusCode.Unimplemented, "identity.provider not implemented"));

    // identity.framework
    public virtual Task<CreateUserResponse> CreateUserAsync(CreateUserRequest req, ServerCallContext ctx) =>
        throw new RpcException(new Status(StatusCode.Unimplemented, "identity.framework not implemented"));

    public virtual Task<UpdateUserResponse> UpdateUserAsync(UpdateUserRequest req, ServerCallContext ctx) =>
        throw new RpcException(new Status(StatusCode.Unimplemented, "identity.framework not implemented"));

    public virtual Task<DeleteUserResponse> DeleteUserAsync(DeleteUserRequest req, ServerCallContext ctx) =>
        throw new RpcException(new Status(StatusCode.Unimplemented, "identity.framework not implemented"));

    public virtual Task<ListUsersResponse> ListUsersAsync(ListUsersRequest req, ServerCallContext ctx) =>
        throw new RpcException(new Status(StatusCode.Unimplemented, "identity.framework not implemented"));

    public virtual Task<SearchUsersResponse> SearchUsersAsync(SearchUsersRequest req, ServerCallContext ctx) =>
        throw new RpcException(new Status(StatusCode.Unimplemented, "identity.framework not implemented"));

    public virtual Task<AssignRoleResponse> AssignRoleAsync(AssignRoleRequest req, ServerCallContext ctx) =>
        throw new RpcException(new Status(StatusCode.Unimplemented, "identity.framework not implemented"));

    public virtual Task<RevokeRoleResponse> RevokeRoleAsync(RevokeRoleRequest req, ServerCallContext ctx) =>
        throw new RpcException(new Status(StatusCode.Unimplemented, "identity.framework not implemented"));

    public virtual Task<ListRolesResponse> ListRolesAsync(ListRolesRequest req, ServerCallContext ctx) =>
        throw new RpcException(new Status(StatusCode.Unimplemented, "identity.framework not implemented"));

    public virtual Task<ListSessionsResponse> ListSessionsAsync(ListSessionsRequest req, ServerCallContext ctx) =>
        throw new RpcException(new Status(StatusCode.Unimplemented, "identity.framework not implemented"));

    public virtual Task<RevokeSessionResponse> RevokeSessionAsync(RevokeSessionRequest req, ServerCallContext ctx) =>
        throw new RpcException(new Status(StatusCode.Unimplemented, "identity.framework not implemented"));

    public virtual Task<ChangePasswordResponse> ChangePasswordAsync(ChangePasswordRequest req, ServerCallContext ctx) =>
        throw new RpcException(new Status(StatusCode.Unimplemented, "identity.framework not implemented"));

    public virtual Task<EnsureAdminResponse> EnsureAdminAsync(EnsureAdminRequest req, ServerCallContext ctx) =>
        throw new RpcException(new Status(StatusCode.Unimplemented, "identity.framework not implemented"));
}
