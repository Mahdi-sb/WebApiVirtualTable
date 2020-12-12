using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using VirtualTable.Helper;
using VirtualTable.Mapper;
using VirtualTable.ViewModel;

namespace VirtualTable.Controllers
{
    public class NewTableController : Controller
    {
        private readonly IApi _helper;
        public NewTableController(IApi helper)
        {
            _helper = helper;
        }



        [HttpGet]
        public IActionResult AddNewTable()
        {
            var table = new TableView();
            return View(table);
            
        }

        [HttpPost]
        public async Task<IActionResult> AddNewTable(TableView model)
        {
            HttpClient client = _helper.Initial();
            var tb = Map.Table(model);
            var resualt= await client.PostAsJsonAsync("api/Table",tb);
            if (!ModelState.IsValid) return View("AddNewTable", model);
            if (resualt.Content.ReadAsStringAsync().Result == Massage.IsOk) return RedirectToAction("Index", "Home");
            ViewData["ErrorMessage"] = resualt.Content.ReadAsStringAsync().Result;
            return View("AddNewTable", model);
        }


    }
}