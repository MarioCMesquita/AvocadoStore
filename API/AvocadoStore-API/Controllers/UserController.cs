using AvocadoStore_API.Entities;
using AvocadoStore_API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AvocadoStore_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public ActionResult Get(int id = 0)
        {
            try
            {
                if (id > 0)
                {
                    
                    UserEntity result = new UserRepository().GetById(id);
                    return result != null ? Ok(result) : StatusCode(404, "Nenhum resultado encontrado!");
                }
                else
                {
                    if (User.IsInRole("Admin"))
                    {
                        List<UserEntity> result = new UserRepository().GetAll();
                        return result != null ? Ok(result) : StatusCode(404, "Nenhum resultado encontrado!");
                    }
                    return Forbid();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro: {ex}");
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Save([FromBody] UserEntity body)
        {
            try
            {
                new UserRepository().Save(body);
                return Ok("Salvo com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro: {ex}");
            }
        }

        [HttpPut]
        [Authorize(Roles = "Admin, User")]
        public ActionResult Update([FromBody] UserEntity body)
        {
            try
            {
                new UserRepository().Update(body);
                return Ok("Usuário alterado com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro: {ex}");
            }
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id, int cd_user)
        {
            try
            {
                new UserRepository().Delete(id, cd_user);
                return Ok("Deletado com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro: {ex}");
            }
        }
    }
}
