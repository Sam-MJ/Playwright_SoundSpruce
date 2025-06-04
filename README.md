# SoundSpruce Playwright test suite
This suite is to supplement the existing tests within my Django project.
## Page Object Model
It is using a Page Object Model design pattern where locators are encapsulated within an object and tests are bound to the Page Object's interface instead of the concrete locator.
This allows you to have only one source of truth for the locator code which is easily changeable without breaking all of the tests.

PageObjects are built by inheriting the BasePage and then adding the page specific locators and url directories to PageUrl
## Limitations
Because SoundSpruce uses Django, which has many built in validators, these tests are mainly focused on the functionality that I have built and as such I haven't written many tests to do form validation.

The project is also setup to run locally with recaptcha test keys although ideally it would be run in a staging environment.
