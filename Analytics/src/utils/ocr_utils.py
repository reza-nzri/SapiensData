import cv2
import pytesseract
from PIL import Image

def make_image_ugly(path):
    # Load the image with OpenCV
    image = cv2.imread(path)

    # Convert to grayscale
    gray = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)

    # Apply thresholding
    _, thresh = cv2.threshold(gray, 150, 255, cv2.THRESH_BINARY)

    # Use PIL to convert back to an Image object for Tesseract
    processed_image = Image.fromarray(thresh)

    return processed_image

def give_image_text(path):
    processed_image = make_image_ugly(path)

    # Extract text
    text = pytesseract.image_to_string(processed_image, lang='deu')
    print("OCR Text Output:\n", text)