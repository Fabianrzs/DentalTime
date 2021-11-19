using BLL;
using DAL;
using DentalTime.Config;
using DentalTime.Models;
using DentalTime.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalTime.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private JwtService _jwtService;
        private UserService _userService;

        public LoginController(DentalTimeContext context, IOptions<AppSetting> appSettings)
        {
            //var admin = _context.Users.Find("admin");
            //if (admin == null)
            //{
            //    _context.Users.Add(new Entity.User() { UserName = "admin", Password = "admin", Email = "admin@gmail.com", Estado = "AC", FirstName = "Adminitrador", LastName = "", MobilePhone = "31800000000" });
            //    var i = _context.SaveChanges();
            //}
            _jwtService = new JwtService(appSettings);
            _userService = new UserService(context);
        }

        [AllowAnonymous]
        [HttpPost()]
        public IActionResult Login(LoginInputModel model)
        {
            var user = _userService.Validate(model.UserName, model.Password);
            if (user == null)
            {
                ModelState.AddModelError("Acceso Denegado", "Username or password is incorrect");
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            var response = _jwtService.GenerateToken(user);
            return Ok(response);
        }


    }
}
