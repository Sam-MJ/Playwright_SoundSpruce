using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Playwright.Xunit;
using Playwright_SoundSpruce.Models;


namespace Playwright_SoundSpruce
{
    public class ShopPageNavigationTests : PageTest
    {
        private ShopPage _homePage;

        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            _homePage = new ShopPage(Page);
            await _homePage.GoTo();

            await Expect(Page).ToHaveTitleAsync(new Regex("shop"));
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
