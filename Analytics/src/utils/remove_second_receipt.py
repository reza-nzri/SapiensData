# remove_receipt.py

import json
import os
from colorama import Fore, Style

class JsonReceiptRemover:
    def __init__(self, username):
        """
        Initializes the JsonReceiptRemover with the username and the file path
        for the JSON file that needs to be processed.
        
        Parameters:
        - username (str): The username used to construct the file path.
        """
        self.username = username
        self.file_path = f"src/_temp_files/{self.username}/_temp_receipt.json"  # Path to the user-specific JSON file

    def remove_receipt(self):
        """Remove the 'receipt' key from the JSON and move its contents to the parent level."""
        try:
            # Check if the file exists
            if not os.path.exists(self.file_path):
                print(Fore.RED + f"Error: The file {self.file_path} does not exist." + Style.RESET_ALL)
                return

            # Open the existing JSON file and load its content
            with open(self.file_path, "r", encoding="utf-8") as file:
                data = json.load(file)

            # Check if the "receipt" key exists
            if "receipt" in data:
                # Move contents of "receipt" to the parent level
                receipt_contents = data.pop("receipt")  # Pop the contents of 'receipt' into a new variable

                # Add the contents of "receipt" to the parent level, before "Store"
                data.update(receipt_contents)

                print(Fore.GREEN + f"Successfully removed 'receipt' key and moved its contents for user {self.username}." + Style.RESET_ALL)
            else:
                print(Fore.RED + "'receipt' not found in the JSON file." + Style.RESET_ALL)
                return

            # Save the modified data back to the JSON file
            with open(self.file_path, "w", encoding="utf-8") as output_file:
                json.dump(data, output_file, ensure_ascii=False, indent=4)

            print(Fore.GREEN + "The 'receipt' field has been removed, and its contents have been moved successfully." + Style.RESET_ALL)

        except Exception as e:
            print(Fore.RED + f"An error occurred while processing the file: {e}" + Style.RESET_ALL)

# Example usage
if __name__ == "__main__":
    # Get the username as an argument
    username = input("Enter username: ")

    # Create an instance of JsonReceiptRemover and call the method to remove the 'receipt' field
    remover = JsonReceiptRemover(username)
    remover.remove_receipt()
