using Infrastructure.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using VirtualTable.Helper;
using VirtualTable.Mapper;

namespace VirtualTable.Controllers
{
    public class ShowInfoController : Controller
    {
       private readonly IApi _helper ;

        public ShowInfoController( IApi helper )
        {
            _helper = helper;
        }
        /// <summary>
        /// show data of table 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> ShowData(int id)
        {
            HttpClient client = _helper.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/Table/{id}");
            var result = res.Content.ReadAsStringAsync().Result;
            var values = JsonConvert.DeserializeObject<List<ValueDto>>(result);
            ViewData["column"] = Map.Types(values);
            return View(values);
        }

       
    }
}
