
using ChatService.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using Server.Entities;

namespace ChatService.App;
using Microsoft.AspNetCore.SignalR;

public class MyChat:Hub<IChatClient>
{
    //отправляет сообщение в конкретный чат всем пользователям
    [Authorize]
    [HubMethodName("Send")]
    public async Task Send(string message, string userName)
    {
        await Clients.All.SendForAll(message:message,sender:userName);
    }
        
    
}