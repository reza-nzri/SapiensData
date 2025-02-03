import axios from 'axios';
import Cookies from 'js-cookie';

const URL = "https://localhost:7198/api/Receipts"; // Replace with your actual API URL

const SendImageApi = async (imageFile) => {
  try {
    // Create FormData to send the image in the request body
    const formData = new FormData();
    formData.append('Image', imageFile, imageFile.name); // Add image to form data

    // Retrieve the JWT token from cookies
    const token = Cookies.get('authToken'); 

    // Send POST request with axios
    const response = await axios.post(URL, formData, {
      headers: {
        'Accept': '*/*', // Accept header for all content types
        'Authorization': `Bearer ${token}`, // Authorization with Bearer token
        'Content-Type': 'multipart/form-data', // Content type for file upload
      },
    });

    // Return the response status code
    return response.status;
  } catch (error) {
    console.error('Error sending post request:', error);
    throw error; // Re-throw the error to be handled elsewhere if necessary
  }
};

export default SendImageApi;