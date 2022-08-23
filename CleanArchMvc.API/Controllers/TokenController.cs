﻿using CleanArchMvc.API.Models;
using CleanArchMvc.Domain.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {

        private readonly IAuthenticate _authentication;
        public TokenController(IAuthenticate authentication)
        {
            _authentication = authentication;
        }

        [HttpPost("LoginUser")]
        public async Task<ActionResult<UserToken>> Login([FromBody] LoginModel userInfo)
        {
            var result = await _authentication.Authenticate(userInfo.Email, userInfo.Password);

            if (result)
            {
                //return GenerateToken(userInfo);
                return Ok($"User {userInfo.Email} login successfully");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid Login attempt.");
                return BadRequest(ModelState);
            }
        }

        [HttpPost("CreateUser")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult> CreateUser([FromBody] LoginModel userInfo)
        {
            var result = await _authentication.RegisterUser(userInfo.Email, userInfo.Password);

            if (result)
            {
                //return GenerateToken(userInfo);
                return Ok($"User {userInfo.Email} was created successfully");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid Login attempt.");
                return BadRequest(ModelState);
            }
        }



    }
}
