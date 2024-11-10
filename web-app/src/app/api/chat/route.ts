import { NextResponse } from 'next/server';

export async function POST(req: Request) {
  try {
    const { message } = await req.json();
    const response = await fetch('http://localhost:4891/v1/chat/completions', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({
        model: 'Mistral Instruct',
        messages: [{ role: 'user', content: message }],
        max_tokens: 50,
        temperature: 0.28,
      }),
    });
    const data = await response.json();

    return NextResponse.json({ response: data.choices[0].message.content });
  } catch (error) {
    return NextResponse.json({ error: 'Failed to fetch response from GPT-4All' }, { status: 500 });
  }
}
