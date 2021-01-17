using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchFight.Api.Utilities
{
    public class Constantes
    {
        public static string server = "34.71.88.53";
        public static string database_name = "TranzactSearch";
        public static string database_user = "sqlserver";
        public static string database_password = "Peru123.";

        public static string cnx_sql = "Data Source=" + server + "; Initial Catalog=" + database_name + "; User ID=" + database_user + "; password=" + database_password;

        public static string LOG_ERROR_ACTIVO = "1";
        public static string LOG_TRANSAC_ACTIVO = "1";
        public static string RUTA_LOG_ERROR = @"\LOG_ERRORES\";
        public static string RUTA_LOG_TRANSAC = @"\LOG_TRANSACCIONES\";
    }
}
