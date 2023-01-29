using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace kanbanApi.Helper
{
    public class Helper
    {

        public enum UserRoles
        {

            Leader,
            Member,
           
        }

        public static string DecodeToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            if (token == null)
                return null;
            var decoded = handler.ReadJwtToken(token.Replace("Bearer ", ""));

            return decoded.Claims.First(claim => claim.Type == "nameid").Value;
        }
    }
}
