"use client";
import { useState } from 'react';
import ChatInput from '@/components/ChatInput';
import ChatMessages from '@/components/ChatMessages';

// Define the message type with strict sender type
type Message = { sender: 'bot' | 'user'; text: string };

export default function ChatPage() {
  const [messages, setMessages] = useState<Message[]>([
    { sender: 'bot', text: 'Hello! How can I help you today?' }
  ]);

  const sendMessage = async (message: string) => {
    setMessages([...messages, { sender: 'user', text: message }]);
    try {
      const response = await fetch('/api/chat', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ message }),
      });
      const data = await response.json();
      setMessages([...messages, { sender: 'user', text: message }, { sender: 'bot', text: data.response }]);
    } catch (error) {
      console.error('Error:', error);
    }
  };

  return (
    <div className="flex flex-col h-screen bg-gray-50">
      <div className="flex-1 overflow-y-auto p-4">
        <ChatMessages messages={messages} />
      </div>
      <ChatInput onSend={sendMessage} />
    </div>
  );
}