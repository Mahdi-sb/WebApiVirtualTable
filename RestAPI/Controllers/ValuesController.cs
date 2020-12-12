using System.Collections.Generic;
using Infrastructure;
using Infrastructure.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Addvalue;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IAddValue _service;
        public ValuesController(IAddValue service)
        {
            _service = service;
        }


        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ActionResult<List<TypesDto>> GetTable(int id)
        {

            return Ok(_service.TableData(id));
        }

        // POST api/<ValuesController>
        [HttpPost]
        public ActionResult Post([FromBody] List<ValueDto> value)
        {
            var error = _service.AddToValueTable(value);
            return error != Massage.IsOk ? StatusCode(StatusCodes.Status500InternalServerError, error) : Ok(error);
        }


    }
}
