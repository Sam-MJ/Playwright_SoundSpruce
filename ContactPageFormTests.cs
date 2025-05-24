using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.Xunit;
using Playwright_SoundSpruce.Models;
using Xunit.Abstractions;


namespace Playwright_SoundSpruce
{
    public class ContactPageFormTests : PageTest
    {
        private ContactPage _contactPage;
        private readonly ITestOutputHelper _output;

        public ContactPageFormTests(ITestOutputHelper output)
        {
            _output = output;
        }
        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            _contactPage = new ContactPage(Page);
            await _contactPage.GoTo();

            await Expect(Page).ToHaveTitleAsync(new Regex("SoundSpruce"));
        }

        private async Task ExpectFormUnsent(ILocator field, string fieldInput)
        {
            await _contactPage.FillForm(field, fieldInput);
            Assert.Equal(await field.InputValueAsync(), fieldInput);

            // Currently this just checks that after clicking submit the form contents hasn't been sent,
            // but because recaptcha blocks sending, it also doesn't send so this test can never fail.

            // TODO Expect that a request hasn't been sent when the submit button is pressed.
        }

        [Fact]
        public async Task PassingCompleteForm()
        {
            await _contactPage.FillForm(_contactPage.firstName, "Tester");
            await _contactPage.FillForm(_contactPage.lastName, "McTestFace");
            await _contactPage.FillForm(_contactPage.email, "test@123.com");
            await _contactPage.FillForm(_contactPage.subject, "This is a test");
            await _contactPage.FillForm(_contactPage.message, "Message");

            // recaptcha will block the sending of a form so it is only possible to test that the post request was sent.
            // it will not pass the recaptcha and therefore won't be forwarded to the success page.
            IResponse response = await Page.RunAndWaitForResponseAsync(async () =>
            {
                await _contactPage.ClickFormSubmit();
            }, response => response.Url.Contains("recaptcha"));

            Assert.Equal(response.Status, 200);                   
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
