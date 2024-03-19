using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Server.App;

public static  class AuthOptions
{
    public const string AUDIENCE = "CoffeeAudience";
    public const string ISSUER = "CoffeeIssuer";
    private const string KEY = "MySuperSecrecKeyCOFFEEloveCookies123Tea";
    public static SymmetricSecurityKey GetSecurityKey() => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
}