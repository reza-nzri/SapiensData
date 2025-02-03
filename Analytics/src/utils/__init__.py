# Analytics\src\utils\__init__.py

# Importing various utility classes and functions
from .cli import CLI
from .image_selector import ImageSelector
from .OpenAi.chatgpt_client import ChatGPTClient
from .add_metadata_to_json import JsonUpdater
from .folder_check import FolderChecker
from .json_formatter import JsonFormatter
from .md_propmt_maker import MdPropmtMaker
from .metadata_extractor import MetadataExtractor
from .ocr_extractor import OcrExtractor
from .pdf_ocr_extractor import PDFTextExtractor
from .post_receipt import ReceiptSender
from .temp_file_deleter import TempFileDeleter
from .text_auto_corrector import TextAutoCorrector
from .text_cleaner import TextCleaner
from .remove_second_receipt import JsonReceiptRemover


__all__ = [
    'CLI',  # Command Line Interface handler
    'ImageSelector',  # Image selection handler
    'ChatGPTClient',  # Interface with OpenAI's GPT-3/4 for various tasks
    'JsonUpdater',  # Update JSON files with metadata
    'FolderChecker',  # Check and validate folder structures
    'JsonFormatter',  # Format and clean JSON data
    'MdPropmtMaker',  # Generate Markdown prompts
    'MetadataExtractor',  # Extract metadata from documents
    'OcrExtractor',  # Extract text from images via OCR
    'PDFTextExtractor',  # Extract text from PDFs without OCR
    'ReceiptSender',  # Handle receipt sending functionality
    'TempFileDeleter',  # Delete temporary files associated with a user
    'TextAutoCorrector',  # Correct spelling and grammar errors in text
    'TextCleaner',  # Clean and format text for better readability
    'JsonReceiptRemover'
]
