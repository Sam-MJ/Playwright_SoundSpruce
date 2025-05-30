using Microsoft.Playwright;
using System.Text.RegularExpressions;

namespace Playwright_SoundSpruce.Models
{
    public class LoginPage
    {
        private readonly IPage _page;
        public string PageUrl { get; }
        public ILocator IncorrectCredentialsAlert { get; }

        private readonly ILocator _userName;
        private readonly ILocator _password;
        private readonly ILocator _logIn;
        private readonly ILocator _createAccount;
        private readonly ILocator _lostPassword;
        public LoginPage(IPage page)
        {
            _page = page;
            PageUrl = "https://soundspruce.com/register/login";

            _userName = page.GetByLabel("Username");
            _password = page.GetByLabel("Password");
            _logIn = page.GetByRole(AriaRole.Button, new() { Name = "Log in" });
            _createAccount = page.GetByRole(AriaRole.Link, new() { Name = "Create an account" });
            _lostPassword = page.GetByRole(AriaRole.Link, new() { Name = "Lost password?" });

            IncorrectCredentialsAlert = page.GetByRole(AriaRole.Alert).Locator("ul > li").Filter(new() { HasTextRegex = new Regex("Please enter a correct username and password") });
        }

        public async Task GoTo()
        {
            await _page.GotoAsync(PageUrl);
        }

        public async Task FillLoginFields(string userName, string password)
        {
            await _userName.FillAsync(userName);
            await _password.FillAsync(password);
        }

        public async Task ClickLogInButton()
        {
            await _logIn.ClickAsync();
        }

        public async Task ClickCreateAccount()
        {
            await _createAccount.ClickAsync();
        }

        public async Task ClickLostPassword()
        {
            await _lostPassword.ClickAsync();
        }
    }
}
