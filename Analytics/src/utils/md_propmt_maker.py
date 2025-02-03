import os
import json
import datetime
from colorama import Fore, Style


class MdPropmtMaker:
    def __init__(self, username):
      self.username = username  # Store the username
      self.markdown_file_path1 = 'dataset/json_structure/json_structure_prompt.md'
      self.json_file_path1 =  'dataset/json_structure/json_structure.json'
      # Dynamically create the output file name with current timestamp
      self.output_dir = os.path.abspath(f'src/_temp_files/{self.username}')  # Ensure the path is absolute and correct 
      timestamp = datetime.datetime.now().strftime("%Y%m%d_%H%M%S%f") # %f includes microseconds, which are the first 3 digits of nanoseconds
      self.output_file_path = os.path.join(self.output_dir, f"_temp_final_promp_{timestamp}.md")

    def read_markdown(self):
        """Read the content of the markdown file."""
        with open(self.markdown_file_path1, 'r', encoding='utf-8') as file:
            return file.read()

    def read_json(self):
      """Read the JSON content."""
      with open(self.json_file_path1, 'r', encoding='utf-8') as file:
          return json.load(file)
          
    def read_structure_example(self):
      """Read the content of the structure_example.json file."""
      example_json_path = 'dataset/json_structure/structure_example.json'
      with open(example_json_path, 'r', encoding='utf-8') as file:
          return json.load(file)

    def read_ocr_text(self):
      """Read the content of the _temp_final_ocr.txt file."""
      ocr_text_path = f'src/_temp_files/{self.username}/_temp_final_ocr.txt'
      with open(ocr_text_path, 'r', encoding='utf-8') as file:
          return file.read()

    def process_markdown(self, markdown_content: str, json_content: dict, example_content: dict, ocr_content: str):
      """Process markdown and insert json, example json, and OCR content."""
      json_str = json.dumps(json_content, indent=4)
      example_json_str = json.dumps(example_content, indent=4)

      # Look for the specific markers to insert content
      markdown_content = markdown_content.replace("**json_structure.json:**\n\n```json\n\n```\n", f"**json_structure.json:**\n\n```json\n{json_str}\n```\n")
      markdown_content = markdown_content.replace("json_structure_example.json:\n\n```json\n\n```\n", f"json_structure_example.json:\n\n```json\n{example_json_str}\n```\n")
      markdown_content = markdown_content.replace("**Input OCR-Text from Receipt:**\n\n```txt\n\n```\n", f"**Input OCR-Text from Receipt:**\n\n```txt\n{ocr_content}\n```\n")

      return markdown_content

    def save_processed_markdown(self, processed_content: str):
        """Save the processed content to the output file."""
        # Ensure the output directory exists
        os.makedirs(os.path.dirname(self.output_file_path), exist_ok=True)
        with open(self.output_file_path, 'w', encoding='utf-8') as file:
            file.write(processed_content)

    def run(self):
        """Execute the full processing workflow."""
        print("\nReading markdown and JSON files...")
        markdown_content = self.read_markdown()
        json_content = self.read_json()
        example_content = self.read_structure_example()  # Read the example JSON file
        ocr_content = self.read_ocr_text()  # Read the OCR text file

        print("Processing the markdown...")
        processed_content = self.process_markdown(markdown_content, json_content, example_content, ocr_content)

        print("Saving the processed markdown...")
        self.save_processed_markdown(processed_content)
        print(Fore.YELLOW + "Final markdown saved to: " + Style.RESET_ALL + f"{self.output_file_path}\n")


if __name__ == "__main__":
  """Execute the full processing workflow."""
  # Get the username as input
  username = input("\nEnter the username: ").strip()
    
  processor = MdPropmtMaker(username)
  processor.run()
