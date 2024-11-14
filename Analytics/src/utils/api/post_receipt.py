import os
import json
import requests
from colorama import Fore, init
from dotenv import load_dotenv

# Initialize colorama
init(autoreset=True)

# Load environment variables from .env file
load_dotenv('.env.dev')

class ReceiptSender:
    def __init__(self, username):
        self.username = username
        self.api_url = "https://localhost:7198/api/Receipts/receive-json-from-python" 
        self.api_key = os.getenv("SAPIENS_API_KEY")
        self.json_file_path = f"src/_temp_files/{self.username}/_temp_receipt.json"
        self.headers = {
            "Username": self.username,
            "Very-cool-api-key": self.api_key
        }

    def send_receipt(self):
        # Check if the JSON file exists
        if not os.path.exists(self.json_file_path):
            print(Fore.RED + f"Error: File {self.json_file_path} does not exist!")
            return

        # Load data from JSON file
        with open(self.json_file_path, 'r') as file:
            data = json.load(file)

        # Send the POST request with the JSON data
        response = requests.post(self.api_url, json=data, headers=self.headers, verify=False)

        # Check if the request was successful
        if response.status_code == 200:
            print(Fore.GREEN + "Success: Receipt data sent successfully.")
        else:
            print(Fore.RED + f"Error: Status code: {response.status_code} Text: {response.text}")

if __name__ == "__main__":
    # Replace 'your_username' with the actual username
    username = "string"

    # Create an instance of the ReceiptSender class and send the receipt
    sender = ReceiptSender(username)
    sender.send_receipt()
