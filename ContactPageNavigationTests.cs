using System.Text.RegularExpressions;
using Microsoft.Playwright.Xunit;
using Playwright_SoundSpruce.Models;


namespace Playwright_SoundSpruce
{
    public class ContactPageNavigationTests : PageTest
    {
        private ContactPage _contactPage;
        private HomePage _homePage;

        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            _contactPage = new ContactPage(Page);
            _homePage = new HomePage(Page);

            await _contactPage.GoTo();

            await Expect(Page).ToHaveTitleAsync(new Regex("Contact"));
            await Expect(Page).ToHaveURLAsync(new Regex("/contact/"));
        }

        [Fact]
        public async Task CanNavigateToHome()
        {
            await _contactPage.ClickHome();
            await Expect(Page).ToHaveURLAsync(_homePage.PageUrl);
        }
    }
}
