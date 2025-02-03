import fitz  # PyMuPDF
import os
from colorama import Fore, Style

class PDFTextExtractor:
    def __init__(self, username, pdf_path):
        """
        Initializes the PDFTextExtractor with a PDF file path and username.
        
        :param username: The username for constructing the output file path.
        :param pdf_path: Path to the PDF file for text extraction.
        """
        self.username = username
        self.pdf_path = pdf_path
        self.output_path = f"src/_temp_files/{self.username}/_temp_final_ocr.txt"  # Path to save extracted text

    def extract_text_from_pdf(self):
        """
        Extracts text from the PDF using PyMuPDF (fitz).
        
        :return: Extracted text from the PDF.
        """
        try:
            # Open the provided PDF file
            pdf_document = fitz.open(self.pdf_path)

            extracted_text = ""
            for page_num in range(pdf_document.page_count):
                page = pdf_document.load_page(page_num)  # Load each page
                page_text = page.get_text("text")  # Extract text from the page
                extracted_text += f"--- Page {page_num + 1} ---\n{page_text}\n"

            return extracted_text
        except Exception as e:
            print(Fore.RED + f"Error during PDF text extraction: {e}" + Style.RESET_ALL)
            return ""

    def save_extracted_text(self, extracted_text):
        """
        Save the extracted text to a file.
        
        :param extracted_text: The text to be saved.
        """
        try:
            # Ensure the directory exists
            output_dir = os.path.dirname(self.output_path)
            os.makedirs(output_dir, exist_ok=True)  # Create the directory if it doesn't exist

            # Write the extracted text to the file (overwrite if it exists)
            with open(self.output_path, "w", encoding="utf-8") as file:
                file.write(extracted_text)

            print(Fore.GREEN + "Text extraction and saving completed successfully!" + Style.RESET_ALL)
        except Exception as e:
            print(Fore.RED + f"Error saving extracted text: {e}" + Style.RESET_ALL)

    def run(self):
        """
        Runs the text extraction process and saves the result.
        """
        # Extract text from the provided PDF file
        extracted_text = self.extract_text_from_pdf()

        if extracted_text.strip():  # Only save if OCR text is not empty
            # Save the extracted text
            self.save_extracted_text(extracted_text)
        else:
            print(Fore.RED + "No text was extracted from the PDF." + Style.RESET_ALL)


# Example Usage
if __name__ == "__main__":
    # Prompt the user for the username and PDF path input
    username = input("Enter username: ")
    pdf_path = input("Enter the PDF path: ")

    # Create an instance of PDFTextExtractor and run the text extraction
    text_extractor = PDFTextExtractor(username, pdf_path)
    text_extractor.run()
