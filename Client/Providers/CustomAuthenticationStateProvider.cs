﻿using Blazor.SubtleCrypto;
using Blazored.LocalStorage;
using Bondlog.Shared.Domain.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Bondlog.Client.Providers
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService localStorageService;
        private readonly ICryptoService cryptoService;
        private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

        public CustomAuthenticationStateProvider(ILocalStorageService localStorageService, ICryptoService cryptoService)
        {
            this.localStorageService = localStorageService;
            this.cryptoService = cryptoService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var encryptedUserSession = await localStorageService.GetItemAsync<UserSessionModel>("UserData");
            if (encryptedUserSession is null)
                return await Task.FromResult(new AuthenticationState(_anonymous));


            var claimPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
            new Claim(ClaimTypes.Name,  await cryptoService.DecryptAsync(encryptedUserSession.Username!.ToString())),
            new Claim(ClaimTypes.Role, await cryptoService.DecryptAsync(encryptedUserSession.UserRole!.ToString()))
            }, "JwtAuth"));

            return await Task.FromResult(new AuthenticationState(claimPrincipal));
        }

        public void NotifyAuthenticationState()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}