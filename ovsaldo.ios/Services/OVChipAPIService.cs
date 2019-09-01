using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OvChipApi;
using OvChipApi.Responses;
using Plugin.SecureStorage;

namespace OVSaldo.ios.Services
{
    public class OVChipAPIService
    {
        private OvClient client = new OvClient();
        private DateTime expirationDate;

        private static readonly Lazy<OVChipAPIService> lazy = new Lazy<OVChipAPIService> (() => new OVChipAPIService());

        public static OVChipAPIService Instance { get { return lazy.Value; } }

        public static string AttachCardURL = "https://www.ov-chipkaart.nl/mijn-ov-chip/mijn-ov-chipkaarten/kaart-koppelen.htm";

        public async Task Authorize()
        {
            String username = CrossSecureStorage.Current.GetValue("username");
            String password = CrossSecureStorage.Current.GetValue("password");

            Debug.WriteLine("Authorizing...");
            await client.LoginAsync(username, password);

            expirationDate = DateTime.Now.AddSeconds(client.OAuthTokens.ExpiresIn);
            Debug.WriteLine("New token will expire on " + expirationDate.ToString("dd/MM/yyyy HH:mm:ss"));
        }

        private async Task EnsureAuthorized()
        {

            if (client.IsAuthenticated && (expirationDate - DateTime.Now).TotalMinutes > 5)
            {
                return;
            }
            else
            {
                await Authorize();
            }
        }

        public async Task<List<OvCardResponse>> GetCardsAsync()
        {
            await EnsureAuthorized();
            Response<List<OvCardResponse>> result = await client.GetCardsAsync();
            return result.Data;
        }

        public async Task<TransactionResponse> GetTransactionsAsync(string mediumId)
        {
            await EnsureAuthorized();
            Response<TransactionResponse> result = await client.GetTransactionsAsync(mediumId);
            return result.Data;
        }
    }
}
