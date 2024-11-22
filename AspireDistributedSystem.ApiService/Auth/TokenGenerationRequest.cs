using System.Text.Json;

namespace AspireDistributedSystem.ApiService.Auth;

public record struct TokenGenerationRequest(string Email, Guid UserId, Dictionary<string, JsonElement> CustomClaims);
