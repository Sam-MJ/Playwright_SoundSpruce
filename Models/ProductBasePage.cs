using Microsoft.Playwright;

namespace Playwright_SoundSpruce.Models
{
    public abstract class ProductBasePage : BasePage
    {
        protected virtual string ShopUrlSegment => "shop/";
        private readonly ILocator _buyButton;

        public ProductBasePage(IPage page) : base(page) 
        {
            _buyButton = page.GetByRole(AriaRole.Button, new() { Name = "Buy Now" });
        }

        public async Task ClickBuyButton()
        {
            await _buyButton.ClickAsync();
        }
    }
}
