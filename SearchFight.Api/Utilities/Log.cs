﻿
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SearchFight.Api.Utilities
{
    public class Log
    {
        #region Propiedades

        public static void registrarLog(string msg, string tipoLog, string main_path)
        {
            string LOG_ACTIVO = "";
            string RUTA_LOG = "";
            if (tipoLog == "ERROR")
            {
                LOG_ACTIVO = Constantes.LOG_ERROR_ACTIVO;
                RUTA_LOG = Constantes.RUTA_LOG_ERROR;
            }
            else if (tipoLog == "TRANSAC")
            {
                LOG_ACTIVO = Constantes.LOG_TRANSAC_ACTIVO;
                RUTA_LOG = Constantes.RUTA_LOG_TRANSAC;
            }

            if (LOG_ACTIVO == "1")
            {
                string path = main_path + RUTA_LOG;

                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }
                //Log.Write(path + "log-", msg);
            }
        }

        public static Int16 registrosPorPagina()
        {
            return 10;
        }

        #endregion Propiedades

        public static String fnCambiarCaracteres(String psCadena)
        {
            psCadena = psCadena.Replace("á", "&aacute;");
            psCadena = psCadena.Replace("é", "&eacute;");
            psCadena = psCadena.Replace("í", "&iacute;");
            psCadena = psCadena.Replace("ó", "&oacute;");
            psCadena = psCadena.Replace("ú", "&uacute;");
            psCadena = psCadena.Replace("ñ", "&#241;");
            psCadena = psCadena.Replace("Á", "&Aacute;");
            psCadena = psCadena.Replace("É", "&Eacute;");
            psCadena = psCadena.Replace("Í", "&Iacute;");
            psCadena = psCadena.Replace("Ó", "&Oacute;");
            psCadena = psCadena.Replace("Ú", "&Uacute;");
            psCadena = psCadena.Replace("Ñ", "&#209;");
            return psCadena;
        }
    }
}
