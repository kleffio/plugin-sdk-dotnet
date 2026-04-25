using Grpc.Core;
using Kleff.Plugin.Sdk.Services;

namespace Kleff.Plugin.Sdk.Internal;

// gRPC service name prefix — matches the Go SDK's kleff.plugins.v1.* namespace.
file static class S
{
    internal static Method<TReq, TRes> Unary<TReq, TRes>(string service, string method) =>
        new(MethodType.Unary, service, method, JsonMarshaller.For<TReq>(), JsonMarshaller.For<TRes>());
}

internal static class ServiceDefinitions
{
    private const string Health = "kleff.plugins.v1.PluginHealth";
    private const string UI = "kleff.plugins.v1.PluginUI";
    private const string Middleware = "kleff.plugins.v1.PluginMiddleware";
    private const string HTTP = "kleff.plugins.v1.PluginHTTP";
    private const string Identity = "kleff.plugins.v1.IdentityPlugin";

    internal static ServerServiceDefinition BuildHealth(BasePlugin plugin) =>
        ServerServiceDefinition.CreateBuilder()
            .AddMethod(S.Unary<HealthRequest, HealthResponse>(Health, "Health"), plugin.HealthAsync)
            .AddMethod(S.Unary<GetCapabilitiesRequest, GetCapabilitiesResponse>(Health, "GetCapabilities"), plugin.GetCapabilitiesAsync)
            .Build();

    internal static ServerServiceDefinition BuildUI(IUIPlugin handler) =>
        ServerServiceDefinition.CreateBuilder()
            .AddMethod(S.Unary<GetUIManifestRequest, GetUIManifestResponse>(UI, "GetUIManifest"), handler.GetUIManifestAsync)
            .Build();

    internal static ServerServiceDefinition BuildMiddleware(IMiddlewarePlugin handler) =>
        ServerServiceDefinition.CreateBuilder()
            .AddMethod(S.Unary<MiddlewareRequest, MiddlewareResponse>(Middleware, "OnRequest"), handler.OnRequestAsync)
            .Build();

    internal static ServerServiceDefinition BuildHTTP(IRoutesPlugin handler) =>
        ServerServiceDefinition.CreateBuilder()
            .AddMethod(S.Unary<GetRoutesRequest, GetRoutesResponse>(HTTP, "GetRoutes"), handler.GetRoutesAsync)
            .AddMethod(S.Unary<HandleHTTPRequest, HandleHTTPResponse>(HTTP, "Handle"), handler.HandleAsync)
            .Build();

    internal static ServerServiceDefinition BuildIdentity(IIdentityPlugin handler) =>
        ServerServiceDefinition.CreateBuilder()
            .AddMethod(S.Unary<LoginRequest, LoginResponse>(Identity, "Login"), handler.LoginAsync)
            .AddMethod(S.Unary<RegisterRequest, RegisterResponse>(Identity, "Register"), handler.RegisterAsync)
            .AddMethod(S.Unary<GetUserRequest, GetUserResponse>(Identity, "GetUser"), handler.GetUserAsync)
            .AddMethod(S.Unary<HealthRequest, HealthResponse>(Identity, "Health"), handler.HealthAsync)
            .AddMethod(S.Unary<ValidateTokenRequest, ValidateTokenResponse>(Identity, "ValidateToken"), handler.ValidateTokenAsync)
            .AddMethod(S.Unary<GetOIDCConfigRequest, GetOIDCConfigResponse>(Identity, "GetOIDCConfig"), handler.GetOIDCConfigAsync)
            .AddMethod(S.Unary<RefreshTokenRequest, RefreshTokenResponse>(Identity, "RefreshToken"), handler.RefreshTokenAsync)
            .AddMethod(S.Unary<EnsureAdminRequest, EnsureAdminResponse>(Identity, "EnsureAdmin"), handler.EnsureAdminAsync)
            .AddMethod(S.Unary<ChangePasswordRequest, ChangePasswordResponse>(Identity, "ChangePassword"), handler.ChangePasswordAsync)
            .AddMethod(S.Unary<ListSessionsRequest, ListSessionsResponse>(Identity, "ListSessions"), handler.ListSessionsAsync)
            .AddMethod(S.Unary<RevokeSessionRequest, RevokeSessionResponse>(Identity, "RevokeSession"), handler.RevokeSessionAsync)
            .Build();
}
