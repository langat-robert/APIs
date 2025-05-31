namespace CSharpSample1.API.Models
{
    public class LookupGroupDto
    {
        public int? LookupGroupID { get; set; }
        public string LookupGroupCode { get; set; } = string.Empty;
        public string LookupGroupName { get; set; } = string.Empty;
        public int UserID { get; set; }
    }
}
