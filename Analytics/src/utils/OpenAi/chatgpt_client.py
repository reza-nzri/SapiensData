import openai
import os
import json  # Import the json module to work with JSON files
from colorama import Fore, Style
from dotenv import load_dotenv

# Load the environment variables from .env file
load_dotenv(".env.dev")


class ChatGPTClient:
    def __init__(self, username):
        """
        Initializes the ChatGPTClient, loads the OpenAI API key, 
        and sets configuration for the GPT-4 model.
        
        Parameters:
        - username (str): The username for dynamically generating the file paths
        """
        self.username = username  # Save the username to dynamically construct file paths
        # Retrieve the OpenAI API key from the environment
        self.api_key = os.getenv('OPENAI_API_KEY')
        if not self.api_key:
            raise ValueError(Fore.RED + "API Key not found in environment variables" + Style.RESET_ALL)

        openai.api_key = self.api_key

        # Set default configuration for the GPT-3.5-turbo model
        self.model = "gpt-4"  # You can change this to "gpt-4" or "gpt-3.5-turbo" if needed
        self.max_tokens = 2048  # Token limit for output
        self.temperature = 0.2  # Controls randomness of responses (0.0-1.0)
        self.top_p = 0.9        # Controls diversity via nucleus sampling (0.0-1.0)
        self.frequency_penalty = 0.0  # Discourage repetition (negative values increase repetition)
        self.presence_penalty = 0.8  # Discourage new topic introduction

        # Read the default prompt from the specified file
        self.system_message = self.load_default_prompt()

    def load_default_prompt(self):
        """
        Load the entire content from the json_structure_prompt.tet file 
        and return it as a system message. If the file cannot be read, return an empty string.
        
        Returns:
        - str: The system message content
        """
        try:
            # Dynamically build the file path for json_structure_prompt.text
            file_path = "src/utils/OpenAi/json_structure_prompt.txt"

            # Print the absolute file path for debugging purposes
            # print(Fore.YELLOW + f"Attempting to load the file from: {os.path.abspath(file_path)}" + Style.RESET_ALL)

            # Read the file content
            with open(file_path, "r", encoding="utf-8") as file:
                # Read all content and return it as a system message
                content = file.read()
                return content.strip()  # Return the full content as a system message
        
        except Exception as e:
            print(Fore.RED + f"Error loading the prompt file: {e}" + Style.RESET_ALL)
            return ""  # Return an empty string if the file can't be read

    def get_response(self):
        """
        Load the OCR text from the file and send it to OpenAI's GPT-3.5-turbo model to return the response.
        Save the response as _temp_receipt.json in the user-specific folder.
        
        Returns:
        - str: The response text from the model
        """
        try:
            # Check if the system message is valid (i.e., not empty)
            if not self.system_message:
                print(Fore.RED + "System message not loaded properly." + Style.RESET_ALL)
                return None

            # Dynamically construct the path to the OCR text file
            ocr_text_file_path = f"src/_temp_files/{self.username}/_temp_final_ocr.txt"

            # Load OCR text from the file
            with open(ocr_text_file_path, "r", encoding="utf-8") as file:
                ocr_text = file.read().strip()

            if not ocr_text:
                print(Fore.RED + f"OCR text file for {self.username} is empty or could not be read." + Style.RESET_ALL)
                return None

            # Proceed with OpenAI API call only if all required data is present
            response = openai.ChatCompletion.create(
                model=self.model,
                messages=[
                    {"role": "system", "content": self.system_message},
                    {"role": "user", "content": f"Input OCR-Text from Receipt: {ocr_text}"}
                ],
                max_tokens=self.max_tokens,
                temperature=self.temperature,
                top_p=self.top_p,
                frequency_penalty=self.frequency_penalty,
                presence_penalty=self.presence_penalty
            )

            # Extract the response text (remove any extra text or formatting)
            response_text = response['choices'][0]['message']['content'].strip()

            # Define the path for saving the response JSON file
            output_file_path = f"src/_temp_files/{self.username}/_temp_receipt.json"

            # Save the response text as a JSON file
            with open(output_file_path, "w", encoding="utf-8") as output_file:
                json.dump({"receipt": response_text}, output_file, ensure_ascii=False, indent=4)

            # Return the response text for any other uses or debugging
            return response_text

        except Exception as e:
            print(Fore.RED + f"Error while interacting with OpenAI API or reading OCR text file: {e}" + Style.RESET_ALL)
            return None

    def set_configuration(self, max_tokens=None, temperature=None, top_p=None, frequency_penalty=None, presence_penalty=None):
        """
        Allow customization of the model configuration settings.
        
        Parameters:
        - max_tokens (int): The max number of tokens for the response.
        - temperature (float): Controls randomness of responses (0.0-1.0).
        - top_p (float): Controls diversity via nucleus sampling (0.0-1.0).
        - frequency_penalty (float): Penalty for repetition of phrases.
        - presence_penalty (float): Discourages introducing new topics.
        """
        if max_tokens is not None:
            self.max_tokens = max_tokens
        if temperature is not None:
            self.temperature = temperature
        if top_p is not None:
            self.top_p = top_p
        if frequency_penalty is not None:
            self.frequency_penalty = frequency_penalty
        if presence_penalty is not None:
            self.presence_penalty = presence_penalty


# Example usage
if __name__ == "__main__":
    # Get the username from the command line or any other input
    username = input("Enter username: ")

    # Create an instance of the ChatGPT client with the username
    gpt_client = ChatGPTClient(username)

    # Set a custom configuration (optional)
    gpt_client.set_configuration(max_tokens=2048, temperature=0.2)

    # Get response from ChatGPT (OCR text will be loaded from the user's folder)
    response_text = gpt_client.get_response()

    # Check if the response was saved and print the success message
    if response_text:
        print(Fore.YELLOW + "\nResponse has been saved as _temp_receipt.json." + Style.RESET_ALL)
    else:
        print("No response received.")
