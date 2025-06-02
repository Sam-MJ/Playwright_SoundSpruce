using Microsoft.Playwright;

namespace Playwright_SoundSpruce.Models
{
    public class HomePage : BasePage
    {
        public override string PageUrl => BaseUrl;
        public PageHeader Header { get; }

        private readonly ILocator _getStarted;
        private readonly ILocator _seeDetails;
        public HomePage(IPage page) : base(page)
        {
            Header = new PageHeader(page);

            _getStarted = page.GetByRole(AriaRole.Link, new() { Name = "Get Started" });
            _seeDetails = page.GetByRole(AriaRole.Link, new() { Name = "See Details" });
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

