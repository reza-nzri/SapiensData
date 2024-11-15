import axios from 'axios';
import Cookies from 'js-cookie';

const URL = "https://localhost:7198/api/Auth/user-login"

const SendLoginApi = async (username, password) => {
  try {
    const data = {
      username: username,
      password: password,
    };

    // Send the POST request using axios
    const response = await axios.post(URL, data);

    // Assuming the response contains a token or some data that you want to save in a cookie
    const { token } = response.data;

    const thirtyMinutes = 30 / (60 * 24); // 30 minutes converted to days
    // Save the token in a cookie (or any other data you need)
    Cookies.set('authToken', token, { expires: thirtyMinutes, path: '' });

    return response.status;
  } catch (error) {
    console.error("Error sending post request:", error);
  }
};

export default SendLoginApi;
