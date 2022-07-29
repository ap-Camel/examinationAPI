using System.Security.Cryptography;
using System.Text;
using exmainationApi.Dtos;
using exmainationApi.Models;
using exmainationApi.Services.localDb.Interfaces;
using exmainationApi.Heplers;
using exmainationApi.Dtos.UserDtos;

namespace exmainationApi.Services.localDb.Tables {    

    public class UserData : IUserData
    {
        private readonly ISqlDataAccess _db;

        public UserData(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<GeneralUser> verifyUserAsync(string email, string password)
        {

            string hashedPass = await Hashing.hash(password);

            string sql = $"select top 1 * from generalUser where email = '{email}' and userPassword = '{hashedPass}'";

            return await _db.LoadSingle<GeneralUser>(sql);
        }


        public async Task<GeneralUser> checkForEmailAsync(string email) {
            string sql = $"select top 1 * from generalUser where email = '{email}'";

            return await _db.LoadSingle<GeneralUser>(sql);
        }


        public async Task<int> insertUser(UserSignupDto user) {
            string sql = $"insert into generalUser output inserted.ID values ('{user.firstName}', '{user.lastName}', '{user.userRole}', '{user.email}', default, '{user.email}', '{await Hashing.hash(user.password)}', default, default, null)";

            return await _db.insertDataWithReturn(sql);
        }

        public async Task<GeneralUser> getUser(string username) {
            string sql = $"select top 1 * from generalUser where username = '{username}'";

            return await _db.LoadSingle<GeneralUser>(sql);
        }

        public async Task<bool> deleteUserAsync(int id) {
            string sql = $"delete from generalUser where ID = {id}";

            return await _db.insertData(sql);
        }
    }
}