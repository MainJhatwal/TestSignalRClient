using Microsoft.AspNetCore.SignalR.Client;
using static System.Net.WebRequestMethods;

var baseURL= "https://localhost:7261/MhcNotificationHub";
var hubConnection = new HubConnectionBuilder()
              .WithUrl(baseURL)
            .WithAutomaticReconnect(new[] { TimeSpan.Zero, TimeSpan.Zero, TimeSpan.FromSeconds(10) })
    .Build();

hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
{

        var newMessage = $"{user}: {message}";
        Console.WriteLine(newMessage);
});

await hubConnection.StartAsync();

Console.WriteLine("Connected to SignalR hub. Press any key to exit.");
Console.ReadKey();

await hubConnection.StopAsync();