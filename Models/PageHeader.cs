using Microsoft.Playwright;

namespace Playwright_SoundSpruce.Models
{
    public class PageHeader
    {
        private readonly IPage _page;
        private readonly ILocator _home;
        private readonly ILocator _about;
        private readonly ILocator _shop;
        private readonly ILocator _contact;
        private readonly ILocator _logIn;
        private readonly ILocator _logOut;
        private readonly ILocator _myProducts;
        public PageHeader(IPage page)
        {
            _page = page;

            _home = page.GetByRole(AriaRole.Link, new() { Name = "Home" });
            _about = page.GetByRole(AriaRole.Link, new() { Name = "About" });
            _shop = page.GetByRole(AriaRole.Link, new() { Name = "Shop" });
            _contact = page.GetByRole(AriaRole.Link, new() { Name = "Contact" });
            _logIn = page.GetByRole(AriaRole.Link, new() { Name = "Log In" });
            _logOut = page.GetByRole(AriaRole.Button, new() { Name = "Log Out", IncludeHidden = true });
            _myProducts = page.GetByRole(AriaRole.Link, new() { Name = "My Products", IncludeHidden = true });
        }

        // These ClickX methods could be handled by a generic function with a locator input but may require extra functionality
        // Such as checking which header links should be visible on each page.
        // This will either make the generic method more complicated or make the API less straight-forward to use and extend.

        public async Task ClickHome()
        {
            await _home.ClickAsync();
        }
        public async Task ClickAbout()
        {
            await _about.ClickAsync();
        }

        public async Task ClickShop()
        {
            await _shop.ClickAsync();
        }

        public async Task ClickContact()
        {
            await _contact.ClickAsync();
        }

        public async Task ClickLogIn()
        {
            await _logIn.ClickAsync();
        }

        public async Task ClickLogOut()
        {
            await _logOut.ClickAsync();
        }

        public async Task ClickMyProducts()
        {
            await _myProducts.ClickAsync();
        }
    }
}

