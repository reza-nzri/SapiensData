namespace SoftwareManagementAPI.Models
{
    public class SoftwareModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? Release { get; set; }
    }
}