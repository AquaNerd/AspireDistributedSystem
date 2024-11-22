using AspireDistributedSystem.ApiService.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace AspireDistributedSystem.ApiService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IdentityController : ControllerBase
{
    // TODO: For the love of God please use something like identity server or Okta or Azure AD to perform this 
    private const string TokenSecret = "ForTheLoveOfGodStoreAndLoadThisGuySecurely!";
    // TODO: Normally this would be for a much shorter lifespan but this is only a demo
    private static readonly TimeSpan TokenLifetime = TimeSpan.FromHours(8);

    [HttpPost("token")]
    public IActionResult GenerateToken([FromBody] TokenGenerationRequest request)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(TokenSecret);

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Sub, request.Email),
            new(JwtRegisteredClaimNames.Email, request.Email),
            new("userid", request.UserId.ToString()),
        };

        foreach (var claimPair in request.CustomClaims)
        {
            var jsonElement = (JsonElement)claimPair.Value;
            var valueType = jsonElement.ValueKind switch
            {
                JsonValueKind.True => ClaimValueTypes.Boolean,
                JsonValueKind.False => ClaimValueTypes.Boolean,
                JsonValueKind.Number => ClaimValueTypes.Double,
                _ => ClaimValueTypes.String
            };

            var claim = new Claim(claimPair.Key, claimPair.Value.ToString()!, valueType);
        }

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.Add(TokenLifetime),
            Issuer = "https://localhost:7322",
            Audience = "https://localhost:7216",
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        var jwt = tokenHandler.WriteToken(token);
        return Ok(jwt);
    }

}
