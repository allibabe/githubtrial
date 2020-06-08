using MyShop.UI.Models;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MyShop.UI.Controllers
{
    public interface IAccountController
    {
        ApplicationSignInManager SignInManager { get; }
        ApplicationUserManager UserManager { get; }

        Task<ActionResult> ConfirmEmail(string userId, string code);
        ActionResult ExternalLogin(string provider, string returnUrl);
        Task<ActionResult> ExternalLoginCallback(string returnUrl);
        Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl);
        ActionResult ExternalLoginFailure();
        ActionResult ForgotPassword();
        Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model);
        ActionResult ForgotPasswordConfirmation();
        Task<ActionResult> Login(LoginViewModel model, string returnUrl);
        ActionResult Login(string returnUrl);
        ActionResult LogOff();
        ActionResult Register();
        Task<ActionResult> Register(RegisterViewModel model);
        Task<ActionResult> ResetPassword(ResetPasswordViewModel model);
        ActionResult ResetPassword(string code);
        ActionResult ResetPasswordConfirmation();
        Task<ActionResult> SendCode(SendCodeViewModel model);
        Task<ActionResult> SendCode(string returnUrl, bool rememberMe);
        Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe);
        Task<ActionResult> VerifyCode(VerifyCodeViewModel model);
    }
}