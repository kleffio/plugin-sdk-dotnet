using System.Net;
using System.Security.Cryptography.X509Certificates;
using Kleff.Plugin.Sdk.Internal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Kleff.Plugin.Sdk;

public static class PluginServer
{
    public static async Task ServeAsync<TPlugin>(string[] args)
        where TPlugin : KleffPlugin
    {
        var port = int.Parse(Environment.GetEnvironmentVariable("PORT") ?? "50051");

        var builder = WebApplication.CreateBuilder(args);
        builder.Logging.ClearProviders();
        builder.Logging.AddSimpleConsole(o => o.SingleLine = true);

        builder.Services.AddGrpc();
        builder.Services.AddSingleton<KleffPlugin, TPlugin>();

        builder.WebHost.ConfigureKestrel(opts =>
        {
            opts.Listen(IPAddress.Any, port, endpoint =>
            {
                var cert = Environment.GetEnvironmentVariable("PLUGIN_TLS_CERT_PEM");
                var key  = Environment.GetEnvironmentVariable("PLUGIN_TLS_KEY_PEM");
                if (!string.IsNullOrEmpty(cert) && !string.IsNullOrEmpty(key))
                    endpoint.UseHttps(X509Certificate2.CreateFromPem(cert, key));
                else
                    endpoint.Protocols = HttpProtocols.Http2;
            });
        });

        var app = builder.Build();
        app.MapGrpcService<HealthBridge>();
        app.MapGrpcService<UIManifestBridge>();
        app.MapGrpcService<APIMiddlewareBridge>();
        app.MapGrpcService<APIRoutesBridge>();
        app.MapGrpcService<IdentityProviderBridge>();
        app.MapGrpcService<IdentityFrameworkBridge>();

        var mode = string.IsNullOrEmpty(Environment.GetEnvironmentVariable("PLUGIN_TLS_CERT_PEM"))
            ? "insecure" : "mTLS";
        Console.WriteLine($"[kleff] plugin listening on :{port} ({mode})");

        await app.RunAsync();
    }
}
