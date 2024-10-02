using Entities.DTO;
using Microsoft.AspNetCore.Mvc;
using Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public AuthController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
        {
            try
            {
                await _userServices.RegisterAsync(userRegisterDto.Username, userRegisterDto.Email, userRegisterDto.Password);
                return Ok("Kayıt Başarılı");
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
        {
            try
            {
                var token = await _userServices.LoginAsync(loginDto.Email, loginDto.Password);
                return Ok(new { Token = token });

            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
