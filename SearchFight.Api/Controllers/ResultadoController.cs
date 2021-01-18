using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SearchFight.Api.Connection;
using SearchFight.Api.Models;
using SearchFight.Api.Utilities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SearchFight.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultadoController : ControllerBase
    {

        private readonly IWebHostEnvironment _host;
        private string main_path;

        public ResultadoController(IWebHostEnvironment host)
        {
            this._host = host;
            main_path = _host.ContentRootPath;
        }

        ConsultaConnection con = new ConsultaConnection();
        RandomUtilities ru = new RandomUtilities();


        List<Consulta> lista = new List<Consulta>();

        string random_str = "";

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{language_value}")]
        public ActionResult<List<Consulta>> Get(string language_value)
        {
            random_str = ru.RandomString(8) + "|" + ru.CurrentDate();

            try
            {
                lista = con.Consulta(language_value);
            }
            catch (Exception e)
            {

            }
            return lista;
        }

        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
