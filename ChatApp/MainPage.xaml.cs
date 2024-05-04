using Microsoft.AspNetCore.SignalR.Client;

namespace ChatApp
{
    public partial class MainPage : ContentPage
    {
        private readonly HubConnection _connection;

        public MainPage()
        {
            InitializeComponent();

            _connection = new HubConnectionBuilder()
                .WithUrl("http://192.168.1.67:5296/chat")
                .Build();

            _connection.On<string>("MensajeResivido", (message) =>
            {
                chatMessage.Text += $"{Environment.NewLine}{message}";
            });

            Task.Run(() =>
            {
                Dispatcher.Dispatch(async () =>
                await _connection.StartAsync());
            });
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            await _connection.InvokeCoreAsync("EnviarMensaje", args: new[] { myChatMessage.Text });

            myChatMessage.Text = String.Empty;
        }
    }
}
