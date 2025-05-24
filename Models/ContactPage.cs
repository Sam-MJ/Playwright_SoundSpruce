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
        private readonly ILocator _home;
        public readonly ILocator firstName;
        public readonly ILocator lastName;
        public readonly ILocator email;
        public readonly ILocator subject;
        public readonly ILocator message;
        private readonly ILocator _submit;

        public ContactPage(IPage page)
        {
            _page = page;
            _home = page.GetByRole(AriaRole.Link, new() { Name = "Home" });
            firstName = page.GetByLabel("First name");
            lastName = page.GetByLabel("Last name");
            email = page.GetByLabel("Email");
            subject = page.GetByLabel("Subject");
            message = page.GetByLabel("Message");
            _submit = page.GetByRole(AriaRole.Button, new() { Name = "Submit"});
        }

        public async Task GoTo()
        {
            await _page.GotoAsync("https://soundspruce.com/contact/");
        }

        public async Task FillForm(ILocator formField, string text)
        {
            await formField.FillAsync(text);
        }
        public async Task ClickFormSubmit()
        {
            await _submit.ClickAsync();
        }
        public async Task ClickHome()
        {
            await _home.ClearAsync();
        }
    }
}
