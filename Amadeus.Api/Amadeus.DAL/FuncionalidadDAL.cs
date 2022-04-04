
using Amadeus.Entities;
using Amadeus.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;


namespace Amadeus.DAL
{
    public static class FunctionsDAL
    {
        
        private static readonly string _StringConection = ApiConnectionStrings.ConnectionStringDB;

        #region Travel
        public static async Task<ModelTravel> GetTravel(int id)
        {

            ModelTravel Travel = new ModelTravel();

            using (SqlConnection conn = new SqlConnection(_StringConection))

            {
                SqlCommand cmd = new SqlCommand("SP_GetTravel", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);

                try
                {
                    await conn.OpenAsync();
                    SqlDataReader Rd = await cmd.ExecuteReaderAsync();
                    while (Rd.Read())
                    {
                        Travel.Id = Convert.ToInt32(Rd["Id"]);
                        Travel.StartDate = Convert.ToDateTime(Rd["StartDate"]);
                        Travel.Observations = Rd["Observations"].ToString();
                        Travel.Email = Rd["Email"].ToString();
                        Travel.Name = Rd["Name"].ToString();
                        Travel.Active = Convert.ToBoolean(Rd["Active"]);
                        Travel.Nacionality = Convert.ToInt32(Rd["Nacionality"]);
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Travel.Msg = ex.ToString();
                    conn.Close();

                }
            }
            return Travel;
        }

        public static async Task<List<ModelTravel>> GetListTravel()
        {
            List<ModelTravel> GetListTravel = new List<ModelTravel>();

            using (SqlConnection conn = new SqlConnection(_StringConection))
            {
                SqlCommand cmd = new SqlCommand("SP_GetTravels", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    await conn.OpenAsync();
                    SqlDataReader Rd = await cmd.ExecuteReaderAsync();

                    while (Rd.Read())
                    {
                        GetListTravel.Add(new ModelTravel

                        {
                            Id = Convert.ToInt32(Rd["Id"]),
                            StartDate = Convert.ToDateTime(Rd["StartDate"]),
                            Observations = Rd["Observations"].ToString(),
                            Email = Rd["Email"].ToString(),
                            Name = Rd["Name"].ToString(),
                            Active = Convert.ToBoolean(Rd["Active"]),
                            Nacionality = Convert.ToInt32(Rd["Nacionality"])
                    });
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    GetListTravel.Add(new ModelTravel {Msg = ex.ToString()});
                   conn.Close();
                }
            }
            return GetListTravel;

        }

        public static async Task<ModelTravel> CreateTravel(DateTime StartDate, string Observations, string Email, string Name, bool Active, int Nacionality)
        {

            ModelTravel Travel = new ModelTravel();

            using (SqlConnection conn = new SqlConnection(_StringConection))

            {
                SqlCommand cmd = new SqlCommand("SP_CreateTravel", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StartDate", StartDate);
                cmd.Parameters.AddWithValue("@Observations", Observations);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Active", Active);
                cmd.Parameters.AddWithValue("@Nacionality", Nacionality);

                try
                {
                    await conn.OpenAsync();
                    SqlDataReader Rd = await cmd.ExecuteReaderAsync();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Travel.Msg = ex.ToString();
                    conn.Close();
                }
            }
            return Travel;
        }

        public static async Task<ModelTravel> UpdateTravel(int Id, DateTime StartDate, string Observations, string Email, string Name, bool Active, int Nacionality)
        {

            ModelTravel Travel = new ModelTravel();

            using (SqlConnection conn = new SqlConnection(_StringConection))

            {
                SqlCommand cmd = new SqlCommand("SP_UpdateTravel", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@StartDate", StartDate);
                cmd.Parameters.AddWithValue("@Observations", Observations);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Active", Active);
                cmd.Parameters.AddWithValue("@Nacionality", Nacionality);

                try
                {
                    await conn.OpenAsync();
                    SqlDataReader Rd = await cmd.ExecuteReaderAsync();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Travel.Msg = ex.ToString();
                    conn.Close();
                }
            }
            return Travel;
        }

        public static async Task<ModelTravel> DeleteTravel(int Id)
        {

            ModelTravel Travel = new ModelTravel();

            using (SqlConnection conn = new SqlConnection(_StringConection))

            {
                SqlCommand cmd = new SqlCommand("SP_DeleteTravel", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);

                try
                {
                    await conn.OpenAsync();
                    SqlDataReader Rd = await cmd.ExecuteReaderAsync();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Travel.Msg = ex.ToString();
                    conn.Close();
                }
            }
            return Travel;
        }

        #endregion

    }
}
