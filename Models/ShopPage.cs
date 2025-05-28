using System;
using System.Collections.Generic;
using Microsoft.Playwright;

namespace Playwright_SoundSpruce.Models
{
    internal class ShopPage
    {
        private readonly IPage _page;
        public string PageUrl { get; }

        private readonly ILocator _seeDetails;

        public ShopPage(IPage page)
        {
            _page = page;
            PageUrl = "https://soundspruce.com/shop/";

            _seeDetails = page.GetByRole(AriaRole.Link, new() { Name = "See Details" });
        }

        public async Task GoTo()
        {
            await _page.GotoAsync(PageUrl);
        }

        public async Task ClickSeeDetails()
        {
            await _seeDetails.ClickAsync();
        }
    }
}
