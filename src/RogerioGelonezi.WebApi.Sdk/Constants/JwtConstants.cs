using Microsoft.Extensions.Configuration;

namespace RogerioGelonezi.WebApi.Sdk.Constants
{
    public static class JwtConstants
    {
        private const string JwtSecret = "My-aW3S0M3-JWT-$Ecret";
        private const string JwtSecretEnvironmentVariable = "JwtSecret";

        public static string GetJwtSecret(IConfiguration configuration)
        {
            return configuration[JwtSecretEnvironmentVariable] ?? JwtSecret;
        }
    }
}
