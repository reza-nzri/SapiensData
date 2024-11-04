namespace SoftwareManagementAPI.Dtos.Software
{
    public class AddSoftwareDto
    {
        public string Name { get; set; } = string.Empty;       // Name of the software
        public string Description { get; set; } = string.Empty; // Description of the software
        public DateTime? ReleaseDate { get; set; }             // Optional release date
    }
}