using System.Text.Json.Serialization;

namespace Kleff.Plugin.Sdk;

// ── Health types ──────────────────────────────────────────────────────────────

public class HealthRequest { }

public class HealthResponse
{
    [JsonPropertyName("status")] public HealthStatus Status { get; set; }
    [JsonPropertyName("message")] public string? Message { get; set; }
}

public enum HealthStatus
{
    Unknown = 0,
    Healthy = 1,
    Degraded = 2,
    Unhealthy = 3,
}

// ── Error type ────────────────────────────────────────────────────────────────

public class PluginError
{
    [JsonPropertyName("code")] public ErrorCode Code { get; set; }
    [JsonPropertyName("message")] public string? Message { get; set; }
}

public enum ErrorCode
{
    Unknown = 0,
    InvalidArgument = 1,
    Unauthorized = 2,
    Conflict = 3,
    NotFound = 4,
    Internal = 5,
    NotSupported = 6,
}

// ── Capabilities ──────────────────────────────────────────────────────────────

public class GetCapabilitiesRequest { }

public class GetCapabilitiesResponse
{
    [JsonPropertyName("capabilities")] public List<string>? Capabilities { get; set; }
}

// ── IDP types ─────────────────────────────────────────────────────────────────

public class LoginRequest
{
    [JsonPropertyName("username")] public string Username { get; set; } = "";
    [JsonPropertyName("password")] public string Password { get; set; } = "";
}

public class LoginResponse
{
    [JsonPropertyName("token")] public TokenSet? Token { get; set; }
    [JsonPropertyName("error")] public PluginError? Error { get; set; }
}

public class TokenSet
{
    [JsonPropertyName("access_token")] public string AccessToken { get; set; } = "";
    [JsonPropertyName("refresh_token")] public string? RefreshToken { get; set; }
    [JsonPropertyName("id_token")] public string? IdToken { get; set; }
    [JsonPropertyName("token_type")] public string TokenType { get; set; } = "";
    [JsonPropertyName("expires_in")] public long ExpiresIn { get; set; }
    [JsonPropertyName("scope")] public string? Scope { get; set; }
}

public class RegisterRequest
{
    [JsonPropertyName("username")] public string Username { get; set; } = "";
    [JsonPropertyName("email")] public string Email { get; set; } = "";
    [JsonPropertyName("password")] public string Password { get; set; } = "";
    [JsonPropertyName("first_name")] public string? FirstName { get; set; }
    [JsonPropertyName("last_name")] public string? LastName { get; set; }
}

public class RegisterResponse
{
    [JsonPropertyName("user_id")] public string? UserId { get; set; }
    [JsonPropertyName("error")] public PluginError? Error { get; set; }
}

public class GetUserRequest
{
    [JsonPropertyName("user_id")] public string UserId { get; set; } = "";
}

public class GetUserResponse
{
    [JsonPropertyName("user")] public UserInfo? User { get; set; }
    [JsonPropertyName("error")] public PluginError? Error { get; set; }
}

public class UserInfo
{
    [JsonPropertyName("user_id")] public string UserId { get; set; } = "";
    [JsonPropertyName("email")] public string Email { get; set; } = "";
    [JsonPropertyName("username")] public string Username { get; set; } = "";
    [JsonPropertyName("first_name")] public string? FirstName { get; set; }
    [JsonPropertyName("last_name")] public string? LastName { get; set; }
}

// ── Token validation types ────────────────────────────────────────────────────

public class ValidateTokenRequest
{
    [JsonPropertyName("token")] public string Token { get; set; } = "";
}

public class ValidateTokenResponse
{
    [JsonPropertyName("claims")] public TokenClaims? Claims { get; set; }
    [JsonPropertyName("error")] public PluginError? Error { get; set; }
}

public class TokenClaims
{
    [JsonPropertyName("subject")] public string Subject { get; set; } = "";
    [JsonPropertyName("username")] public string? Username { get; set; }
    [JsonPropertyName("email")] public string? Email { get; set; }
    [JsonPropertyName("roles")] public List<string>? Roles { get; set; }
}

// ── OIDC config types ─────────────────────────────────────────────────────────

public class GetOIDCConfigRequest { }

public class GetOIDCConfigResponse
{
    [JsonPropertyName("config")] public OIDCConfig? Config { get; set; }
    [JsonPropertyName("error")] public PluginError? Error { get; set; }
}

public class OIDCConfig
{
    [JsonPropertyName("authority")] public string Authority { get; set; } = "";
    [JsonPropertyName("client_id")] public string ClientId { get; set; } = "";
    [JsonPropertyName("jwks_uri")] public string JwksUri { get; set; } = "";
    [JsonPropertyName("scopes")] public List<string>? Scopes { get; set; }
    [JsonPropertyName("auth_mode")] public string? AuthMode { get; set; }
    [JsonPropertyName("token_endpoint")] public string? TokenEndpoint { get; set; }
    [JsonPropertyName("authorization_endpoint")] public string? AuthorizationEndpoint { get; set; }
    [JsonPropertyName("userinfo_endpoint")] public string? UserinfoEndpoint { get; set; }
    [JsonPropertyName("end_session_endpoint")] public string? EndSessionEndpoint { get; set; }
    [JsonPropertyName("internal_token_endpoint")] public string? InternalTokenEndpoint { get; set; }
}

// ── Token refresh types ───────────────────────────────────────────────────────

public class RefreshTokenRequest
{
    [JsonPropertyName("refresh_token")] public string RefreshToken { get; set; } = "";
}

public class RefreshTokenResponse
{
    [JsonPropertyName("token")] public TokenSet? Token { get; set; }
    [JsonPropertyName("error")] public PluginError? Error { get; set; }
}

// ── Admin seeding types ───────────────────────────────────────────────────────

public class EnsureAdminRequest { }

public class EnsureAdminResponse
{
    [JsonPropertyName("error")] public PluginError? Error { get; set; }
}

// ── Session types ─────────────────────────────────────────────────────────────

public class Session
{
    [JsonPropertyName("id")] public string Id { get; set; } = "";
    [JsonPropertyName("ip_address")] public string? IpAddress { get; set; }
    [JsonPropertyName("user_agent")] public string? UserAgent { get; set; }
    [JsonPropertyName("started_at")] public long? StartedAt { get; set; }
    [JsonPropertyName("last_access")] public long? LastAccess { get; set; }
    [JsonPropertyName("expires_at")] public long? ExpiresAt { get; set; }
    [JsonPropertyName("current")] public bool Current { get; set; }
}

public class ListSessionsRequest
{
    [JsonPropertyName("user_id")] public string UserId { get; set; } = "";
    [JsonPropertyName("current_session_id")] public string? CurrentSessionId { get; set; }
}

public class ListSessionsResponse
{
    [JsonPropertyName("sessions")] public List<Session>? Sessions { get; set; }
    [JsonPropertyName("error")] public PluginError? Error { get; set; }
}

public class RevokeSessionRequest
{
    [JsonPropertyName("user_id")] public string UserId { get; set; } = "";
    [JsonPropertyName("session_id")] public string SessionId { get; set; } = "";
}

public class RevokeSessionResponse
{
    [JsonPropertyName("error")] public PluginError? Error { get; set; }
}

// ── Change password types ─────────────────────────────────────────────────────

public class ChangePasswordRequest
{
    [JsonPropertyName("user_id")] public string UserId { get; set; } = "";
    [JsonPropertyName("current_password")] public string CurrentPassword { get; set; } = "";
    [JsonPropertyName("new_password")] public string NewPassword { get; set; } = "";
}

public class ChangePasswordResponse
{
    [JsonPropertyName("error")] public PluginError? Error { get; set; }
}

// ── UI manifest types ─────────────────────────────────────────────────────────

public class GetUIManifestRequest { }

public class GetUIManifestResponse
{
    [JsonPropertyName("manifest")] public UIManifest? Manifest { get; set; }
    [JsonPropertyName("error")] public PluginError? Error { get; set; }
}

public class UIManifest
{
    [JsonPropertyName("plugin_id")] public string? PluginId { get; set; }
    [JsonPropertyName("nav_items")] public List<NavItem>? NavItems { get; set; }
    [JsonPropertyName("settings_pages")] public List<SettingsPage>? SettingsPages { get; set; }
    [JsonPropertyName("login_config")] public LoginConfig? LoginConfig { get; set; }
    [JsonPropertyName("signup_config")] public SignupConfig? SignupConfig { get; set; }
    [JsonPropertyName("profile_sections")] public List<ProfileSection>? ProfileSections { get; set; }
}

public class NavItem
{
    [JsonPropertyName("label")] public string Label { get; set; } = "";
    [JsonPropertyName("icon")] public string? Icon { get; set; }
    [JsonPropertyName("path")] public string Path { get; set; } = "";
    [JsonPropertyName("permission")] public string? Permission { get; set; }
    [JsonPropertyName("children")] public List<NavItem>? Children { get; set; }
}

public class SettingsPage
{
    [JsonPropertyName("label")] public string Label { get; set; } = "";
    [JsonPropertyName("path")] public string Path { get; set; } = "";
    [JsonPropertyName("iframe_url")] public string? IframeUrl { get; set; }
}

public class LoginConfig
{
    [JsonPropertyName("disable_signup_link")] public bool? DisableSignupLink { get; set; }
}

public class SignupConfig
{
    [JsonPropertyName("disabled")] public bool? Disabled { get; set; }
    [JsonPropertyName("hide_first_name")] public bool? HideFirstName { get; set; }
    [JsonPropertyName("hide_last_name")] public bool? HideLastName { get; set; }
    [JsonPropertyName("hide_username")] public bool? HideUsername { get; set; }
}

public class ProfileSection
{
    [JsonPropertyName("id")] public string Id { get; set; } = "";
    [JsonPropertyName("title")] public string Title { get; set; } = "";
    [JsonPropertyName("description")] public string? Description { get; set; }
    [JsonPropertyName("iframe_url")] public string? IframeUrl { get; set; }
    [JsonPropertyName("actions")] public List<string>? Actions { get; set; }
}

// ── API middleware types ───────────────────────────────────────────────────────

public class MiddlewareRequest
{
    [JsonPropertyName("user_id")] public string UserId { get; set; } = "";
    [JsonPropertyName("roles")] public List<string>? Roles { get; set; }
    [JsonPropertyName("method")] public string Method { get; set; } = "";
    [JsonPropertyName("path")] public string Path { get; set; } = "";
    [JsonPropertyName("headers")] public Dictionary<string, string>? Headers { get; set; }
}

public class MiddlewareResponse
{
    [JsonPropertyName("allow")] public bool Allow { get; set; }
    [JsonPropertyName("error")] public PluginError? Error { get; set; }
}

// ── HTTP route ownership types ─────────────────────────────────────────────────

public class GetRoutesRequest { }

public class GetRoutesResponse
{
    [JsonPropertyName("routes")] public List<Route>? Routes { get; set; }
    [JsonPropertyName("error")] public PluginError? Error { get; set; }
}

public class Route
{
    [JsonPropertyName("method")] public string Method { get; set; } = "";
    [JsonPropertyName("path")] public string Path { get; set; } = "";
    [JsonPropertyName("public")] public bool? Public { get; set; }
}

public class HandleHTTPRequest
{
    [JsonPropertyName("request")] public HTTPRequest? Request { get; set; }
}

public class HandleHTTPResponse
{
    [JsonPropertyName("response")] public HTTPResponse? Response { get; set; }
    [JsonPropertyName("error")] public PluginError? Error { get; set; }
}

public class HTTPRequest
{
    [JsonPropertyName("method")] public string Method { get; set; } = "";
    [JsonPropertyName("path")] public string Path { get; set; } = "";
    [JsonPropertyName("raw_query")] public string? RawQuery { get; set; }
    [JsonPropertyName("headers")] public Dictionary<string, string>? Headers { get; set; }
    [JsonPropertyName("body")] public byte[]? Body { get; set; }
    [JsonPropertyName("user_id")] public string? UserId { get; set; }
    [JsonPropertyName("roles")] public List<string>? Roles { get; set; }
}

public class HTTPResponse
{
    [JsonPropertyName("status_code")] public int StatusCode { get; set; }
    [JsonPropertyName("headers")] public Dictionary<string, string>? Headers { get; set; }
    [JsonPropertyName("body")] public byte[]? Body { get; set; }
}
