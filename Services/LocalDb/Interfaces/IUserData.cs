using exmainationApi.Dtos;
using exmainationApi.Models;

namespace exmainationApi.Services.localDb.Interfaces {
    public interface IUserData
    {
        Task<GeneralUser> verifyUserAsync(string email, string password);
        Task<GeneralUser> checkForEmailAsync(string email);
        Task<int> insertUser(UserSignupDto user);
        Task<GeneralUser> getUser(string username);
        Task<bool> deleteUserAsync(int id);
    }
}