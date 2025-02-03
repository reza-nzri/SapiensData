import axios from 'axios';
import Cookies from 'js-cookie';

const URL = "https://localhost:7198/api/Receipts"; // Replace with your actual API URL

const GiveImageApi = async (offset) => {
  try {
    // Retrieve the JWT token from cookies
    const token = Cookies.get('authToken'); 

    // Send POST request with axios
    const response = await axios.get(`${URL}/${offset}`, {
      headers: {
        'Accept': '*/*', // Accept header for all content types
        'Authorization': `Bearer ${token}`, // Authorization with Bearer token
      },
    });

    // Return the response status code
    return response;
  } catch (error) {
    console.error('Error sending post request:', error);
    throw error; // Re-throw the error to be handled elsewhere if necessary
  }
};

export default GiveImageApi;