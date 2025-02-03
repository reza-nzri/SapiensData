import os
from colorama import Fore, Style

class TextCleaner:
    def __init__(self, username):
        """
        Initializes the TextCleaner class to process and clean the input text from the file
        and save the result to the same file.
        
        Parameters:
        - username (str): The username used to construct the file path for loading and saving the cleaned text.
        """
        self.username = username
        self.input_path = f"src/_temp_files/{self.username}/_temp_final_ocr.txt"  # Path to load the text from
        self.output_path = self.input_path  # Save to the same path

    def convert_to_semicolon_separated(self, input_text):
        """
        This method processes the input text by removing unwanted phrases and 
        splitting the text into lines, then joining them into a semicolon-separated format.
        
        Parameters:
        - input_text (str): The text to be cleaned and processed.
        
        Returns:
        - str: The processed text in semicolon-separated format.
        """
        try:
            # Remove the unwanted "CS Scanned with CamScanner" text
            cleaned_text = input_text.replace("CS Scanned with CamScanner", "")
            
            # Split the input text by newlines and remove any empty lines
            lines = [line.strip() for line in cleaned_text.splitlines() if line.strip()]
            
            # Join the lines with a space (no semicolon used as per previous behavior) and return the result
            semicolon_separated_text = " ".join(lines)
            
            return semicolon_separated_text
        except Exception as e:
            self.handle_error(e)

    def handle_error(self, error):
        """
        Custom error handler to log the error into the output file.
        """
        with open(self.output_path, "w", encoding="utf-8") as file:
            file.write("Error occurred during text processing: \n")
            file.write(str(error))

    def save_processed_text(self, cleaned_text):
        """
        Saves the cleaned text into the specified output file.
        """
        try:
            # Save the cleaned text to the file
            with open(self.output_path, "w", encoding="utf-8") as file:
                file.write(cleaned_text)

            # Success message
            print(Fore.GREEN + f"Text cleaning and saving completed successfully for user {self.username}." + Style.RESET_ALL)

        except Exception as e:
            self.handle_error(e)

    def load_and_process_text(self):
        """
        Load the text from the file, process it, and save the result.
        """
        try:
            # Check if the input file exists
            if not os.path.exists(self.input_path):
                print(Fore.RED + f"Error: The file '{self.input_path}' does not exist." + Style.RESET_ALL)
                return

            # Open the file and read its content
            with open(self.input_path, "r", encoding="utf-8") as file:
                input_text = file.read()

            # Process the input text
            cleaned_text = self.convert_to_semicolon_separated(input_text)

            # Save the processed text back to the file
            self.save_processed_text(cleaned_text)

        except Exception as e:
            self.handle_error(e)


# Example usage
if __name__ == "__main__":
    # Get the username from the user input
    username = input("Enter username: ")

    # Create an instance of TextCleaner and call the method to process and save the cleaned text
    text_cleaner = TextCleaner(username)
    text_cleaner.load_and_process_text()
