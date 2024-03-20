namespace ChatService.Interfaces;

public interface IChatClient
{
    Task SendForAll(string message, string sender);
}