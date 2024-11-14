import openai
import os
from colorama import Fore, Style
from dotenv import load_dotenv

# Load the environment variables from .env file
load_dotenv(".env.dev")


class ChatGPTClient:
    def __init__(self):
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
        self.presence_penalty = 0.0  # Discourage new topic introduction

    def get_response(self, text_input):
        if not text_input.strip():
            raise ValueError("Input text cannot be empty or just spaces.")
        
        try:
            # Create the OpenAI API call using the correct endpoint for chat-based models
            response = openai.ChatCompletion.create(
                model=self.model,
                messages=[
                    {"role": "system", "content": "You are a helpful assistant."},
                    {"role": "user", "content": text_input}
                ],
                max_tokens=self.max_tokens,
                temperature=self.temperature,
                top_p=self.top_p,
                frequency_penalty=self.frequency_penalty,
                presence_penalty=self.presence_penalty
            )
            
            # Return the response text
            return response['choices'][0]['message']['content'].strip()

        except openai.error.OpenAIError as e:
            # Print the error and return None
            print(Fore.RED + f"Error while interacting with OpenAI API: {e}" + Style.RESET_ALL)
            return None

    def set_configuration(self, max_tokens=None, temperature=None, top_p=None, frequency_penalty=None, presence_penalty=None):
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
    gpt_client.set_configuration(max_tokens=1500, temperature=0.6)

    # Example input text
    input_text = "What is data sciense?"

    # Get response from ChatGPT
    response_text = gpt_client.get_response(input_text)

    # Print the response if it exists
    if response_text:
        print(Fore.YELLOW + "\nChatGPT Response: \n" + Style.RESET_ALL + response_text)
        print("")
    else:
        print("No response received.")
