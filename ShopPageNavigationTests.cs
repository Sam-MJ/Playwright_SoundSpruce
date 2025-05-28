using System.Text.RegularExpressions;
using Microsoft.Playwright.Xunit;
using Playwright_SoundSpruce.Models;


namespace Playwright_SoundSpruce
{
    public class ShopPageNavigationTests : PageTest
    {
        private ShopPage _shopPage;

        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            _shopPage = new ShopPage(Page);
            await _shopPage.GoTo();

            await Expect(Page).ToHaveTitleAsync(new Regex("shop"));
            await Expect(Page).ToHaveURLAsync(new Regex("/shop/"));
        }

        [Fact]
        public async Task CanNavigateToSeeDetails()
        {
            await _shopPage.ClickSeeDetails();
            await Expect(Page).ToHaveURLAsync(new Regex("/shop/\\w+"));
        }
    }
}
