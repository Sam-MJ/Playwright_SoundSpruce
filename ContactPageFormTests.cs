using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.Xunit;
using Playwright_SoundSpruce.Models;


namespace Playwright_SoundSpruce
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

        private async Task ExpectFormUnsent(ILocator field, string fieldInput)
        {
            await _contactPage.FillForm(field, fieldInput);

            // This will only be a valid test if the form is sent from an IP that has been added to recaptcha whitelist.
            // If it has not, the fields will remain filled even if the post request has been sent.
            Assert.Equal(await field.InputValueAsync(), fieldInput);
        }

        [Fact]
        public async Task PassingCompleteForm()
        {
            await _contactPage.FillForm(_contactPage.firstName, "Tester");
            await _contactPage.FillForm(_contactPage.lastName, "McTestFace");
            await _contactPage.FillForm(_contactPage.email, "test@123.com");
            await _contactPage.FillForm(_contactPage.subject, "This is a test");
            await _contactPage.FillForm(_contactPage.message, "Message");

            // This will only pass when sent from an IP that has been added to recapcha whitelist.
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
            await ExpectFormUnsent(_contactPage.firstName, "Tester");
            await ExpectFormUnsent(_contactPage.lastName, "McTestFace");
            await ExpectFormUnsent(_contactPage.email, "test@123.com");
            
            await _contactPage.firstName.ClearAsync();
            await ExpectFormUnsent(_contactPage.message, "Message");
        }
    }
}
