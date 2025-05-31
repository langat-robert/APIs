using System.Data;
using Microsoft.Data.SqlClient;
using MoLSP.Api.Models;

namespace MoLSP.Api.Services
{
    public class LookupGroupService
    {
        private readonly string _connectionString;

        public LookupGroupService(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("MoLSPConnection");
        }

        public async Task<bool> AddOrEditLookupGroupAsync(LookupGroup group)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_AddEditLookupGroup", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@LookupGroupID", (object?)group.LookupGroupID ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@LookupGroupCode", group.LookupGroupCode);
            cmd.Parameters.AddWithValue("@LookupGroupName", group.LookupGroupName);
            cmd.Parameters.AddWithValue("@UserID", group.UserID);

            var outputParam = new SqlParameter("@Result", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(outputParam);

            await conn.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            // Retrieve the output parameter value
            int result = (int)outputParam.Value;
            //Console.WriteLine($"From DB result: {result}");
            return result > 0;
        }
    }
}
