using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SearchFight.Cliente.Models;

namespace SearchFight.Cliente.Controllers
{
    public class ResultadoController : Controller
    {
        private string url = "";
        public IActionResult Index()
        {
            string buscar = Request.Query["busqueda"];
            url = Constantes.api_url + "/api/Resultado/" + buscar;
            List<Consulta> oList = new List<Consulta>();
            string res = ApiCaller.consume_endpoint_method(url, null, "GET");
            oList = JsonConvert.DeserializeObject<List<Consulta>>(res);
            return View("Index", oList);
        }
    }
}
