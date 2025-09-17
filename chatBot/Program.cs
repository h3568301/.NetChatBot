using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.AI;

var builder = Host.CreateApplicationBuilder();

builder.Services.AddChatClient(new OllamaChatClient(new Uri("http://localhost:11434"), "llama3"));

var app = builder.Build();

var chatClient = app.Services.GetRequiredService<IChatClient>();

var chatHistory = new List<ChatMessage>();

while (true)
{
    Console.WriteLine("Prompt:");
    var prompt = Console.ReadLine();
    chatHistory.Add(new ChatMessage(ChatRole.User, prompt));

    Console.WriteLine("Response:");
    var chatResponse = "";
    await foreach (var item in chatClient.GetStreamingResponseAsync(chatHistory)) {
        Console.Write(item);
        chatResponse += item;
    }
    chatHistory.Add(new ChatMessage(ChatRole.Assistant, chatResponse));
    Console.WriteLine();
 }