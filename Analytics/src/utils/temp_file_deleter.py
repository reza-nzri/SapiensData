import os
import shutil  # For deleting directories
import sys
from colorama import Fore, Style

class TempFileDeleter:
    def __init__(self, username):
        """
        Initializes the TempFileDeleter with the given username.
        
        Parameters:
        - username (str): The username whose temp folder will be deleted.
        """
        self.username = username
        self.base_dir = os.path.abspath('src/_temp_files')  # Base directory for user-specific temp files

    def delete_temp_files_by_username(self):
        """Delete all files and the folder associated with the given username."""
        user_dir = os.path.join(self.base_dir, self.username)  # User-specific folder path
        
        # Check if the directory exists
        if not os.path.exists(user_dir):
            print(Fore.RED + f"Error: The directory for username {self.username} does not exist." + Style.RESET_ALL)
            return

        # Try to delete the directory and its contents
        try:
            # Remove the directory and all its contents
            shutil.rmtree(user_dir)
            print(Fore.GREEN + f"Successfully deleted the directory and all files for user {self.username}." + Style.RESET_ALL)
        except Exception as e:
            print(f"Error deleting {user_dir}: {e}")

    def run(self):
        """Run the deletion of the user-specific folder and its contents."""
        print(Fore.YELLOW + f"Starting deletion process for the folder associated with username: {self.username}" + Style.RESET_ALL)
        
        self.delete_temp_files_by_username()

        print(Fore.GREEN + "The folder and all its contents have been deleted." + Style.RESET_ALL)


if __name__ == "__main__":
    # Check if the username was passed as a command-line argument
    if len(sys.argv) != 2:
        print(Fore.RED + "Error: Please provide the username as an argument." + Style.RESET_ALL)
        sys.exit(1)
    
    # Get the username from the command line argument
    username = sys.argv[1]

    # Create an instance of TempFileDeleter and call the deletion process
    temp_deleter = TempFileDeleter(username)
    temp_deleter.run()
