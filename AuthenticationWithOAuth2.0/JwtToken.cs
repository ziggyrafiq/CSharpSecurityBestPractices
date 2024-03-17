using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace AuthenticationWithOAuth2._0
{
    public static class JwtToken
    {
        public static string GenerateJwtToken(string username, int userId)
        {
            // Set the secret key used to sign the token (should be stored securely in production)
            string secretKey = "our_secret_key_here";
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            // Set the signing credentials
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Create the claims for the user (we can include additional claims as needed)
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.NameIdentifier, userId.ToString())
        };

            // Generate the token
            var token = new JwtSecurityToken(
                issuer: "our_issuer",
                audience: "our_audience",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1), // Token expiration time
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
