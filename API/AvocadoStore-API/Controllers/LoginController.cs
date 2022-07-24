using AvocadoStore_API.Entities;
using AvocadoStore_API.Repository;
using AvocadoStore_API.Services.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AvocadoStore_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Post(string login, string password)
        {
            try
            {
                UserEntity user = new LoginRepository().Login(login, password);

                if (user != null)
                {
                    return Ok(new {
                        UserData = user,
                        Token = TokenService.GenerateToken(user)
                    });
                }

                return StatusCode(403, "Credenciais inválidas!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro: {ex}");
            }
        }
    }
}
