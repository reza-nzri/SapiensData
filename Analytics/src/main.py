# Analytics\src\main.py

import os
import sys  # to handle command-line arguments
from colorama import Fore, Style

# Import necessary utility classes from the utils module
from utils import CLI, ChatGPTClient, JsonUpdater, FolderChecker, JsonFormatter, \
                   MdPropmtMaker, MetadataExtractor, OcrExtractor, PDFTextExtractor, ReceiptSender, \
                   TempFileDeleter, TextAutoCorrector, TextCleaner


def main(source_image):
    """
    Main function to handle the workflow of processing a receipt image and 
    performing various tasks such as extraction, correction, and response generation.
    
    This function processes the receipt and ensures that each task is completed successfully 
    before moving to the next task. If any task fails, an error message is displayed and 
    the process stops.
    """
    # Step 1: Initialize the CLI interface and show the welcome message
    cli = CLI()
    cli.welcome_message()

    # Step 2: Extract metadata from the receipt (filename, path, username)
    receipt_generator = MetadataExtractor(source_image)
    receipt_path = receipt_generator.extract_receipt_path()  # Get the path of the receipt
    receipt_filename = receipt_generator.extract_receipt_filename()  # Get the filename of the receipt
    username = receipt_generator.extract_username()  # Extract the username for folder structure

    # Step 3: Check if the folder for the username exists
    folder_checker = FolderChecker(username)
    folder_checker.run()  # Ensure that the folder for the username exists

    # Step 4: Validate the file extension (ensure only allowed formats)
    allowed_extensions = [".jpg", ".jpeg", ".png", ".pdf"]
    file_extension = os.path.splitext(receipt_filename)[1].lower()  # Get the file extension
    if file_extension not in allowed_extensions:
        print(Fore.RED + f"Error: Invalid file extension. Only the following are allowed: {', '.join(allowed_extensions)}" + Style.RESET_ALL)
        exit(1)

    # Step 5: If the file is a PDF, proceed with PDF text extraction
    if file_extension == ".pdf":
        text_extractor = PDFTextExtractor(username, receipt_path)
        text_extractor.run()  # Extract text from the PDF

    # Step 6: Ensure the receipt file exists before proceeding
    if not os.path.exists(receipt_path):
        print(Fore.RED + f"Error: The file '{receipt_path}' does not exist." + Style.RESET_ALL)
        exit(1)

    # Step 7: Extract text using OCR if not already extracted
    ocr_extractor = OcrExtractor(username, receipt_path)
    ocr_extractor.extract_text()  # Perform OCR extraction

    # Step 8: Clean the extracted text (auto-correction and text formatting)
    text_cleaner = TextAutoCorrector(username)
    text_cleaner.load_and_process_text()  # Auto-correct the text

    # Step 9: Further process the cleaned text (for additional formatting)
    text_cleaner = TextCleaner(username)
    text_cleaner.load_and_process_text()  # Perform further text cleaning

    # Step 10: Generate a prompt for the AI (GPT model)
    processor = MdPropmtMaker(username)
    processor.run()  # Generate the Markdown prompt for GPT

    # Step 11: Initialize the ChatGPT client, configure it, and get a response
    gpt_client = ChatGPTClient(username)
    gpt_client.set_configuration(max_tokens=2048, temperature=0.2)  # Set configuration for GPT

    # Step 12: Create an instance of JsonFormatter for the given username and call the method to load, format, and save the JSON file
    json_formatter = JsonFormatter(username)
    json_formatter.load_and_format_json()

    # Step 13: Get the response from GPT based on OCR text
    response_text = gpt_client.get_response()

    # Step 14: Check if the response was successfully generated and saved
    if response_text:
        print(Fore.YELLOW + "\nResponse has been saved as _temp_receipt.json." + Style.RESET_ALL)
    else:
        print(Fore.RED + "No response received." + Style.RESET_ALL)

    # Step 15: Add metadata to the JSON file
    json_updater = JsonUpdater(username, receipt_filename)
    json_updater.update_json_with_metadata()  # Update the JSON with metadata

    # Step 16: Send the receipt (e.g., email, API, etc.)
    sender = ReceiptSender(username)
    sender.send_receipt()  # Send the receipt

    # Step 17: If all tasks were successful, delete the temporary files for the user
    temp_deleter = TempFileDeleter(username)
    temp_deleter.run()  # Delete the temporary files and user-specific folder


# Example usage
if __name__ == "__main__":
    # Check if the source image path is provided as a command-line argument
    if len(sys.argv) != 2:
        print(Fore.RED + "Error: Please provide the source image path as an argument." + Style.RESET_ALL)
        sys.exit(1)
    
    # Get the source image path from the command-line argument
    source_image = sys.argv[1]
    
    # Call the main function with the source image path 
    main(source_image)
