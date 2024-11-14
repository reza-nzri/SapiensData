import openai
import os
from colorama import Fore, Style
from dotenv import load_dotenv

# Load the environment variables from .env file
load_dotenv(".env.dev")


class ChatGPTClient:
    def __init__(self):
        """
        Initializes the ChatGPTClient, loads the OpenAI API key, 
        and sets configuration for the GPT-4 model.
        """
        # Retrieve the OpenAI API key from the environment
        self.api_key = os.getenv('OPENAI_API_KEY')
        if not self.api_key:
            raise ValueError(Fore.RED + "API Key not found in environment variables" + Style.RESET_ALL)

        openai.api_key = self.api_key

        # Set default configuration for the GPT-4 model
        self.model = "gpt-4"  # Use the chat-based GPT-4 model
        self.max_tokens = 2048  # Token limit for output
        self.temperature = 0.2  # Controls randomness of responses (0.0-1.0)
        self.top_p = 0.9        # Controls diversity via nucleus sampling (0.0-1.0)
        self.frequency_penalty = 0.0  # Discourage repetition (negative values increase repetition)
        self.presence_penalty = 0.8  # Discourage new topic introduction

        # Read the default prompt from the specified file
        self.system_message = self.load_default_prompt()

    def load_default_prompt(self):
        """
        Load the entire content from the json_structure_prompt.text file 
        and return it as a system message. If the file cannot be read, return an empty string.
        """
        try:
            # Print the path to help with debugging
            file_path = "src/utils/OpenAi/json_structure_prompt.text"
            # print(Fore.YELLOW + f"Attempting to load the file from: {os.path.abspath(file_path)}" + Style.RESET_ALL)
            
            # Read the file content
            with open(file_path, "r", encoding="utf-8") as file:
                # Read all content (without any trimming)
                content = file.read()
                return content.strip()  # Return the full content as a system message

        except Exception as e:
            print(Fore.RED + f"Error loading the prompt file: {e}" + Style.RESET_ALL)
            return ""

    def get_response(self):
        """
        Load the OCR text from the file and send it to OpenAI's GPT-4 model to return the response.
        If any required step (config, system message, OCR text) fails, skip sending the request.
        """
        try:
            # Check if the system message is valid (i.e., not empty)
            if not self.system_message:
                print(Fore.RED + "System message not loaded properly." + Style.RESET_ALL)
                return None

            # Load OCR text from the file
            with open("src/_temp_files/rezan/_temp_final_ocr.txt", "r", encoding="utf-8") as file:
                ocr_text = file.read().strip()

            if not ocr_text:
                print(Fore.RED + "OCR text file is empty or could not be read." + Style.RESET_ALL)
                return None

            # Proceed with OpenAI API call only if all required data is present
            response = openai.ChatCompletion.create(
                model=self.model,
                messages=[
                    # System message sets the background behavior and instructions
                    {"role": "system", "content": self.system_message},
                    {"role": "user", "content": ocr_text}
                ],
                max_tokens=self.max_tokens,
                temperature=self.temperature,
                top_p=self.top_p,
                frequency_penalty=self.frequency_penalty,
                presence_penalty=self.presence_penalty
            )

            # Return the response text
            return response['choices'][0]['message']['content'].strip()

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
    # Create an instance of the ChatGPT client
    gpt_client = ChatGPTClient()

    # Set a custom configuration (optional)
    gpt_client.set_configuration(max_tokens=2048, temperature=0.2)

    # Get response from ChatGPT (OCR text will be loaded from the file)
    response_text = gpt_client.get_response()

    # Print the response if it exists
    if response_text:
        print(Fore.YELLOW + "\nChatGPT Response: \n" + Style.RESET_ALL + response_text)
        print("")
    else:
        print("No response received.")
