using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright.Xunit;
using Playwright_SoundSpruce.Models;
using Xunit.Sdk;

namespace Playwright_SoundSpruce.Tests
{
    public class SausageFileConverterPageNavigationTests : PageTest
    {
        private SausageFileConverterProductPage _sausageFileConverterPage;

        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            _sausageFileConverterPage = new SausageFileConverterProductPage(Page);
            await _sausageFileConverterPage.GoTo();

            await Expect(Page).ToHaveTitleAsync(new Regex("SausageFileConverter"));
            await Expect(Page).ToHaveURLAsync(_sausageFileConverterPage.ProductSlug);
        }

        [Fact]
        public async Task NotLoggedInClickBuyButton()
        {
            await _sausageFileConverterPage.ClickBuyButton();
            await Expect(Page).ToHaveURLAsync(new Regex("register/login"));
        }
        [Fact]
        public async Task LoggedInClickBuyButton()
        {
            throw new NotImplementedException("Login fixture needed");
            await _sausageFileConverterPage.ClickBuyButton();
            await Expect(Page).ToHaveURLAsync(new Regex("checkout\\.stripe"));
        }

        [Fact]
        public async Task AlreadyPurchasedBuyButtonNotVisible()
        {
            throw new NotImplementedException("Login fixture needed");
            await Expect(_sausageFileConverterPage.BuyButton).Not.ToBeVisibleAsync();
        }
    }
}
