using Microsoft.Playwright;


namespace Playwright_SoundSpruce.Models
{
    public class ContactPage : BasePage
    {
        public override string PageUrl => BaseUrl + "contact";
        public PageHeader Header { get; }

        private readonly ILocator _firstName;
        private readonly ILocator _lastName;
        private readonly ILocator _email;
        private readonly ILocator _subject;
        private readonly ILocator _message;
        private readonly ILocator _submit;

        public ContactPage(IPage page) : base(page)
        {
            Header = new PageHeader(page);

            _firstName = page.GetByLabel("First name");
            _lastName = page.GetByLabel("Last name");
            _email = page.GetByLabel("Email");
            _subject = page.GetByLabel("Subject");
            _message = page.GetByLabel("Message");
            _submit = page.GetByRole(AriaRole.Button, new() { Name = "Submit"});
        }

        public async Task FillFirstNameField(string firstName)
        {
            await _firstName.FillAsync(firstName);
        }
        public async Task FillLastNameField(string lastName)
        {
            await _lastName.FillAsync(lastName);
        }
        public async Task FillEmailField(string email)
        {
            await _email.FillAsync(email);
        }
        public async Task FillSubjectField(string subject)
        {
            await _subject.FillAsync(subject);
        }
        public async Task FillMessageField(string message)
        {
            await _message.FillAsync(message);
        }
        public async Task ClearFirstNameField()
        {
            await _firstName.ClearAsync();
        }
        public async Task ClickFormSubmit()
        {
            await _submit.ClickAsync();
        }
    }
}
