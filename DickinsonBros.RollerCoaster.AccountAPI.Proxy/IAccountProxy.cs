using DickinsonBros.RollerCoaster.AccountAPII.Abstractions;
using RestSharp;
using System.Threading.Tasks;

namespace DickinsonBros.RollerCoaster.AccountAPII.Proxy
{
    public interface IAccountProxy
    {
        Task<IRestResponse> ActivateEmailAsync(ActivateEmailRequest activateEmailRequest);
        Task<IRestResponse<JWTResponse>> CreateAsync(CreateAccountRequest createAccountRequest);
        Task<IRestResponse<JWTResponse>> LoginAsync(LoginRequest createAccountRequest);
        Task<IRestResponse<JWTResponse>> RefreshTokenAsync(string baseURL, RefreshTokenRequest refreshTokenRequest, string authorization);
        Task<IRestResponse> RequestPasswordResetEmailAsync(RequestPasswordResetEmailRequest requestPasswordResetEmailRequest);
        Task<IRestResponse> ResetPasswordAsync(ResetPasswordRequest resetPasswordRequest, string authorization);
        Task<IRestResponse> UpdateEmailPreferenceAsync(UpdateEmailPreferenceRequest updateEmailPreferenceRequest, string authorization);
        Task<IRestResponse> UpdateEmailPreferenceWithTokenAsync(UpdateEmailPreferenceWithTokenRequest updateEmailPreferenceWithTokenRequest);
        Task<IRestResponse> UpdatePasswordAsync(UpdatePasswordRequest updatePasswordRequest, string authorization);
    }
}