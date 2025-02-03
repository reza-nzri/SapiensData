import pytesseract
from PIL import Image, ImageFilter, ImageOps
import os
import traceback
from colorama import Fore, Style

class OcrExtractor:
    def __init__(self, username, image_path):
        """
        Initializes the OcrExtractor class to extract text from an image and save it to a file.
        
        Parameters:
        - username (str): The username used to construct the file path for saving OCR results.
        - image_path (str): The path of the image file from which text will be extracted.
        """
        self.username = username
        self.image_path = image_path
        self.output_path = f"src/_temp_files/{self.username}/_temp_final_ocr.txt"

        # Set the tesseract command path (Ensure the path is correct)
        pytesseract.pytesseract.tesseract_cmd = "C:/Program Files/Tesseract-OCR/tesseract.exe"

    # Custom error handler to display detailed error messages
    def handle_error(self, error):
        with open(self.output_path, "w", encoding="utf-8") as file:
            file.write("Tesseract OCR Error: \n")
            file.write(str(error) + "\n")
            file.write("Detailed Error Traceback:\n")
            file.write(traceback.format_exc())

    def preprocess_image(self):
        """
        Preprocess the image before extracting text by converting to grayscale,
        enhancing contrast, and applying filters.
        """
        try:
            img = Image.open(self.image_path)

            # Convert to grayscale
            img = img.convert('L')

            # Enhance contrast
            img = ImageOps.autocontrast(img)

            # Apply thresholding for better contrast
            img = img.point(lambda p: p > 180 and 255)

            # Apply a median filter to reduce noise
            img = img.filter(ImageFilter.MedianFilter(size=3))

            return img
        except Exception as e:
            self.handle_error(e)
            return None

    def extract_text(self):
        """
        Extract text from the image using Tesseract OCR.
        """
        try:
            # Preprocess the image
            img = self.preprocess_image()
            if img is None:
                return

            # Extract text using Tesseract OCR (German and English languages)
            text = pytesseract.image_to_string(img, lang='deu+eng')

            if text.strip():
                # Write the extracted text to the file
                with open(self.output_path, "w", encoding="utf-8") as file:
                    file.write(text)

                # Success message
                print(Fore.GREEN + "Text extraction and saving completed successfully!" + Style.RESET_ALL)
            else:
                # No text found in the image
                with open(self.output_path, "w", encoding="utf-8") as file:
                    file.write("No text found in the image.")

        except pytesseract.TesseractError as e:
            self.handle_error(e)
        except Exception as e:
            self.handle_error(e)

# Example usage
if __name__ == "__main__":
    # Get the username and image path from the user input
    username = input("Enter username: ")
    image_path = input("Enter the image path: ")

    # Check if the file exists
    if not os.path.exists(image_path):
        print(Fore.RED + f"Error: The file '{image_path}' does not exist." + Style.RESET_ALL)
        exit(1)

    # Create an instance of OcrExtractor and call the method to extract and save text
    ocr_extractor = OcrExtractor(username, image_path)
    ocr_extractor.extract_text()
