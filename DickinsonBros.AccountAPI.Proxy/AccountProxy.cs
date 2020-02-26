using DickinsonBros.AccountAPI.Abstractions;
using DickinsonBros.DurableRest;
using Microsoft.Extensions.Options;
using RestSharp;
using System.Threading.Tasks;

namespace DickinsonBros.AccountAPI.Proxy
{
    public class AccountProxy : IAccountProxy
    {
        internal const string RESOURCE_V1 = "/api/v1/Account/";
        internal readonly string BASE_URL = "";
        internal readonly IDurableRestService _durableRestService;
        public AccountProxy(IDurableRestService durableRestService, IOptions<AccountProxyOptions> accountProxyOptions)
        {
            _durableRestService = durableRestService;
            BASE_URL = baseURL;
        }
        public async Task<IRestResponse<JWTResponse>> CreateAsync(CreateAccountRequest createAccountRequest)
        {
            var restRequest = new RestRequest();
            restRequest.Method = Method.POST;
            restRequest.Resource = RESOURCE_V1 + "Create";
            restRequest.AddJsonBody(createAccountRequest);

            return await _durableRestService.ExecuteAsync<JWTResponse>(restRequest, BASE_URL, 1);
        }
        public async Task<IRestResponse<JWTResponse>> LoginAsync(LoginRequest createAccountRequest)
        {
            var restRequest = new RestRequest();
            restRequest.Method = Method.POST;
            restRequest.Resource = RESOURCE_V1 + "Login";
            restRequest.AddJsonBody(createAccountRequest);

            return await _durableRestService.ExecuteAsync<JWTResponse>(restRequest, BASE_URL, 1);
        }
        public async Task<IRestResponse<JWTResponse>> RefreshTokenAsync(string baseURL, RefreshTokenRequest refreshTokenRequest, string authorization)
        {
            await Task.CompletedTask;
            return null;
        }
        public async Task<IRestResponse> RequestPasswordResetEmailAsync(RequestPasswordResetEmailRequest requestPasswordResetEmailRequest)
        {
            await Task.CompletedTask;
            return null;
        }
        public async Task<IRestResponse> ResetPasswordAsync(ResetPasswordRequest resetPasswordRequest, string authorization)
        {
            await Task.CompletedTask;
            return null;
        }
        public async Task<IRestResponse> UpdateEmailPreferenceWithTokenAsync(UpdateEmailPreferenceWithTokenRequest updateEmailPreferenceWithTokenRequest)
        {
            await Task.CompletedTask;
            return null;
        }
        public async Task<IRestResponse> UpdateEmailPreferenceAsync(UpdateEmailPreferenceRequest updateEmailPreferenceRequest, string authorization)
        {
            await Task.CompletedTask;
            return null;
        }
        public async Task<IRestResponse> ActivateEmailAsync(ActivateEmailRequest activateEmailRequest)
        {
            await Task.CompletedTask;
            return null;
        }
        public async Task<IRestResponse> UpdatePasswordAsync(UpdatePasswordRequest updatePasswordRequest, string authorization)
        {
            await Task.CompletedTask;
            return null;
        }
    }
}
