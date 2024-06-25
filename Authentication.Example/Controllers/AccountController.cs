using Authentication.Example.Data;
using Authentication.Example.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Authentication.Example.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly AppDbContext _context;

    private readonly ILogger<AccountController> _logger;

    private readonly IConfiguration _configuration;

    private readonly UserManager<AppUser> _userManager;

    private readonly SignInManager<AppUser> _signInManager;

    public AccountController(
        AppDbContext context,
        ILogger<AccountController> logger,
        IConfiguration configuration,
        UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager)
    {
        _context = context;
        _logger = logger;
        _configuration = configuration;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpPost]
    public async Task<ActionResult> Register(RegisterDTO input)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var newUser = new AppUser
                {
                    UserName = input.UserName,
                    Email = input.Email
                };
                var result = await _userManager.CreateAsync(
                    newUser, input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation(
                        $"User {newUser.UserName} ({newUser.Email}) has been created.",
                        newUser.UserName, newUser.Email);
                    return StatusCode(201,
                        $"User '{newUser.UserName}' has been created.");
                }
                else
                    throw new Exception(
                        string.Format("Error: {0}", string.Join(" ",
                            result.Errors.Select(e => e.Description))));
            }
            else
            {
                var details = new ValidationProblemDetails(ModelState);
                details.Status = StatusCodes.Status400BadRequest;
                return new BadRequestObjectResult(details);
            }
        }
        catch (Exception e)
        {
            var exceptionDetails = new ProblemDetails();
            exceptionDetails.Detail = e.Message;
            exceptionDetails.Status =
                StatusCodes.Status500InternalServerError;
            return StatusCode(
                StatusCodes.Status500InternalServerError,
                exceptionDetails);
        }
    }

    [HttpPost]
    public async Task<ActionResult> Login(LoginDTO input)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(input.UserName);
                if (user == null
                    || !await _userManager.CheckPasswordAsync(
                           user, input.Password))
                    throw new Exception("Invalid login attempt.");
                else
                {
                    var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                            System.Text.Encoding.UTF8.GetBytes(
                                _configuration["JWT:SigningKey"])),
                        SecurityAlgorithms.HmacSha256);

                    var claims = new List<Claim>();
                    claims.Add(new Claim(
                        ClaimTypes.Name, user.UserName));

                    var userRoles = (await _userManager.GetRolesAsync(user)).ToList();
                    foreach (var userRole in userRoles)
                        claims.Add(new Claim(ClaimTypes.Role, userRole));

                    var jwtObject = new JwtSecurityToken(
                        issuer: _configuration["JWT:Issuer"],
                        audience: _configuration["JWT:Audience"],
                        claims: claims,
                        expires: DateTime.Now.AddSeconds(300),
                        signingCredentials: signingCredentials);

                    var jwtString = new JwtSecurityTokenHandler()
                .WriteToken(jwtObject);

                    return StatusCode(
                StatusCodes.Status200OK, jwtString);
                }
            }
            else
            {
                var details = new ValidationProblemDetails(ModelState);
                details.Status = StatusCodes.Status400BadRequest;
                return new BadRequestObjectResult(details);
            }
        }
        catch (Exception e)
        {
            var exceptionDetails = new ProblemDetails();
            exceptionDetails.Detail = e.Message;
            exceptionDetails.Status =
                StatusCodes.Status401Unauthorized;
            return StatusCode(
                StatusCodes.Status401Unauthorized,
                exceptionDetails);
        }

    }
}
