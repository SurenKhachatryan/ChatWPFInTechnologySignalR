using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace ChatWebApi.Hubs
{
    public class NotificationHub : Hub
    {
        private static ConcurrentDictionary<string, string> _connections = new ConcurrentDictionary<string, string>();
        public static ConcurrentDictionary<string, string> Connections { get { return _connections; } }


        public override Task OnConnectedAsync()
        {
            var connectionId = Context.ConnectionId;

            var token = Context.GetHttpContext().Request.Query["Token"].ToString();

            if (token != null)
            {
                _connections.AddOrUpdate(connectionId, token, (Key, Value) => Value);
            }

            return base.OnConnectedAsync();
        }


        public override Task OnDisconnectedAsync(Exception exception)
        {
            var connectionId = Context.ConnectionId;

            _connections.TryRemove(connectionId, out var Token);

            return base.OnDisconnectedAsync(exception);
        }

    }
}
