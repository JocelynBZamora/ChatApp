using Microsoft.AspNetCore.SignalR;

namespace MAUISignalRSample.Server
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string message)
        {
            Console.WriteLine(message);
            await Clients.All.SendAsync("MensajeResivido", message);
        }
    }
}
