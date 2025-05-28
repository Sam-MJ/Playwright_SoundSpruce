using System;
using System.Collections.Generic;
using Microsoft.Playwright;

namespace Playwright_SoundSpruce.Models
{
    internal class ShopPage
    {
        private readonly IPage _page;
        private readonly ILocator _seeDetails;

        public ShopPage(IPage page)
        {
            _page = page;
            _seeDetails = page.GetByRole(AriaRole.Link, new() { Name = "See Details" });
        }

        public async Task GoTo()
        {
            await _page.GotoAsync("https://soundspruce.com/shop/");
        }

        public async Task ClickSeeDetails()
        {
            await _seeDetails.ClickAsync();
        }
    }
}
