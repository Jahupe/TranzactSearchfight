using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchFight.Api.Utilities
{
    public class Constantes
    {
        public static string server = "LIM-11GYM53";
        public static string database_name = "TranzactSearch";
        public static string database_user = "sa";
        public static string database_password = "Peru123.";

        public static string cnx_sql = "Data Source=" + server + "; Initial Catalog=" + database_name + "; User ID=" + database_user + "; password=" + database_password;

        public static string LOG_ERROR_ACTIVO = "1";
        public static string LOG_TRANSAC_ACTIVO = "1";
        public static string RUTA_LOG_ERROR = @"\LOG_ERRORES\";
        public static string RUTA_LOG_TRANSAC = @"\LOG_TRANSACCIONES\";
    }
}
