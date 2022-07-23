using exmainationApi.Dtos;
using exmainationApi.Models;
using exmainationApi.Services.localDb.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace exmainationApi.Controllers {
    [ApiController]
    [Route("user")]
    [Authorize]
    public class UserController {
        private readonly IUserData userData;

        public UserController(IUserData userData) {
            this.userData = userData;
        }
    }
}