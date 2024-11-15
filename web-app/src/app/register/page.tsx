'use client'
import { useState } from 'react';
import sendRegisterApi from '../../api/Register';
import sendLoginApi from '@/api/Login';
import { useRouter } from 'next/navigation';

export default function RegisterPage() {
  const router = useRouter();

  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [email, setEmail] = useState('');
  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');

  const [error, setError] = useState('');


  const handleRegister = async (e) => {
    e.preventDefault(); // Prevent default form submission

    if (!username || !password || !email || !firstName || !lastName) {
      alert("enter more information.");
      return;
    }

    setError('');  // Reset any previous error

    const res_status = await sendRegisterApi(username, password, email, firstName, lastName);

    if (res_status == 200) {
      await sendLoginApi(username, password);
      router.push("/myprofile");
    }
    else {
      setError('Register failed. Please try again.');
    }
  };

  return (
    <div className="flex items-center justify-center h-screen bg-gray-100">
      <div className="w-full max-w-md p-8 space-y-6 bg-white rounded-lg shadow-lg">
        <h2 className="text-2xl font-bold text-center text-gray-700">Register</h2>

        {error && <div className="text-red-500 text-center">{error}</div>}


        <form onSubmit={handleRegister} className="space-y-4">
          <div>
            <label htmlFor="username" className="block text-sm font-medium text-gray-600">Username</label>
            <input
              type="text"
              id="username"
              name="username"
              value={username}
              onChange={(e) => setUsername(e.target.value)}
              required
              className="w-full p-3 mt-2 border border-gray-300 rounded focus:outline-none focus:ring-2 focus:ring-blue-500 text-gray-600"
            />
          </div>

          <div>
            <label htmlFor="password" className="block text-sm font-medium text-gray-600">Password</label>
            <input
              type="password"
              id="password"
              name="password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              required
              className="w-full p-3 mt-2 border border-gray-300 rounded focus:outline-none focus:ring-2 focus:ring-blue-500 text-gray-600"
            />
          </div>

          <div>
            <label htmlFor="email" className="block text-sm font-medium text-gray-600">Email</label>
            <input
              type="email"
              id="email"
              name="email"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              required
              className="w-full p-3 mt-2 border border-gray-300 rounded focus:outline-none focus:ring-2 focus:ring-blue-500 text-gray-600"
            />
          </div>

          <div>
            <label htmlFor="firstname" className="block text-sm font-medium text-gray-600">First name</label>
            <input
              type="firstname"
              id="firstname"
              name="firstname"
              value={firstName}
              onChange={(e) => setFirstName(e.target.value)}
              required
              className="w-full p-3 mt-2 border border-gray-300 rounded focus:outline-none focus:ring-2 focus:ring-blue-500 text-gray-600"
            />
          </div>

          <div>
            <label htmlFor="lastname" className="block text-sm font-medium text-gray-600">Last name</label>
            <input
              type="lastname"
              id="lastname"
              name="lastname"
              value={lastName}
              onChange={(e) => setLastName(e.target.value)}
              required
              className="w-full p-3 mt-2 border border-gray-300 rounded focus:outline-none focus:ring-2 focus:ring-blue-500 text-gray-600"
            />
          </div>

          <button
            type="submit"
            className="w-full py-3 mt-6 text-white bg-blue-500 rounded-lg hover:bg-blue-600 focus:outline-none focus:ring-4 focus:ring-blue-300"
          >
            Login
          </button>
        </form>
      </div>
    </div>
  );
}
