using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.DTO;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Entities;
using System;

namespace Restaurant.Services.Api.Controllers
{
    [Route("api/[controller]")]
    public class ControllerBase<Entity, EntityDTO> : Controller
        where Entity : EntityBase
        where EntityDTO : DTOBase
    {
        readonly protected IAppBase<Entity, EntityDTO> app;

        public ControllerBase(IAppBase<Entity, EntityDTO> app)
        {
            this.app = app;
        }

        [HttpGet]
        [Route("")]
        public IActionResult List()
        {
            try
            {
                var restaurants = app.GetAll();
                return new OkObjectResult(restaurants);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var restaurants = app.GetById(id);
                return new OkObjectResult(restaurants);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("")]
        public IActionResult Insert([FromBody] EntityDTO data)
        {
            try
            {
                return new OkObjectResult(app.Insert(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        [Route("")]
        public IActionResult Update([FromBody] EntityDTO data)
        {
            try
            {
                app.Update(data);
                return new OkObjectResult(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }


        [HttpDelete]
        [Route("id")]
        public IActionResult Delete(int id)
        {
            try
            {
                app.Delete(id);
                return new OkObjectResult(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
    }
}
