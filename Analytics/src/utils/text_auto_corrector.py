import os
from colorama import Fore, Style
from language_tool_python import LanguageTool
from spellchecker import SpellChecker
from textblob import TextBlob
import spacy

class TextAutoCorrector:
    def __init__(self, username, languages=['de', 'en']):
        """
        Initializes the TextAutoCorrector class to process and correct text for the given username.
        
        Parameters:
        - username (str): The username for constructing the file path for saving the corrected text.
        - languages (list): List of languages to support for correction (default is ['de', 'en']).
        """
        self.username = username
        self.input_path = f"src/_temp_files/{self.username}/_temp_final_ocr.txt"
        self.output_path = self.input_path  # Save the corrected text to the same file
        
        # Initialize tools for each specified language
        self.language_tool = {lang: LanguageTool(lang) for lang in languages}
        self.spell_checker = SpellChecker(language='en')  # Default to English
        self.nlp = spacy.load("en_core_web_sm")  # Spacy for advanced NLP processing

    def correct_with_language_tool(self, text):
        """Correct text using LanguageTool for multiple languages."""
        for lang, tool in self.language_tool.items():
            text = tool.correct(text)
        return text

    def correct_with_spellchecker(self, text):
        """Correct spelling using the SpellChecker library."""
        words = text.split()
        corrected_words = []
        for word in words:
            if word.lower() in self.spell_checker:
                corrected_words.append(word)
            else:
                corrected_words.append(self.spell_checker.correction(word) or word)
        return " ".join(corrected_words)

    def correct_with_textblob(self, text):
        """Correct text using TextBlob for basic spelling corrections."""
        blob = TextBlob(text)
        return str(blob.correct())

    def apply_corrections(self, text):
        """Apply multiple correction methods to the text."""
        text = self.correct_with_language_tool(text)
        text = self.correct_with_spellchecker(text)
        text = self.correct_with_textblob(text)
        return text

    def save_corrected_text(self, corrected_text):
        """Save the corrected text into the specified file."""
        try:
            # Save the cleaned text to the file
            with open(self.output_path, "w", encoding="utf-8") as file:
                file.write(corrected_text)

            # Success message
            print(Fore.GREEN + f"Text cleaning and saving completed successfully for user {self.username}." + Style.RESET_ALL)

        except Exception as e:
            self.handle_error(e)

    def handle_error(self, error):
        """Handle any errors that occur during the process."""
        with open(self.output_path, "w", encoding="utf-8") as file:
            file.write("Error occurred during text processing: \n")
            file.write(str(error))

    def load_and_process_text(self):
        """Load the text from the file, process it, and save the result."""
        try:
            # Check if the input file exists
            if not os.path.exists(self.input_path):
                print(Fore.RED + f"Error: The file '{self.input_path}' does not exist." + Style.RESET_ALL)
                return

            # Open the file and read its content
            with open(self.input_path, "r", encoding="utf-8") as file:
                input_text = file.read()

            # Process the input text
            corrected_text = self.apply_corrections(input_text)

            # Save the processed text back to the file
            self.save_corrected_text(corrected_text)

        except Exception as e:
            self.handle_error(e)


# Example usage
if __name__ == "__main__":
    # Get the username from the user input
    username = input("Enter username: ")

    # Create an instance of TextAutoCorrector and call the method to process and save the corrected text
    text_cleaner = TextAutoCorrector(username)
    text_cleaner.load_and_process_text()
