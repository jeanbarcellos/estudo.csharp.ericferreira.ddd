using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.DTO;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Interfaces.Services;
using System;

namespace Restaurant.Services.Api.Controllers
{
    [Route("api/[controller]")]
    abstract public class ControllerBase<Entity, EntityDTO> : Controller
        where Entity : EntityBase
        where EntityDTO : DTOBase
    {
        readonly protected IAppServiceBase<Entity, EntityDTO> _appService;

        public ControllerBase(IAppServiceBase<Entity, EntityDTO> appService)
        {
            _appService = appService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAll([FromServices] IDishService service)
        {
            try
            {
                var restaurants = _appService.GetAll();

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
                var restaurants = _appService.GetById(id);

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
                return new OkObjectResult(_appService.Insert(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromBody] EntityDTO data)
        {
            try
            {
                _appService.Update(data);

                return new OkObjectResult(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }


        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _appService.Delete(id);

                return new OkObjectResult(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
    }
}
