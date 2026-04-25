using Grpc.Core;

namespace Kleff.Plugin.Sdk.Services;

public interface IMiddlewarePlugin
{
    Task<MiddlewareResponse> OnRequestAsync(MiddlewareRequest request, ServerCallContext context);
}
