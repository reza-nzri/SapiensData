interface ChatMessagesProps {
  messages: { sender: 'user' | 'bot'; text: string }[];
}

export default function ChatMessages({ messages }: ChatMessagesProps) {
  return (
    <div className="space-y-4">
      {messages.map((msg, idx) => (
        <div
          key={idx}
          className={`p-4 rounded-lg ${msg.sender === 'user' ? 'bg-blue-500 text-white' : 'bg-gray-300 text-black'}`}
        >
          {msg.text}
        </div>
      ))}
    </div>
  );
}
