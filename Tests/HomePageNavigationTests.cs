using System.Text.RegularExpressions;
using Microsoft.Playwright.Xunit;
using Playwright_SoundSpruce.Models;

namespace Playwright_SoundSpruce.Tests
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
