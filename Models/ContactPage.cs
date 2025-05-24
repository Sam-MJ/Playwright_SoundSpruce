using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;


namespace Playwright_SoundSpruce.Models
{
    public class ContactPage
    {
        private readonly IPage _page;
        private readonly ILocator _firstName;
        private readonly ILocator _lastName;
        private readonly ILocator _email;
        private readonly ILocator _subject;
        private readonly ILocator _message;
        private readonly ILocator _submit;

        public ContactPage(IPage page)
        {
            _page = page;
            _firstName = page.GetByLabel("First name");
            _lastName = page.GetByLabel("Last name");
            _email = page.GetByLabel("Email");
            _subject = page.GetByLabel("Subject");
            _message = page.GetByLabel("Message");
            _submit = page.GetByRole(AriaRole.Button, new() { Name = "Submit"});
        }

        public async Task EnterFirstName(string text)
        {
            await _firstName.FillAsync(text);
        }
        public async Task ClickSubmit()
        {
            await _submit.ClickAsync();
        }
    }
}
