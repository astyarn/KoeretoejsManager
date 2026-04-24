using KoeretoejsManager.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace KoeretoejsManager.Api.Services
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly IUserTokenStore _userTokenStore;

        public CustomAuthStateProvider(IUserTokenStore userTokenStore)
        {
            _userTokenStore = userTokenStore;
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = _userTokenStore.GetToken();

            if (string.IsNullOrWhiteSpace(token))
            {
                return Task.FromResult(
                    new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()))
                );
            }

            //TODO Get Blazor to remember the correct user after refresh, by parsing the token and creating a ClaimsPrincipal with the correct claims.

            return Task.FromException<AuthenticationState>(new NotImplementedException());
        }

        public void NotifyAuthStateChanged()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

    }
}
