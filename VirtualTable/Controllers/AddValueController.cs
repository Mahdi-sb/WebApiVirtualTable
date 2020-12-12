using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Infrastructure;
using Infrastructure.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VirtualTable.Helper;
using VirtualTable.Mapper;

namespace VirtualTable.Controllers
{
    public class AddValueController : Controller
    {
        private readonly IApi _helper;

        public AddValueController(IApi helper)
        {
            _helper = helper;
        }

        /// <summary>
        /// create page to choose table
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task< IActionResult> ChooseTable()
        {
            HttpClient client = _helper.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/Table");
            var result = res.Content.ReadAsStringAsync().Result;
            var values = JsonConvert.DeserializeObject<List<TableDto>>(result);
            return View(values);
        }

        /// <summary>
        /// seed data in database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task< IActionResult> SeedData(int id)
        {
            HttpClient client = _helper.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/values/{id}");
            var result = res.Content.ReadAsStringAsync().Result;
            var model = Map.TypeList(Map.TableData(result));
            return View(model);
        }
        [HttpPost]
        public async Task< IActionResult> SeedData(List<ValueDto> values, List<TypesDto> model)
        {
            model = Map.TypeList(values);
            
            
            if (ModelState.IsValid)
            { 
                HttpClient client = _helper.Initial();
                var error = await client.PostAsJsonAsync("api/Values", values);
                if (error.Content.ReadAsStringAsync().Result == Massage.IsOk) return RedirectToAction("Index", "Home");
                ViewData["ErrorMessage"] = error.Content.ReadAsStringAsync().Result;
                return View(model);
            }
            ViewData["ErrorMessage"] = Massage.FillFields;
            return View(model);
        }

    }
}
