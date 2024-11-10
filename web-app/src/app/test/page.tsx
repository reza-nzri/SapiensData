// src/pages/index.tsx
'use client'
import { useState } from 'react';
import axios from 'axios';

export default function Home() {
  const [response, setResponse] = useState<string | null>(null);

  const handlePostRequest = async () => {
    try {
      // const res = await axios.post('http://localhost:4891/v1/chat/completions', {
      //   model: "Mistral Instruct",
      //   messages: [{ role: "user", content: "Who is Lionel Messi?" }],
      //   max_tokens: 50,
      //   temperature: 0.28,
      // }, {
      //   headers: { 'Content-Type': 'application/json' }
      // });

      const res = await axios.get("https://localhost:7198/api/Expenses");
      
      setResponse(JSON.stringify(res.data, null, 2)); // Format JSON for readability
    } catch (error) {
      setResponse('Error fetching data');
      console.error(error);
    }
  };

  return (
    <div className="flex flex-col items-center justify-center min-h-screen bg-gray-900 p-4">
      <h1 className="text-2xl font-bold mb-4">Axios POST Request Example</h1>
      <button
        onClick={handlePostRequest}
        className="px-4 py-2 bg-blue-600 text-white rounded-lg hover:bg-blue-700"
      >
        Send POST Request
      </button>
      <div className="mt-6 w-full max-w-md bg-red-800- p-4 rounded-lg shadow-md">
        <h2 className="text-lg font-semibold mb-2">Response:</h2>
        <pre className="whitespace-pre-wrap">{response || 'No data yet'}</pre>
      </div>
    </div>
  );
}
