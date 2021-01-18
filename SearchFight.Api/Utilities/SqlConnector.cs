﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SearchFight.Api.Utilities
{
    public class SqlConnector
    {
        public static string strCadConexion
        {
            get
            {
                return Constantes.cnx_sql;
            }
        }

        public static DataSet getDataset(string spName, ArrayList alParametros)
        {
            SqlConnection conn = getConnection();
            SqlCommand cmd = getCommand(conn, spName, alParametros);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            conn.Close();
            return ds;
        }

        public static DataSet getDataset(string sql)
        {
            SqlConnection conn = getConnection();
            SqlCommand cmd = getCommand(conn, sql);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            conn.Close();
            return ds;
        }

        public static DataTable getDataTable(string spName, ArrayList alParametros)
        {
            try
            {
                SqlConnection conn = getConnection();
                SqlCommand cmd = getCommand(conn, spName, alParametros);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                conn.Close();
                return dt;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message.ToString());

            }

        }

        public static DataTable getDataTable(string sql)
        {
            SqlConnection conn = getConnection();
            SqlCommand cmd = getCommand(conn, sql);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            conn.Close();
            return dt;
        }


        public static object executeScalar(string sql, ArrayList alParametros)
        {
            SqlConnection conn = getConnection();
            SqlCommand cmd = getCommand(conn, sql, alParametros);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            object obj = cmd.ExecuteScalar();
            conn.Close();
            return obj;
        }

        public static int executeNonQuery(string spName, ArrayList alParametros)
        {
            SqlConnection conn = getConnection();
            SqlCommand cmd = getCommand(conn, spName, alParametros);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            int res = cmd.ExecuteNonQuery();
            conn.Close();
            return res;
        }

        public static SqlConnection getConnection()
        {
            string strcnx = getConnectionString();
            SqlConnection conn = new SqlConnection(strcnx);
            conn.Open();
            return conn;
        }

        public static string getConnectionString()
        {
            return Constantes.cnx_sql;
        }

        public static Hashtable getConnectionStringTable()
        {
            string[] parameters = getConnectionString().Split(';');
            string[] key_value;
            Hashtable table = new Hashtable(4);

            foreach (string parameter in parameters)
            {
                key_value = parameter.Trim().Split('=');
                table.Add(key_value[0].Trim().ToUpper(), key_value[1]);
            }
            return table;
        }


        private static SqlCommand getCommand(SqlConnection conn, string spName, ArrayList alParametros)
        {
            SqlCommand cmd = new SqlCommand(spName, conn);

            IEnumerator ieParametros = alParametros.GetEnumerator();
            while (ieParametros.MoveNext())
            {
                cmd.Parameters.Add((SqlParameter)ieParametros.Current);
            }
            return cmd;
        }

        private static SqlCommand getCommand(SqlConnection conn, string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            return cmd;
        }
    }
}
