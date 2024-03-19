
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
    [HubMethodName("SendToUser")]
    public async Task SendMessageToUser(long idUser, string message)
    {
        var sender = Context.User.Identity.Name;
        var client = new HttpClient();
        var result = await client.GetAsync($"http://localhost:5221/api/Authorization/GetUserFromId/{idUser}");
        var content = await result.Content.ReadAsStringAsync();
        var user = JsonConvert.DeserializeObject<User>(content);
        await this.Clients.User(user.Username).SendForUser(user:user.Username, message:message, sender:sender);
    }
        
    
}