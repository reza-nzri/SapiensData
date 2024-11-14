import os
from colorama import Fore, init
from dotenv import load_dotenv

# Initialize colorama
init(autoreset=True)

class MetadataExtractor:
    def __init__(self, source_image: str):
        self.source_image = source_image
        self.google_drive_path = self._get_google_drive_path()

    def _get_google_drive_path(self) -> str:
        # Define the path to the .env file
        env_path = os.path.join(os.path.dirname(__file__), '..', '..', '.env.dev')
        
        # Load environment variables from .env file
        load_dotenv(env_path)
        
        google_drive_path = os.getenv("GOOGLE_DRIVE_BEGINNING_PATH", "")
        if not google_drive_path:
            raise ValueError(Fore.RED + "Error: GOOGLE_DRIVE_BEGINNING_PATH not found in .env file")
        return google_drive_path

    def extract_receipt_path(self) -> str:
        # Combine Google Drive base path with the relative source image path
        receipt_path = os.path.join(self.google_drive_path, self.source_image.replace("\\", "/"))
        return receipt_path

    def extract_username(self) -> str:
        # Split the source image path to find the "dummy" folder (which is the parent folder of the username)
        path_parts = self.source_image.split('/')
        if 'user_data' in path_parts:
            user_data_index = path_parts.index('user_data')
            # The username should be the folder after "user_data"
            if user_data_index + 1 < len(path_parts):
                return path_parts[user_data_index + 1]
        raise ValueError(Fore.RED + "Error: Username not found in source image path")
      
    def extract_receipt_filename(self) -> str:
      # Extract the filename from the source image path
      filename = os.path.basename(self.source_image)
      return filename


if __name__ == "__main__":
    source_image = r"SapiensCloud/media/user_data/dummy/receipts/aldi-sued_20231009_181413.jpg"

    receipt_generator = MetadataExtractor(source_image)
    receipt_path = receipt_generator.extract_receipt_path()
    receipt_filename = receipt_generator.extract_receipt_filename()
    username = receipt_generator.extract_username()

    print("\nExtracted Receipt Path: " + Fore.YELLOW + f"{receipt_path}")
    print("Extracted receipt_filename: " + Fore.YELLOW + f"{receipt_filename}")
    print("Extracted Username: " + Fore.YELLOW + f"{username}\n")
