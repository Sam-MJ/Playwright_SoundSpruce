using Microsoft.Playwright;

namespace Playwright_SoundSpruce.Models
{
    public abstract class ProductBasePage : BasePage
    {
        protected virtual string ShopUrlSegment => "shop/";
        public abstract string ProductSlug { get; }
        public ILocator BuyButton { get; }

        public ProductBasePage(IPage page) : base(page) 
        {
            BuyButton = page.GetByRole(AriaRole.Button, new() { Name = "Buy Now" });
        }

        public async Task ClickBuyButton()
        {
            await BuyButton.ClickAsync();
        }
    }
}
