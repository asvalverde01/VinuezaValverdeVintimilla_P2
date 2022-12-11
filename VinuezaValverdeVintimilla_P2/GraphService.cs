﻿using Azure.Identity;
using Microsoft.Graph;

namespace VinuezaValverdeVintimilla_P2
{
    internal class GraphService
    {
        private readonly string[] _scopes = new[] { "User.Read" };
        private const string TenantId = "585a4d92-db1d-4bbb-b5ac-c5299e3894e3";
        private const string ClientId = "3f04eb53-b2a6-4f9f-93b8-89497245ffec";
        private GraphServiceClient _client;


        public GraphService()
        {
            Initialize();
        }

        private void Initialize()
        {
            // assume Windows for this sample
            if (OperatingSystem.IsWindows())
            {
                var options = new InteractiveBrowserCredentialOptions
                {
                    TenantId = TenantId,
                    ClientId = ClientId,
                    AuthorityHost = AzureAuthorityHosts.AzurePublicCloud,
                    RedirectUri = new Uri("https://localhost"),
                };

                InteractiveBrowserCredential interactiveCredential = new(options);
                _client = new GraphServiceClient(interactiveCredential, _scopes);
            }
            else
            {
                // TODO: Add iOS/Android support
            }
        }

        public async Task<User> GetMyDetailsAsync()
        {
            try
            {
                return await _client.Me.Request().GetAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading user details: {ex}");
                return null;
            }
        }
        
        

    }
}
