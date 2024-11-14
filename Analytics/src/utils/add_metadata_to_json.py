import json
import os
from colorama import Fore, Style

class JsonUpdater:
    def __init__(self, username, receipt_filename):
        """
        Initializes the JsonUpdater class to load, modify, and save a JSON file 
        based on the given username and receipt filename.
        
        Parameters:
        - username (str): The username used to construct the file path.
        - receipt_filename (str): The receipt filename to be added to the metadata.
        """
        self.username = username  # Save the username to dynamically construct the file path
        self.receipt_filename = receipt_filename  # Save the receipt filename
        self.file_path = f"src/_temp_files/{self.username}/_temp_receipt.json"  # Path to the JSON file

    def update_json_with_metadata(self):
        """
        Add the 'file_metadata' section to the JSON file before the 'receipt' field.
        """
        try:
            # Check if the file exists before proceeding
            if not os.path.exists(self.file_path):
                print(Fore.RED + f"Error: The file {self.file_path} does not exist." + Style.RESET_ALL)
                return

            # Open the existing JSON file and load its content
            with open(self.file_path, "r", encoding="utf-8") as file:
                data = json.load(file)

            # Define the metadata to add, inserting the receipt_filename dynamically
            file_metadata = {
                "fileMetadata": {
                    "receipt_filename": self.receipt_filename
                }
            }

            # Add the file_metadata before the "receipt" field
            data = {**file_metadata, **data}

            # Write the updated JSON back to the file
            with open(self.file_path, "w", encoding="utf-8") as output_file:
                json.dump(data, output_file, ensure_ascii=False, indent=4)

            print(Fore.GREEN + f"Successfully added metadata to the JSON file for user {self.username}." + Style.RESET_ALL)

        except json.JSONDecodeError as e:
            print(Fore.RED + f"Error decoding JSON: {e}" + Style.RESET_ALL)
        except Exception as e:
            print(Fore.RED + f"An error occurred: {e}" + Style.RESET_ALL)

# Example usage
if __name__ == "__main__":
    # Get the username from the user input
    username = input("Enter username: ")
    
    # Get the receipt_filename from the user input
    receipt_filename = "to_process_20240812_221520.jpg"

    # Create an instance of JsonUpdater for the given username
    json_updater = JsonUpdater(username, receipt_filename)

    # Call the method to update the JSON file with metadata
    json_updater.update_json_with_metadata()
