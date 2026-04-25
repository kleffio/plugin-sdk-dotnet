using Grpc.Core;

namespace Kleff.Plugin.Sdk.Services;

public interface IIdentityPlugin
{
    Task<LoginResponse> LoginAsync(LoginRequest request, ServerCallContext context);
    Task<RegisterResponse> RegisterAsync(RegisterRequest request, ServerCallContext context);
    Task<GetUserResponse> GetUserAsync(GetUserRequest request, ServerCallContext context);
    Task<HealthResponse> HealthAsync(HealthRequest request, ServerCallContext context);
    Task<ValidateTokenResponse> ValidateTokenAsync(ValidateTokenRequest request, ServerCallContext context);
    Task<GetOIDCConfigResponse> GetOIDCConfigAsync(GetOIDCConfigRequest request, ServerCallContext context);
    Task<RefreshTokenResponse> RefreshTokenAsync(RefreshTokenRequest request, ServerCallContext context);
    Task<EnsureAdminResponse> EnsureAdminAsync(EnsureAdminRequest request, ServerCallContext context);
    Task<ChangePasswordResponse> ChangePasswordAsync(ChangePasswordRequest request, ServerCallContext context);
    Task<ListSessionsResponse> ListSessionsAsync(ListSessionsRequest request, ServerCallContext context);
    Task<RevokeSessionResponse> RevokeSessionAsync(RevokeSessionRequest request, ServerCallContext context);
}
