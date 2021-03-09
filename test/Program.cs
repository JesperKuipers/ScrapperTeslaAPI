using System;
using System.Threading.Tasks;
using OtpNet;
using TeslaAuth;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = "";
            string password = "";
            string mfaCode = null;
            TeslaAccountRegion region = TeslaAccountRegion.Unknown;

            Console.WriteLine("----------------------=== Access Token ===-----------------------------\n");

            var authHelper = new TeslaAuthHelper("DataGrabberTeslaAPI/1.0");
            var tokens = authHelper.AuthenticateAsync(username, password, mfaCode, region).Result;
            Console.WriteLine("token: " + tokens);
            Console.WriteLine("Access token: " + tokens.AccessToken);
            //Console.WriteLine("Refresh token: " + tokens.RefreshToken);
            Console.WriteLine("Created at: " + tokens.CreatedAt);
            Console.WriteLine("Expires in: " + tokens.ExpiresIn);

            Console.WriteLine("\n----------------------=== Refresh Token ===-----------------------------\n");

            var newToken = authHelper.RefreshTokenAsync(tokens.RefreshToken, region).Result;
            Console.WriteLine("Refreshed Access token: " + newToken.AccessToken);
            //Console.WriteLine("New Refresh token: " + newToken.RefreshToken);
            Console.WriteLine("Refreshed token created at: " + newToken.CreatedAt);
            Console.WriteLine("Refreshed token expires in: " + newToken.ExpiresIn);
        }
    }
}
