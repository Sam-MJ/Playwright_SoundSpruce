using Microsoft.Playwright;

namespace Playwright_SoundSpruce.Models
{
    public class HomePage
    {
        private readonly IPage _page;
        public string PageUrl { get; }
        public PageHeader Header { get; }

        private readonly ILocator _getStarted;
        private readonly ILocator _seeDetails;
        public HomePage(IPage page)
        {
            _page = page;
            PageUrl = "https://soundspruce.com/";
            Header = new PageHeader(page);

            _getStarted = page.GetByRole(AriaRole.Link, new() { Name = "Get Started" });
            _seeDetails = page.GetByRole(AriaRole.Link, new() { Name = "See Details" });
        }

        public async Task GoTo()
        {
            await _page.GotoAsync(PageUrl);
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

