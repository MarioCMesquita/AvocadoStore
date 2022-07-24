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
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public ActionResult Get(int id = 0)
        {
            try
            {
                if (id > 0)
                {

                    ProductEntity result = new ProductRepository().GetById(id);
                    return result != null ? Ok(result) : StatusCode(404, "Nenhum resultado encontrado!");
                }
                else
                {
                    if (User.IsInRole("Admin"))
                    {
                        List<ProductEntity> result = new ProductRepository().GetAll();
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

        [HttpGet]
        [Route("ProductsView")]
        [Authorize(Roles = "Admin")]
        public ActionResult GetProductsView()
        {
            try
            {
                var result = new ProductRepository().GetProductsView();
                return result != null ? Ok(result) : StatusCode(404, "Nenhum resultado encontrado!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro: {ex}");
            }
        }
    }
}
