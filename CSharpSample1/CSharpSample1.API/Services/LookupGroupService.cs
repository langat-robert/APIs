using CSharpSample1.API.Data;
using CSharpSample1.API.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CSharpSample1.API.Services
{
    public class LookupGroupService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<LookupGroupService> _logger;
        public LookupGroupService(ApplicationDbContext context, ILogger<LookupGroupService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<int> AddOrEditLookupGroupAsync(LookupGroupDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.LookupGroupCode) || string.IsNullOrWhiteSpace(dto.LookupGroupName))
                throw new ArgumentException("LookupGroupCode and LookupGroupName are required.");
            if (dto.UserID <= 0)
                throw new ArgumentException("UserID must be a positive integer.");

            var lookupGroupIdParam = new SqlParameter("@LookupGroupID", dto.LookupGroupID ?? (object)DBNull.Value);
            var codeParam = new SqlParameter("@LookupGroupCode", dto.LookupGroupCode);
            var nameParam = new SqlParameter("@LookupGroupName", dto.LookupGroupName);
            var userIdParam = new SqlParameter("@UserID", dto.UserID);

            try
            {
                _logger.LogInformation("Executing stored procedure sp_AddEditLookupGroup for LookupGroupCode: {Code}", dto.LookupGroupCode);
                var result = await _context.Database.ExecuteSqlRawAsync(
                    "EXEC sp_AddEditLookupGroup @LookupGroupID, @LookupGroupCode, @LookupGroupName, @UserID",
                    lookupGroupIdParam, codeParam, nameParam, userIdParam);
                _logger.LogInformation("Stored procedure executed successfully for LookupGroupCode: {Code}", dto.LookupGroupCode);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing stored procedure for LookupGroupCode: {Code}", dto.LookupGroupCode);
                throw new ApplicationException("Database operation failed.", ex);
            }
        }
    }
}
