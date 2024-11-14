import json
import os
from colorama import Fore, Style

class JsonFormatter:
    def __init__(self, username):
        """
        Initializes the JsonFormatter, which loads the file for a given username,
        reformats the JSON content, and saves it back to the file.
        
        Parameters:
        - username (str): The username for which the specific file will be processed.
        """
        self.username = username  # Save the username to dynamically construct the file path
        self.ocr_text_file_path = f"src/_temp_files/{self.username}/_temp_receipt.json"  # Path to the JSON file
        
    def load_and_format_json(self):
        """
        Load the JSON from the file, format it properly by removing unwanted escape characters
        and newline sequences, and overwrite the file with the formatted JSON.
        """
        try:
            # Check if the file exists before proceeding
            if not os.path.exists(self.ocr_text_file_path):
                print(Fore.RED + f"Error: The file {self.ocr_text_file_path} does not exist." + Style.RESET_ALL)
                return
            
            # Open the existing JSON file
            with open(self.ocr_text_file_path, "r", encoding="utf-8") as file:
                # Load the JSON data from the file
                data = json.load(file)

            # Format the JSON data as a string with proper indentation
            formatted_json = json.dumps(data, indent=4, ensure_ascii=False)

            # Now handle the unwanted newline escape characters
            formatted_json = formatted_json.replace("\\n", "\n").replace("\\r", "\r").replace("\\", "")

            formatted_json = self.remove_third_and_last_occurrence(formatted_json, '\"')

            # Write the formatted JSON back to the file
            with open(self.ocr_text_file_path, "w", encoding="utf-8") as output_file:
                output_file.write(formatted_json)

            print(Fore.GREEN + f"JSON formatting completed successfully for user {self.username}." + Style.RESET_ALL)
        
        except json.JSONDecodeError as e:
            print(Fore.RED + f"Error decoding JSON: {e}" + Style.RESET_ALL)
        except Exception as e:
            print(Fore.RED + f"An error occurred: {e}" + Style.RESET_ALL)
            
    def remove_third_and_last_occurrence(self, s, char):
      # Find the third occurrence of the character
      first = s.find(char)
      second = s.find(char, first + 1)
      third = s.find(char, second + 1)

      if third != -1:
          # Remove the third occurrence
          s = s[:third] + s[third+1:]

      # Find the last occurrence of the character
      last = s.rfind(char)
      if last != -1:
          # Remove the last occurrence
          s = s[:last] + s[last+1:]

      return s

# Example usage
if __name__ == "__main__":
    # Get the username from the user input
    username = "rezan"

    # Create an instance of JsonFormatter for the given username
    json_formatter = JsonFormatter(username)

    # Call the method to load, format, and save the JSON file
    json_formatter.load_and_format_json()
