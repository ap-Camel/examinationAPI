using System.IdentityModel.Tokens.Jwt;

namespace exmainationApi.Heplers {
    public static class JwtHelpers {
        public static int getSpecificID(string token) {
            string tokenHash = token.Split(" ")[1];

            var newToken = new JwtSecurityToken(tokenHash);
            int userId = int.Parse(newToken.Claims.First(x => x.Type == "specificID").Value);

            return userId;
        }

        public static int getGeneralID(string token) {
            string tokenHash = token.Split(" ")[1];

            var newToken = new JwtSecurityToken(tokenHash);
            int userId = int.Parse(newToken.Claims.First(x => x.Type == "ID").Value);

            return userId;
        }
    }
}