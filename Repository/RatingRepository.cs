using Entities;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RatingRepository: IRatingRepository
    {

        IConfiguration _configuration;   
        public RatingRepository(IConfiguration configuration)
        {
            _configuration=configuration;
        }
        //private static void CreateCommand(string queryString, string connectionString)
        //{
        //    using(SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        using (SqlCommand command = new SqlCommand(queryString, connection))
        //        {
        //            command.Connection.Open();
        //            command.ExecuteNonQuery();
        //        }                
        //    }       
        //}
        public async Task EnterRating(Rating rating)
        {
            var connectionString = _configuration.GetConnectionString("ShulamitHome");
            var queryString = "INSERT INTO [dbo].[rating] ([HOST],[METHOD],[PATH],[REFERER],[USER_AGENT],[Record_Date])" +
            "VALUES(@HOST,@Method,@Path,@Referer,@UserAgent,@RecordDate)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.Add("@Host", SqlDbType.NVarChar, 50).Value = rating.Host;
                    command.Parameters.Add("@Method", SqlDbType.NChar, 10).Value = rating.Method;
                    command.Parameters.Add("@Path", SqlDbType.NVarChar, 50).Value = rating.Path;
                    command.Parameters.Add("@Referer", SqlDbType.NVarChar, 100).Value = rating.Referer;
                    command.Parameters.Add("@UserAgent", SqlDbType.NVarChar, int.MaxValue).Value = rating.UserAgent;
                    command.Parameters.Add("@RecordDate", SqlDbType.DateTime).Value = rating.RecordDate;
                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                    await connection.CloseAsync();
                }
            }
        }

    }
}







