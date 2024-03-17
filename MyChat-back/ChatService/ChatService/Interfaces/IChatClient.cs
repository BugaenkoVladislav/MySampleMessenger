namespace ChatService.Interfaces;

public interface IChatClient
{
    Task SendForGroup<TMessageType>(string user, string sender, TMessageType message);
    Task SendForUser<TMessageType>(string user, string sender, TMessageType message);
}