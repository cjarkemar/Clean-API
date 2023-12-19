using System.Text;

namespace API.Helpers
{
    public class SecretKeyHelper
    {
        public static byte[] GetSecretKey(IConfiguration configuration)
        {
            var secretKey = configuration["JwtSettings:Key"];

            if (string.IsNullOrEmpty(secretKey))
            {
                throw new InvalidOperationException("JwtSettings:Key is probably missing or invalid in appsettings.json.");
            }

            return Encoding.ASCII.GetBytes(secretKey);
        }
    }
}