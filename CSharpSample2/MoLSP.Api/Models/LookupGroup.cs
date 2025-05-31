namespace MoLSP.Api.Models
{
    public class LookupGroup
    {
        public int? LookupGroupID { get; set; }
        public string LookupGroupCode { get; set; } = null!;
        public string LookupGroupName { get; set; } = null!;
        public int UserID { get; set; }
    }
}