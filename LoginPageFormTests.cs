using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using Microsoft.Playwright.Xunit;
using Playwright_SoundSpruce.Models;

namespace Playwright_SoundSpruce
{
    public class LoginPageFixture
    {
        public string TestUserName { get; }
        public string TestPassword { get; }
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
        private HomePage _homePage;
        private LoginPageFixture fixture;
        
        public LoginPageFormTests(LoginPageFixture fixture)
        {
            this.fixture = fixture;
        }
        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            _loginPage = new LoginPage(Page);
            _homePage = new HomePage(Page);

            await _loginPage.GoTo();

            await Expect(Page).ToHaveTitleAsync(new Regex("Log In"));
        }

        private async Task ExpectNotLoggedIn()
        {
            await Expect(Page).ToHaveURLAsync(_loginPage.PageUrl);
            await Expect(_loginPage.IncorrectCredentialsAlert).ToBeVisibleAsync();
        }

        /** <summary>
            Fill in the correct details re-route to the home page.
        </summary> **/
        [Fact]
        public async Task ValidDetailsLogIn()
        {
            await _loginPage.FillLoginFields(fixture.TestUserName, fixture.TestPassword);
            await _loginPage.ClickLogInButton();

            await Expect(Page).ToHaveURLAsync(_homePage.PageUrl);
        }


        /** <summary>
            Fill in the wrong details and attempt to log in, this should fail and should remain on the login url.
        </summary> **/
        [Fact]
        public async Task InvalidUserNameDoesNotLogIn()
        {
            await _loginPage.FillLoginFields("thisisthewrongusername", fixture.TestPassword);
            await _loginPage.ClickLogInButton();

            await ExpectNotLoggedIn();
        }

        [Fact]
        public async Task InvalidPasswordDoesNotLogIn()
        {
            await _loginPage.FillLoginFields(fixture.TestUserName, "thisisthewrongpassword123");
            await _loginPage.ClickLogInButton();

            await ExpectNotLoggedIn();
        }

        [Fact]
        public async Task EmptyCredentialsDoesNotLogIn()
        {
            await _loginPage.ClickLogInButton();
            await Expect(Page).ToHaveURLAsync(_loginPage.PageUrl);
        }
    }
}
