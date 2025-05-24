using System.Text.RegularExpressions;
using Microsoft.Playwright.Xunit;
using Playwright_SoundSpruce.Models;


namespace Playwright_SoundSpruce
{
    public class ContactPageNavigationTests : PageTest
    {
        private ContactPage _contactPage;

        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            _contactPage = new ContactPage(Page);
            await _contactPage.GoTo();

            await Expect(Page).ToHaveTitleAsync(new Regex("Contact"));
            await Expect(Page).ToHaveURLAsync(new Regex("/Contact/"));
        }

        [Fact]
        public async Task CanNavigateToSeeDetails()
        {
            await _contactPage.ClickHome();
            await Expect(Page).ToHaveURLAsync("https://soundspruce.com/");
        }
    }
}
