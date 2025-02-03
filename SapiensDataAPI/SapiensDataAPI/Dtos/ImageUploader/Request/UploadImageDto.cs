namespace SapiensDataAPI.Dtos.ImageUploader.Request
{
	public class UploadImageDto
	{
		public required IFormFile Image { get; set; }
	}
}