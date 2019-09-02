using System.Threading.Tasks;

namespace ChatWebApi.Hubs
{
    public interface INotificationService
    {
        Task SendMessage<T>(string method, T message, int clientId);
    }
}