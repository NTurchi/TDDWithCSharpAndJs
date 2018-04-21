using API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly UserProfileService _service;

        public UserProfileController(UserProfileService service)
        {
            _service = service;
        }

        public IActionResult LogonUser(string username, string password)
        {
            var user = _service.GetUserProfile(username);

            if (user != null && _service.IsUserPasswordValid(user, password))
            {
                return Ok();
            }

            return Unauthorized();
        }
    }
}
