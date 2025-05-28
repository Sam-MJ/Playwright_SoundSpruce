using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using Microsoft.Playwright.Xunit;
using Playwright_SoundSpruce.Models;

namespace Playwright_SoundSpruce
{
    public class LoginPageFixture
    {
        public readonly string TestUserName;
        public readonly string TestPassword;
        public LoginPageFixture()
        {
            var builder = new ConfigurationBuilder().AddUserSecrets(Assembly.GetExecutingAssembly(), false);
            IConfiguration config = builder.Build();
            TestUserName = config["LOGIN.TestUserName"];
            TestPassword = config["LOGIN.TestPassword"];
        }
    }

    public class LoginPageFormTests : PageTest, IClassFixture<LoginPageFixture>
    {
        private LoginPage _loginPage;
        private LoginPageFixture fixture;
        
        public LoginPageFormTests(LoginPageFixture fixture)
        {
            this.fixture = fixture;
        }
        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            _loginPage = new LoginPage(Page);
            await _loginPage.GoTo();

            await Expect(Page).ToHaveTitleAsync(new Regex("Log In"));

            
        }

        [Fact]
        public async Task ValidLogin()
        {
            await _loginPage.FillLoginFields(fixture.TestUserName, fixture.TestPassword);
            await _loginPage.ClickLogInButton();

            await Expect(Page).ToHaveURLAsync("https://soundspruce.com/");
        }
    }
}
