using Microsoft.Playwright;

namespace Playwright_SoundSpruce.Models
{
    public class RegisterPage : BasePage
    {
        public override string PageUrl => BaseUrl + "register";

        private readonly ILocator _userName;
        private readonly ILocator _firstName;
        private readonly ILocator _lastName;
        private readonly ILocator _email;
        private readonly ILocator _password;
        private readonly ILocator _passwordConfirmation;

        private readonly ILocator _register;
        public RegisterPage(IPage page) : base(page)
        {
            _userName = page.GetByLabel("Username");
            _firstName = page.GetByLabel("First name");
            _lastName = page.GetByLabel("Last name");
            _email = page.GetByLabel("Email address");
            _password = page.GetByRole(AriaRole.Textbox, new() { Name = "Password*" });
            _passwordConfirmation = page.GetByRole(AriaRole.Textbox, new() { Name = "Password confirmation*" });
            _register = page.GetByRole(AriaRole.Button, new() { Name = "Continue" });
        }

        public async Task FillUsernameField(string username)
        {
            await _userName.FillAsync(username);
        }

        public async Task FillFirstNameField(string firstName)
        {
            await _firstName.FillAsync(firstName);
        }
        public async Task FillLastNameField(string lastName)
        {
            await _lastName.FillAsync(lastName);
        }

        public async Task FillEmailField(string email)
        {
            await _email.FillAsync(email);
        }

        public async Task FillPasswordField(string password)
        {
            await _password.FillAsync(password);
        }

        public async Task FillPasswordConfirmationField(string passwordConfimation)
        {
            await _passwordConfirmation.FillAsync(passwordConfimation);
        }

        public async Task ClickRegister()
        {
            await _register.ClickAsync();
        }
    }
}
