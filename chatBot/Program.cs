using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder(args);

builder.Services.AddChatClient(chatClientBuilder =>
    chatClientBuilder.UseOpenAI(apiKey: "your-api-key-here"));

var host = builder.Build();

var chatClient = host.Services.GetRequiredService<IChatClient>();

var chatCompletion = await chatClient.CompleteAsync("What is .NET");

Console.WriteLine(chatCompletion.Message.Text);
