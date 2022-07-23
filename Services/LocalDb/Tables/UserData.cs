using System.Security.Cryptography;
using System.Text;
using exmainationApi.Models;
using exmainationApi.Services.localDb.Interfaces;

namespace exmainationApi.Services.localDb.Tables {    

    public class UserData : IUserData
    {
        private readonly ISqlDataAccess _db;

        public UserData(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<GeneralUser> verifyUser(string email, string password)
        {

            StringBuilder Sb = new StringBuilder();

            using (SHA256 myHash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = await myHash.ComputeHashAsync(new MemoryStream(enc.GetBytes(password)));

                foreach (Byte b in result)
                {
                    Sb.Append(b.ToString("x2"));
                }
            }

            string sql = $"select top 1 * from generalUser where email = {email} and password = {Sb}";

            return await _db.LoadSingle<GeneralUser>(sql);
        }
    }
}