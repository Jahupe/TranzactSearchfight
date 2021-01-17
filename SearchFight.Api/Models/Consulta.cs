using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchFight.Api.Models
{
    public class Consulta
    {
        public int id_consulta { get; set; } = 0;
        public string engine { get; set; } = " ";
        public string language { get; set; } = "";

        public int resultado { get; set; } = 0;
    }
}
