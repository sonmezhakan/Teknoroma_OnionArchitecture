using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Teknoroma.Application.DTOs.AccountDTOs;
using Teknoroma.Application.Features.AppUsers.Queries.GetByUserName;
using Teknoroma.Application.ViewModel;
using Teknoroma.Domain.Entities;

namespace Teknoroma.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<AppUser> _signInManager;

        //todo:employee işlemleri yapılacak

        public UserController(IMapper mapper, UserManager<AppUser> userManager,IConfiguration configuration,SignInManager<AppUser> signInManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
            _signInManager = signInManager;
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            AppUser appUser = _mapper.Map<AppUser>(registerDTO);
            //EmployeeDTO employeeDto = _mapper.Map<EmployeeDTO>(registerDTO);
            
            if (_userManager.FindByEmailAsync(appUser.Email).Result != null) return BadRequest("Bu Email bulunmaktadır!");

            if (_userManager.FindByNameAsync(appUser.UserName).Result != null) return BadRequest("Bu user name bulunmaktadır!");

            /*if (_employeeService.AnyPhoneNumber(appUser.PhoneNumber).Result == true) return BadRequest("Bu phone number bulunmaktadır!");*/

            
            var resultUser = await _userManager.CreateAsync(appUser, registerDTO.Password);

            if (resultUser.Succeeded)
            {
                try
                {
                    await _userManager.AddToRoleAsync(appUser, "Member");
                }
                catch (Exception)
                {

                    throw;
                }

                /*employeeDto.ID = _userManager.FindByNameAsync(appUser.UserName).Result.Id;
                await _employeeService.Add(employeeDto);*/

                return Ok();
            }

            return BadRequest("kayıt olamadı");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            
            if (_userManager.FindByNameAsync(loginDTO.UserName).Result == null) return BadRequest("Bu user name bulunamadı!");  

            AppUser appUser = _userManager.FindByNameAsync(loginDTO.UserName).Result;

            if(_userManager.CheckPasswordAsync(appUser, loginDTO.Password).Result == false) return BadRequest("Şifre hatalı!");
            
            var token = GetJwtToken(appUser);
            return Ok(token);
        }

        [HttpGet("{userName}")]
        public async Task<IActionResult> GetByUserName(string userName)
        {
            var result = await Mediator.Send(new GetByUserNameAppUserQueryRequest { UserName = userName});
            return Ok(result);
        }


        private string GetJwtToken(AppUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JWT:ExpireDays"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: expires,
                signingCredentials: credentials
                );

            var result = new JwtSecurityTokenHandler().WriteToken(token);
            return result;
        }
    }
}
