using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SearchFight.Api.Connection;
using SearchFight.Api.Models;
using SearchFight.Api.Utilities;

namespace SearchFight.Api.Controllers
{
    //[ApiController]
    //[Route("api/[controller]")]
    public class ConsultaController : ControllerBase
    {
        private readonly IWebHostEnvironment _host;
        private string main_path;

        public ConsultaController(IWebHostEnvironment host)
        {
            this._host = host;
            main_path = _host.ContentRootPath;
        }

        ConsultaConnection con = new ConsultaConnection();
        RandomUtilities ru = new RandomUtilities();


        List<Consulta> lista = new List<Consulta>();

        string random_str = "";

        // GET api/values
        [HttpGet("{language_value}")]
        public ActionResult<List<Consulta>> Get(string language_value)
        {
            random_str = ru.RandomString(8) + "|" + ru.CurrentDate();

            try
            {

                lista = con.Consulta( language_value);
            }
            catch (Exception e)
            {             
                //LOG.registrarLog("(Output " + random_str + ")[DATA]->[MenuController.cs / listar_menu <> json_error: " + JsonConvert.SerializeObject(oRespuesta), "TRANSAC", main_path);
            }
            return lista;
        }
    }
}
