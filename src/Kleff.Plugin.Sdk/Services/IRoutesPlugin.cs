using Grpc.Core;

namespace Kleff.Plugin.Sdk.Services;

public interface IRoutesPlugin
{
    Task<GetRoutesResponse> GetRoutesAsync(GetRoutesRequest request, ServerCallContext context);
    Task<HandleHTTPResponse> HandleAsync(HandleHTTPRequest request, ServerCallContext context);
}
