using Grpc.Core;

namespace Kleff.Plugin.Sdk;

/// <summary>
/// Base class for all Kleff plugins. Inherit from this and implement
/// IUIPlugin, IRoutesPlugin, IMiddlewarePlugin, or IIdentityPlugin
/// to declare which capabilities your plugin provides.
///
/// PluginServer.ServeAsync() detects the implemented interfaces at runtime
/// and registers the appropriate gRPC services automatically.
/// </summary>
public abstract class BasePlugin
{
    private readonly string _name;
    private readonly string _version;
    private readonly string[] _capabilities;

    protected BasePlugin(string name, string version, params string[] capabilities)
    {
        _name = name;
        _version = version;
        _capabilities = capabilities;
    }

    public virtual Task<HealthResponse> HealthAsync(HealthRequest request, ServerCallContext context) =>
        Task.FromResult(new HealthResponse
        {
            Status = HealthStatus.Healthy,
            Message = $"{_name} {_version}",
        });

    public virtual Task<GetCapabilitiesResponse> GetCapabilitiesAsync(GetCapabilitiesRequest request, ServerCallContext context) =>
        Task.FromResult(new GetCapabilitiesResponse
        {
            Capabilities = [.. _capabilities],
        });
}
