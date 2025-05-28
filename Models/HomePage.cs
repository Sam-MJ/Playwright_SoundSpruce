using Microsoft.Playwright;

namespace Playwright_SoundSpruce.Models
{
    public class HomePage
    {
        private readonly IPage _page;
        private readonly ILocator _about;
        private readonly ILocator _shop;
        private readonly ILocator _contact;
        public readonly ILocator logIn;
        private readonly ILocator _getStarted;
        private readonly ILocator _seeDetails;
        public HomePage(IPage page)
        {
            _page = page;
            _about = page.GetByRole(AriaRole.Link, new() { Name = "About" });
            _shop = page.GetByRole(AriaRole.Link, new() { Name = "Shop" });
            _contact = page.GetByRole(AriaRole.Link, new() { Name = "Contact" });
            logIn = page.GetByRole(AriaRole.Link, new() { Name = "Log In" });
            _getStarted = page.GetByRole(AriaRole.Link, new() { Name = "Get Started" });
            _seeDetails = page.GetByRole(AriaRole.Link, new() { Name = "See Details" });
        }

        public async Task GoTo()
        {
            await _page.GotoAsync("https://soundspruce.com/");
        }

        // These ClickX methods could be handled by a generic function with a locator input but login will require extra functionality
        // This will either make the generic method more complicated or make the API less straight-forward to use and extend.

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
            // what's the best way to throw an error here if this is called when logged in?
            // I want to avoid using Expects at the model level
            await logIn.ClickAsync();
        }

        public async Task ClickGetStarted()
        {
            await _getStarted.ClickAsync();
        }


        public async Task ClickSeeDetails()
        {
            await _seeDetails.ClickAsync();
        }
    }
}

