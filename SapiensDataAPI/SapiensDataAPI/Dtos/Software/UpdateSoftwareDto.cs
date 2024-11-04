namespace SapiensDataAPI.Dtos.Software
{
    public class UpdateSoftwareDto
    {
        public int Id { get; set; }                             // ID of the software to update
        public string Name { get; set; } = string.Empty;       // Name of the software
        public string Description { get; set; } = string.Empty; // Description of the software
        public DateTime? ReleaseDate { get; set; }             // Optional release date
    }
}