using Microsoft.Playwright;

namespace Playwright_SoundSpruce.Models
{
    public class SausageFileConverterProductPage : ProductBasePage
    {
        private string productSlug = "sausage-file-converter";
        public override string PageUrl => BaseUrl + ShopUrlSegment + productSlug;

        public SausageFileConverterProductPage(IPage page) : base(page)
        {

        }
    }
}
