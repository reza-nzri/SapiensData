# Analytics\src\utils\cli.py

from colorama import Fore, Style


class CLI:
    def __init__(self):
        self.threshold = 0.0  # Default threshold
    
    def welcome_message(self):
        # Display a welcome message
        print(Fore.GREEN + "\nWelcome to the SapiensData Project!" + Style.RESET_ALL)
        print("This tool will help you extract and analyze text from your receipts.")
        print(Fore.CYAN + "Please follow the prompts to get started." + Style.RESET_ALL)
        print("")    

    def get_threshold(self):
        while True:
            try:
                user_input = input("Please enter the confidence threshold (0-100): ")
                self.threshold = float(user_input)
                if 0 <= self.threshold <= 100:
                    break
                else:
                    print("Error: Threshold must be between 0 and 100. Please try again.")
            except ValueError:
                print("Invalid input. Please enter a numeric value.")
