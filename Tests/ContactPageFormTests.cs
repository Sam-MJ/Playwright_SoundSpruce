using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.Xunit;
using Playwright_SoundSpruce.Models;


namespace Playwright_SoundSpruce.Tests
{
    public class ContactPageFormTests : PageTest
    {
        private ContactPage _contactPage;
        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            _contactPage = new ContactPage(Page);
            await _contactPage.GoTo();

            await Expect(Page).ToHaveTitleAsync(new Regex("Contact"));
        }

        private async Task SubmitButExpectFormUnsent()
        {
            await _contactPage.ClickFormSubmit();
            await Expect(Page).ToHaveURLAsync(_contactPage.PageUrl);
        }

        [Fact]
        public async Task PassingCompleteForm()
        {
            await _contactPage.FillFirstNameField("Tester");
            await _contactPage.FillLastNameField("McTestFace");
            await _contactPage.FillEmailField("test@123.com");
            await _contactPage.FillSubjectField("This is a test");
            await _contactPage.FillMessageField("Message");

            // This will only be a valid test if the form is sent from an IP that has been added to recaptcha whitelist
            // Or if the webserver is setup in a local environment with a recaptcha test key.
            await _contactPage.ClickFormSubmit();
            await Expect(Page).ToHaveTitleAsync(new Regex("Success"));
            await Expect(Page).ToHaveURLAsync(new Regex("success"));
        }

        /**<summary>
            Check that the form won't submit if the required fields aren't filled out.
        </summary>**/
        [Fact]
        public async Task IncompleteRequiredFieldsForm()
        {
            await _contactPage.FillFirstNameField("Tester");
            await SubmitButExpectFormUnsent();

            await _contactPage.FillLastNameField("McTestFace");
            await SubmitButExpectFormUnsent();

            await _contactPage.FillEmailField("test@123.com");
            await SubmitButExpectFormUnsent();

            await _contactPage.ClearFirstNameField();
            await _contactPage.FillMessageField("Message");
            await SubmitButExpectFormUnsent();
        }
    }
}
