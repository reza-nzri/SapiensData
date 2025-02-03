import axios from 'axios';
import SendLoginApi from './Login';

const URL = "https://localhost:7198/api/Auth/register-user"

const sendRegisterApi = async (username, password, email, firstName, lastName) => {
  try {
    const data = {
        username: username,
        password: password,
        email: email,
        firstName: firstName,
        lastName: lastName
    };

    // Send the POST request using axios
    const response = await axios.post(URL, data);

    if (response.status != 200) {
        return response.status;
    }

    return await SendLoginApi(username, password);
} catch (error) {
    console.error("Error sending post request:", error);
  }
};

export default sendRegisterApi;
