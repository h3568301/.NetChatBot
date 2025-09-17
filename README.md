# .NET ChatBot

A simple chat bot

## Setup

1. **Install Ollama** (if not already installed):
   - Visit [https://ollama.ai/](https://ollama.ai/) and follow installation instructions
   - Start Ollama service

2. **Download Llama3 model**:
   ```bash
   ollama pull llama3
   ```

3. **Clone and build the project**:
   ```bash
   git clone <repository-url>
   cd .NetChatBot
   dotnet build
   ```

## Usage

1. **Start Ollama service** (if not running):
   ```bash
   ollama serve
   ```

2. **Run the chatbot**:
   ```bash
   cd chatBot
   dotnet run
   ```

3. **Start chatting**:
   - The application will prompt you for input
   - Type your message and press Enter
   - The AI will respond with streaming output
   - Continue the conversation or press Ctrl+C to exit

## Configuration

The chatbot is configured to connect to Ollama running on `http://localhost:11434` with the `llama3` model. You can modify these settings in `Program.cs`:

```csharp
builder.Services.AddChatClient(new OllamaChatClient(new Uri("http://localhost:11434"), "llama3"));
```

## How It Works

1. The application creates a host with dependency injection
2. Configures an `IChatClient` using Ollama
3. Maintains a conversation history using `List<ChatMessage>`
4. For each user input:
   - Adds the user message to history
   - Sends the entire history to the AI model
   - Streams the response back to the console
   - Adds the AI response to history for context
