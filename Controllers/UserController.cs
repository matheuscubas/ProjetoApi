using Dapper;
using DesafioDesafiante.Data;
using DesafioDesafiante.Models;
using DesafioDesafiante.Services;
using DesafioDesafiante.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioDesafiante.Controllers
{
    using BCrypt = BCrypt.Net.BCrypt;

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly TokenService _tokenService;
        private readonly DesafioDbContext _context;
        private readonly PasswordService _passwordService;
        private readonly ConnectionService _connection;

        public UserController(TokenService tokenService, DesafioDbContext context, PasswordService passwordService, ConnectionService connection)
        {
            _tokenService = tokenService;
            _context = context;
            _passwordService = passwordService;
            _connection = connection;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("[action]")]
        public async Task<ActionResult<User>> SignIn([FromBody] RegisterViewModel model)
        {
            var password = _passwordService.GeneratePassword();
            model.Password = password;

            var user = new User
            {
                Username = model.Name,
                RoleId = model.RoleId,
                Password = _passwordService.EncryptPassword(password)
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return Ok(new ActionResultViewModel<RegisterViewModel>(model));
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<string>> Login([FromBody] LoginViewModel model)
        {
            using var connection = _connection.Connection();
            var query = @$"SELECT 
                        Users.Username as [Username],
                        Users.[Password] as [Password],
                        Roles.[Name] as [Rolename]
                        FROM Users
                        JOIN Roles ON
                        Users.RoleId = Roles.Id
                        WHERE
                        Users.Username = @Username";
            
            var user = await connection.QueryFirstOrDefaultAsync<LoginUserViewModel>(query,new { Username = model.Username });

            //var user = userEnumerable;//.FirstOrDefault();

            //var user = await _context
            //    .Users
            //    .AsNoTracking()
            //    .Include(x => x.Role)
            //    .FirstOrDefaultAsync(x => x.Username == model.Username);

            //if(PasswordHasher.Verify(user.Password, model.Password))
            //{
            //    var token = _tokenService.GenerateToken(user);
            //    return Ok(new LoginResultViewModel(user.Username, token));
            //}

            if (_passwordService.IsCorrectPassword(model.Password, user))
            {
                var token = _tokenService.GenerateToken(user);
                return Ok(new LoginResultViewModel(user.Username, token));
            }

            return BadRequest(new ActionResultViewModel<dynamic>("Algo de errado não está certo"));
        }
    }
}
