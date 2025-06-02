using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using Microsoft.Playwright.Xunit;
using Playwright_SoundSpruce.Models;

namespace Playwright_SoundSpruce
{
    public class RegisterPageCredentialsFixture
    {
        public string TestPassword { get; }
        public RegisterPageCredentialsFixture()
        {
            var builder = new ConfigurationBuilder().AddUserSecrets(Assembly.GetExecutingAssembly(), false);
            IConfiguration config = builder.Build();
            TestPassword = config["REGISTER.TestPassword"];
        }
    }
    public class RegisterPageFormTests : PageTest, IClassFixture<RegisterPageCredentialsFixture>
    {
        private RegisterPage _registerPage;
        private HomePage _homePage;
        private RegisterPageCredentialsFixture fixture;

        public RegisterPageFormTests(RegisterPageCredentialsFixture fixture)
        {
            this.fixture = fixture;
        }

        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            _registerPage = new RegisterPage(Page);
            _homePage = new HomePage(Page);

            await _registerPage.GoTo();

            await Expect(Page).ToHaveTitleAsync(new Regex("Register"));
        }

        [Fact]
        public async Task PassingCompleteForm()
        {
            string secondsSinceEpoch = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
            await _registerPage.FillUsernameField("testUser" + secondsSinceEpoch);
            await _registerPage.FillFirstNameField("Tester");
            await _registerPage.FillLastNameField("McTestFace");
            await _registerPage.FillEmailField($"test@{secondsSinceEpoch}.com");
            await _registerPage.FillPasswordField(fixture.TestPassword);
            await _registerPage.FillPasswordConfirmationField(fixture.TestPassword);

            await _registerPage.ClickRegister();

            await Expect(Page).ToHaveURLAsync(_homePage.PageUrl);
        }
        
    }
}
