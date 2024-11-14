import os
from colorama import Fore, Style

class FolderChecker:
    def __init__(self, username):
        """
        Initializes the FolderChecker with the given username.
        
        :param username: The username for constructing the folder path.
        """
        self.username = username
        self.base_dir = os.path.abspath('src/_temp_files')  # Base directory for user-specific folders

    def check_or_create_folder(self):
        """
        Checks if the folder with the username exists. If not, creates it.
        
        :return: True if the folder exists, or it has been created successfully.
        """
        user_dir = os.path.join(self.base_dir, self.username)  # User-specific folder path
        
        # Check if the folder exists
        if os.path.exists(user_dir):
            print(Fore.GREEN + f"Folder for username '{self.username}' already exists." + Style.RESET_ALL)
            return True
        else:
            # Create the folder if it doesn't exist
            try:
                os.makedirs(user_dir)
                print(Fore.YELLOW + f"Folder '{self.username}' created successfully!" + Style.RESET_ALL)
                return True
            except Exception as e:
                print(Fore.RED + f"Error creating folder '{self.username}': {e}" + Style.RESET_ALL)
                return False

    def run(self):
        """
        Runs the check or creation process for the folder associated with the username.
        """
        self.check_or_create_folder()


# Example Usage
if __name__ == "__main__":
    # Prompt the user for the username input
    username = input("Enter username: ")

    # Create an instance of FolderChecker and run the folder check/create process
    folder_checker = FolderChecker(username)
    folder_checker.run()
