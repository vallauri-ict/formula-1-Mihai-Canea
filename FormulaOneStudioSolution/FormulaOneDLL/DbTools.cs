﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDLL
{
    public class DbTools
    {

        public void ExecuteSqlScript(string sqlScriptName)
        {
            string WORKINGPATH = $@"C:\Users\{Environment.UserName}\Documents\MSSQLDatabase\FormulaOne\";

            var fileContent = File.ReadAllText(WORKINGPATH + sqlScriptName);
            fileContent = fileContent.Replace("\r\n", "");
            fileContent = fileContent.Replace("\r", "");
            fileContent = fileContent.Replace("\n", "");
            fileContent = fileContent.Replace("\t", "");
            var sqlqueries = fileContent.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

            var con = new SqlConnection($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={WORKINGPATH}FormulaOneStudioDB.mdf;Integrated Security=True");
            var cmd = new SqlCommand("query", con);
            con.Open(); int i = 0;
            foreach (var query in sqlqueries)
            {
                cmd.CommandText = query; i++;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException err)
                {
                    Console.WriteLine("Errore in esecuzione della query numero: " + i);
                    Console.WriteLine("\tErrore SQL: " + err.Number + " - " + err.Message);
                }
            }
            con.Close();
        }

        public List<CardDriverDLL> LoadDrivers(string year)
        {
            string WORKINGPATH = $@"C:\Users\{Environment.UserName}\Documents\MSSQLDatabase\FormulaOne\";
            List<CardDriverDLL> retVal = new List<CardDriverDLL>();
            var con = new SqlConnection($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={WORKINGPATH}FormulaOneStudioDB.mdf;Integrated Security=True");
            using (con)
            {
                SqlCommand command = new SqlCommand(
                  "SELECT DISTINCT drivers.PathImgSmall, drivers.forename, drivers.surname, constructors.name " +
                  "FROM drivers, races, results, constructors " +
                  "WHERE drivers.driverId = results.driverId " +
                  "AND races.raceId = results.raceId " +
                  "AND results.constructorId = constructors.constructorId " +
                  $"AND races.year = {year} " +
                  "ORDER BY drivers.surname ASC",
                  con);
                con.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    try
                    {
                        CardDriverDLL card = new CardDriverDLL(
                        reader.GetString(0),
                        $"{reader.GetString(1)} {reader.GetString(2)}",
                        reader.GetString(3)
                        );
                        retVal.Add(card);
                    }
                    catch (Exception)
                    {
                        //CardDriverDLL card = new CardDriverDLL(
                        //reader.GetString(0),
                        //reader.GetString(1),
                        //"null"
                        //);
                        //retVal.Add(card);
                    }


                }
                reader.Close();
            }
            return retVal;
        }
        public List<TableDriverDLL> LoadTableDrivers(string year)
        {
            string WORKINGPATH = $@"C:\Users\{Environment.UserName}\Documents\MSSQLDatabase\FormulaOne\";
            List<TableDriverDLL> retVal = new List<TableDriverDLL>();
            var con = new SqlConnection($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={WORKINGPATH}FormulaOneStudioDB.mdf;Integrated Security=True");
            using (con)
            {
                SqlCommand command = new SqlCommand(
                  "SELECT DISTINCT drivers.forename, drivers.surname, drivers.number, drivers.dob, drivers.nationality, drivers.url " +
                  "FROM drivers, races, results " +
                  "WHERE drivers.driverId = results.driverId " +
                  "AND races.raceId = results.raceId " +
                  $"AND races.year = {year} " +
                  "ORDER BY drivers.surname ASC",
                  con);
                con.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    try
                    {
                        TableDriverDLL card = new TableDriverDLL(
                            reader.GetString(0),
                            reader.GetString(1),
                            reader.GetInt32(2),
                            reader.GetDateTime(3).Date.ToShortDateString(),
                            reader.GetString(4),
                            reader.GetString(5)
                        );
                        retVal.Add(card);
                    }
                    catch (Exception)
                    {
                        TableDriverDLL card = new TableDriverDLL(
                            reader.GetString(0),
                            reader.GetString(1),
                            0,
                            reader.GetDateTime(3).Date.ToShortDateString(),
                            reader.GetString(4),
                            reader.GetString(5)
                        );
                        retVal.Add(card);
                    }


                }
                reader.Close();
            }
            return retVal;
        }

        public List<CircuitsDLL> LoadTableCircuits(string year)
        {
            string WORKINGPATH = $@"C:\Users\{Environment.UserName}\Documents\MSSQLDatabase\FormulaOne\";
            List<CircuitsDLL> retVal = new List<CircuitsDLL>();
            var con = new SqlConnection($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={WORKINGPATH}FormulaOneStudioDB.mdf;Integrated Security=True");
            using (con)
            {
                SqlCommand command = new SqlCommand(
                  "SELECT circuits.name, circuits.location , circuits.country, races.url " +
                  "FROM circuits " +
                  "JOIN races " +
                  "ON circuits.circuitId = races.circuitId " +
                  $"AND races.year = {year} ",
                  //"ORDER BY drivers.surname ASC",
                  con);
                con.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CircuitsDLL circuit = new CircuitsDLL(
                        reader.GetString(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3)
                    );
                    retVal.Add(circuit);
                }
                reader.Close();
            }
            return retVal;
        }

        // ------------------------------------------------------------------
        // ASP
        // ------------------------------------------------------------------
        public DataTable LoadTableDrivers()
        {
            string WORKINGPATH = $@"C:\Users\{Environment.UserName}\Documents\MSSQLDatabase\FormulaOne\";
            DataTable dt = new DataTable();
            var con = new SqlConnection($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={WORKINGPATH}FormulaOneStudioDB.mdf;Integrated Security=True");
            using (con)
            {
                SqlCommand command = new SqlCommand(
                  "SELECT * FROM drivers ORDER BY forename ASC;",
                  con);
                con.Open();

                //SqlDataReader reader = command.ExecuteReader();
                dt = EseguiQuery(command);
                return dt;
            }
        }

        /// <summary>
        /// Esegue una query che ritorna un dataTable
        /// </summary>
        /// <param name="cmd">Comando Query</param>
        /// <returns>dataTable</returns>
        public DataTable EseguiQuery(SqlCommand cmd)
        {
            SqlDataAdapter adp;
            DataTable dt = new DataTable();
            adp = new SqlDataAdapter(cmd);
            try
            {
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }

    }
}
