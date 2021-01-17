using SearchFight.Api.Models;
using SearchFight.Api.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SearchFight.Api.Connection
{
    public class ConsultaConnection
    {
        SqlConnection cn = new SqlConnection(SqlConnector.strCadConexion);
        string rpta = "";

        public List<Consulta> Consulta(string language_value)
        {
            List<Consulta> ConsultaRpta = new List<Consulta>();
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(Procedures.sp_listar_consulta_engine, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@engine", SqlDbType.Int).Value = engine;
                cmd.Parameters.Add("@language_value", SqlDbType.VarChar).Value = language_value;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ta = new DataTable();
                da.Fill(ta);

                foreach (DataRow row in ta.Rows)
                {
                    Consulta oConsulta = new Consulta();
                    oConsulta.id_consulta = Convert.ToInt32(row["id_consulta"]);
                    oConsulta.engine = Convert.ToString(row["engine"]);
                    oConsulta.language = Convert.ToString(row["language"]);
                    oConsulta.resultado = Convert.ToInt32(row["resultado"]);
                    ConsultaRpta.Add(oConsulta);
                }
            }
            catch (Exception e)
            {
                //LOG.registrarLog("(Excepcion " + random_str + ")[ERROR]->[ReporteConnection.cs / reporte_nps <> " + e.Message.ToString(), "ERROR", main_path);
                rpta = "Ocurrió un error generar el reporte " + e.Message;
            }
            cn.Close();
            return ConsultaRpta;
        }
    }
}
