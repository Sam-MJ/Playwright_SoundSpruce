using System.Text.RegularExpressions;
using Microsoft.Playwright.Xunit;
using Playwright_SoundSpruce.Models;

namespace Playwright_SoundSpruce.Tests
{
    public class HeaderNavigationTests : PageTest
    {
        private HomePage _homePage;
        private ContactPage _contactPage;

        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            _homePage = new HomePage(Page);
            _contactPage = new ContactPage(Page);
            await GoToHomePage();
        }

        // If you are on home page you can't test navigating to home page, so default start at home page
        // but go to contact page to check navigation to home page.
        private async Task GoToHomePage()
        {
            await _homePage.GoTo();
            await Expect(Page).ToHaveTitleAsync(new Regex("SoundSpruce"));
        }

        private async Task GoToContactPage()
        {
            await _contactPage.GoTo();
            await Expect(Page).ToHaveTitleAsync(new Regex("Contact"));
            await Expect(Page).ToHaveURLAsync(new Regex("/contact"));
        }

        [Fact]
        public async Task CanNavigateToAboutPage()
        {
            await _homePage.Header.ClickAbout();
            await Expect(Page).ToHaveTitleAsync(new Regex("About"));
            await Expect(Page).ToHaveURLAsync(new Regex("/about"));
        }

        [Fact]
        public async Task CanNavigateToShopPage()
        {
            await _homePage.Header.ClickShop();
            await Expect(Page).ToHaveTitleAsync(new Regex("Shop"));
            await Expect(Page).ToHaveURLAsync(new Regex("/shop/"));
        }

        [Fact]
        public async Task CanNavigateToContactPage()
        {
            await _homePage.Header.ClickContact();
            await Expect(Page).ToHaveTitleAsync(new Regex("Contact"));
            await Expect(Page).ToHaveURLAsync(new Regex("/contact"));
        }

        [Fact]
        public async Task CanNavigateToLoginPage()
        {
            await _homePage.Header.ClickLogIn();
            await Expect(Page).ToHaveTitleAsync(new Regex("Log In"));
            await Expect(Page).ToHaveURLAsync(new Regex("/register/login"));
            
        }

        [Fact]
        public async Task CanNavigateToHome()
        {
            await GoToContactPage();
            await _contactPage.Header.ClickHome();
            await Expect(Page).ToHaveURLAsync(_homePage.PageUrl);
        }

    }
}
