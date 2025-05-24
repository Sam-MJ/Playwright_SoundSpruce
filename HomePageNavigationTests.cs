using System.Text.RegularExpressions;
using Microsoft.Playwright.Xunit;
using Playwright_SoundSpruce.Models;

namespace Playwright_SoundSpruce
{
    public class HomePageNavigationTests : PageTest
    {
        private HomePage _homePage;

        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            _homePage = new HomePage(Page);
            await _homePage.GoTo();

            await Expect(Page).ToHaveTitleAsync(new Regex("SoundSpruce"));
        }

        [Fact]
        public async Task CanNavigateToAboutPage()
        {
            await _homePage.ClickAbout();
            await Expect(Page).ToHaveTitleAsync(new Regex("About"));
            await Expect(Page).ToHaveURLAsync(new Regex("/about/"));
        }

        [Fact]
        public async Task CanNavigateToShopPage()
        {
            await _homePage.ClickShop();
            await Expect(Page).ToHaveTitleAsync(new Regex("Shop"));
            await Expect(Page).ToHaveURLAsync(new Regex("/shop/"));
        }

        [Fact]
        public async Task CanNavigateToContactPage()
        {
            await _homePage.ClickContact();
            await Expect(Page).ToHaveTitleAsync(new Regex("Contact"));
            await Expect(Page).ToHaveURLAsync(new Regex("/contact/"));
        }

        [Fact]
        public async Task CanNavigateToLoginPage()
        {
            if (await _homePage.logIn.IsVisibleAsync())
            {
                await _homePage.ClickLogIn();
                await Expect(Page).ToHaveTitleAsync(new Regex("Log In"));
                await Expect(Page).ToHaveURLAsync(new Regex("/register/login/"));
            }
        }

        [Fact]
        public async Task CanNavigateToGetStarted()
        {
            await _homePage.ClickGetStarted();
            await Expect(Page).ToHaveTitleAsync(new Regex("Shop"));
            await Expect(Page).ToHaveURLAsync(new Regex("/shop/"));
        }

        [Fact]
        public async Task CanNavigateToSeeDetails()
        {
            await _homePage.ClickSeeDetails();
            await Expect(Page).ToHaveURLAsync(new Regex("/shop/\\w+"));
        }

    }
}
