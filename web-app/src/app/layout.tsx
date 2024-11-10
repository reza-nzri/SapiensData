import Link from 'next/link';
import "./globals.css";

export const metadata = {
  title: 'SapiensData Web App',
  description: 'A web app for AI and data science interactions',
};

export default function Layout({ children }: { children: React.ReactNode }) {
  return (
    <html lang="en">
      <body className="bg-gray-900">
        <nav className="p-4 bg-gray-800 text-white">
          <Link href="/" className="mr-4">Home</Link>
          <Link href="/chat" className="mr-4">AI Chat</Link>
        </nav>
        <main>{children}</main>
      </body>
    </html>
  );
}