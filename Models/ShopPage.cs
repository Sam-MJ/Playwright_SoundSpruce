using System;
using System.Collections.Generic;
using Microsoft.Playwright;

namespace Playwright_SoundSpruce.Models
{
    public class ShopPage : BasePage
    {
        public override string PageUrl => BaseUrl + "shop/";

        private readonly ILocator _seeDetails;

        public ShopPage(IPage page) : base(page)
        {
            _seeDetails = page.GetByRole(AriaRole.Link, new() { Name = "See Details" });
        }

        public async Task ClickSeeDetails()
        {
            await _seeDetails.ClickAsync();
        }
    }
}
