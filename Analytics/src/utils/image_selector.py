import os
import tkinter as tk
from tkinter import filedialog
from colorama import Fore, Style

class ImageSelector:
    def __init__(self):
        self.image_path = None
        
    def get_image_input(self):
        choice = input("Would you like to:\n1) Select an image from your PC\n2) Provide a file path\nChoose 1 or 2: ")
        if choice == '1':
            return self.select_image()
        elif choice == '2':
            self.image_path = input("\nPlease enter the full path to your image: ")
            if not os.path.isfile(self.image_path):
                print(Fore.RED + "Error: File not found. Please check the path and try again." + Style.RESET_ALL)
                return None
            return self.image_path
        else:
            print(Fore.RED + "Invalid choice. Please try again." + Style.RESET_ALL)
            return None    

    def select_image(self):
        # Create the main tkinter window
        root = tk.Tk()
        root.title("Image Selector")

        # Prompt user to select an image
        print(Fore.YELLOW + "\nPlease select an image from your PC." + Style.RESET_ALL)

        # Set the default directory to dataset/reciepts/in_process/
        default_dir = os.path.join(os.getcwd(), 'dataset', 'reciepts', 'in_process')

        # Open file dialog and return the selected file path
        image_path = filedialog.askopenfilename(title="Select an Image",
                                                 initialdir=default_dir,
                                                 filetypes=[("Image Files", "*.jpg;*.jpeg;*.png;*.bmp;*.gif")])
        
        root.destroy()  # Close the Tkinter window after selection
        return image_path

