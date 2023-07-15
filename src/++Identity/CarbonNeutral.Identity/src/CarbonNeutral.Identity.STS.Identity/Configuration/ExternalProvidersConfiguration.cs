// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.
using Duende.IdentityServer;

namespace CarbonNeutral.Identity.STS.Identity.Configuration
{
    public class ExternalProvidersConfiguration
    {
        public bool UseGitHubProvider { get; set; }
        public string GitHubClientId { get; set; }
        public string GitHubClientSecret { get; set; }
        public string GitHubCallbackPath { get; set; }

        public bool UseAzureAdProvider { get; set; }
        public string AzureAdClientId { get; set; }
        public string AzureAdSecret { get; set; }
        public string AzureAdTenantId { get; set; }
        public string AzureInstance { get; set; }
        public string AzureAdCallbackPath { get; set; }
        public string AzureDomain { get; set; }

        public bool UseDiscordProvider {get;set;}
        public string DiscordClientId { get; set; }
        public string DiscordClientSecret { get; set; }
        public string DiscordSignInScheme { get; set; } = IdentityServerConstants.ExternalCookieAuthenticationScheme;
        
        public bool UseSteamProvider {get;set;}
        public string SteamApplicationKey {get;set;}
        public string SteamSignInScheme { get; set; } = IdentityServerConstants.ExternalCookieAuthenticationScheme;
    }
}








