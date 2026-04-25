using Grpc.Core;
using Kleff.Plugin.Sdk.Internal;
using Kleff.Plugin.Sdk.Services;

namespace Kleff.Plugin.Sdk;

public static class PluginServer
{
    /// <summary>
    /// Starts a gRPC server for the given plugin, auto-registering services
    /// based on which interfaces the plugin implements. Blocks until SIGTERM or Ctrl+C.
    /// </summary>
    public static async Task ServeAsync(BasePlugin plugin, CancellationToken cancellationToken = default)
    {
        var port = int.Parse(Environment.GetEnvironmentVariable("PORT") ?? "50051");

        var server = new Server();
        server.Services.Add(ServiceDefinitions.BuildHealth(plugin));

        if (plugin is IUIPlugin ui)
            server.Services.Add(ServiceDefinitions.BuildUI(ui));
        if (plugin is IMiddlewarePlugin middleware)
            server.Services.Add(ServiceDefinitions.BuildMiddleware(middleware));
        if (plugin is IRoutesPlugin routes)
            server.Services.Add(ServiceDefinitions.BuildHTTP(routes));
        if (plugin is IIdentityPlugin identity)
            server.Services.Add(ServiceDefinitions.BuildIdentity(identity));

        var credentials = BuildCredentials();
        server.Ports.Add(new ServerPort("0.0.0.0", port, credentials));
        server.Start();

        var mode = credentials == ServerCredentials.Insecure ? "insecure" : "mTLS";
        Console.WriteLine($"[kleff] plugin gRPC server listening on :{port} ({mode})");

        using var linked = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        AppDomain.CurrentDomain.ProcessExit += (_, _) => linked.Cancel();
        Console.CancelKeyPress += (_, e) => { e.Cancel = true; linked.Cancel(); };

        try
        {
            await Task.Delay(Timeout.Infinite, linked.Token);
        }
        catch (OperationCanceledException) { }

        Console.WriteLine("[kleff] shutting down...");
        await server.ShutdownAsync();
    }

    private static ServerCredentials BuildCredentials()
    {
        var cert = Environment.GetEnvironmentVariable("PLUGIN_TLS_CERT_PEM");
        var key = Environment.GetEnvironmentVariable("PLUGIN_TLS_KEY_PEM");

        if (string.IsNullOrEmpty(cert) || string.IsNullOrEmpty(key))
            return ServerCredentials.Insecure;

        return new SslServerCredentials([new KeyCertificatePair(cert, key)]);
    }
}
