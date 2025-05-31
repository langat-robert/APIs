
1. create a well architected RESTful API using C#, using best recommended practices
2. Database is MSSQLSERVER Version 16.0.x, database name is called MoLSP
3. I have a stored procedure called sp_AddEditLookupGroup that i will use to implement database logic with definition as below
CREATE OR ALTER PROCEDURE sp_AddEditLookupGroup
    @LookupGroupID INT = NULL,
    @LookupGroupCode NVARCHAR(10),
    @LookupGroupName NVARCHAR(100),
    @UserID INT)
4. Ensure it uses the most secure option