using exmainationApi.Models;

namespace exmainationApi.Services.localDb.Interfaces {
    public interface IUserData
    {
        Task<GeneralUser> verifyUser(string email, string password);
    }
}