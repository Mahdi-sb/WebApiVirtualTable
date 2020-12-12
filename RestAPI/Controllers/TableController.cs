using Infrastructure;
using Infrastructure.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.AddNewTable;
using Service.Addvalue;
using Service.ShowInformation;
using VirtualTable.Mapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : Apicontroller
    {
        private readonly IAddValue _show;
        private readonly IShowInfo _info;
        private readonly IAddTable _add;
        public TableController(IAddValue show ,IShowInfo info,IAddTable add)
        {
            _show = show;
            _info = info;
            _add = add;
        }
        [HttpGet]
        public ActionResult<TableDto> GetAllTable()
        {
            return Ok(Map.TableList(_show.AllTable()));
        }

        [HttpGet("{id}")]
        public  ActionResult<ValueDto> GetTable(int id)
        {

             return Ok( Map.ValueList(_info.ValueOfTable(id)));
        }

        //[HttpGet("{id}")]
        //public ActionResult<List<TypesDto>> Get(int id)
        //{
        //    var fake = Map.TypeList(_show.TableData(id));
        //    return Ok(fake);
        //}

        [HttpPost]
        public ActionResult Post([FromBody]TableInfo table)
        {
            var error=_add.AddInformationToDatabase(table.TableName,Map.TypeList(table));
            return error!=Massage.IsOk ? StatusCode(StatusCodes.Status500InternalServerError,error) : Ok(error);
        }













    //// GET: api/<TableController>
    //[HttpGet]
    //public IEnumerable<string> Get()
    //{
    //    return new string[] { "value1", "value2" };
    //}

    //// GET api/<TableController>/5
    //[HttpGet("{id}")]
    //public string Get(int id)
    //{
    //    return "value";
    //}

    //// POST api/<TableController>
    //[HttpPost]
    //public void Post([FromBody] string value)
    //{
    //}

    //// PUT api/<TableController>/5
    //[HttpPut("{id}")]
    //public void Put(int id, [FromBody] string value)
    //{
    //}

    // DELETE api/<TableController>/5
    // [HttpDelete("{id}")]
    // public void Delete(int id)
    // {
    // }
}
}
