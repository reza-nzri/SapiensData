namespace SapiensDataAPI.Dtos.ImageUploader.Request
{
	public class UploadImageDto
	{
		public string UserName { get; set; }
        public IFormFile Image { get; set; }
    }
}
