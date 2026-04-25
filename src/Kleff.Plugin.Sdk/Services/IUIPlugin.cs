using Grpc.Core;

namespace Kleff.Plugin.Sdk.Services;

public interface IUIPlugin
{
    Task<GetUIManifestResponse> GetUIManifestAsync(GetUIManifestRequest request, ServerCallContext context);
}
