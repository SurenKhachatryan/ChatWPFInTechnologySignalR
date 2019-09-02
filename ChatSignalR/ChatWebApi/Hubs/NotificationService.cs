using BLL.Services.UserServices;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWebApi.Hubs
{
    public class NotificationService : INotificationService
    {
        private readonly IHubContext<NotificationHub> _hub;
        private readonly IUserService _userService;

        public NotificationService(IHubContext<NotificationHub> hub, IUserService userService)
        {
            _hub = hub;
            _userService = userService;
        }


        public async Task SendMessage<T>(string method, T message, int clientId)
        {
            var connections = await GetConnections(clientId);

            if (!connections.Any())
                return;

            await _hub.Clients.Clients(connections).SendAsync(method, message);
        }

        private async Task<List<string>> GetConnections(int clientId)
        {
            var userTokens = await _userService.GetUserSessions(clientId);

            if (!userTokens.Any())
                return new List<string>();

            return GetConnectionsIds(userTokens.Select(x => x.Token).ToList());
        }

        private static List<string> GetConnectionsIds(List<string> userTokens)
        {
            return NotificationHub.Connections.Where(x => userTokens.Contains(x.Value)).Select(x => x.Key).ToList();
        }

    }
}
