using AutoMapper;
using Core.Interfaces;
using Core.Models.Account;
using Core.Services;
using Core.Validators.Account;
using Core.Validators.City;
using Domain;
using Domain.Entities;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApiTransfer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController(
        UserManager<UserEntity> userManager,
        IJwtTokenService jwtTokenService,
        IAccountService accountService,
        AppDbTransferContext context,
        IUserService userService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {

            var validator = new AccountLoginValidator(userManager);
            var validationResult = await validator.ValidateAsync(model);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToArray();
                return BadRequest(new { errors });
            }

            var user = await userManager.FindByEmailAsync(model.Email);

            var token = await jwtTokenService.CreateAsync(user);
            return Ok(new { token });
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm] RegisterModel model)
        {
            if(model == null)
                return BadRequest("Виникли помилки при реєстрації");

            var validator = new AccountRegisterValidator(context);
            var validationResult = await validator.ValidateAsync(model);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToArray();
                return BadRequest(new { errors });
            }

            var item = await accountService.CreateAsync(model);

            return Ok(item);
        }

        [HttpGet]
        [Authorize]

        public async Task<IActionResult> GetProfile()
        {
            var model = await userService.GetUserProfileAsync();
            return Ok(model);
        }

    }
}
