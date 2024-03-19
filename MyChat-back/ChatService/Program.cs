using ChatService.App;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR( );
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:5173")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
        });
});
var app = builder.Build();

app.UseCors("AllowSpecificOrigin");
app.MapHub<MyChat>("/chat");
app.Run();