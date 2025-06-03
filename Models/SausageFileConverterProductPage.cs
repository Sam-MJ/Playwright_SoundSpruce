using Microsoft.Playwright;

namespace Playwright_SoundSpruce.Models
{
    public class SausageFileConverterProductPage : ProductBasePage
    {
        public override string ProductSlug => "sausage-file-converter";
        public override string PageUrl => BaseUrl + ShopUrlSegment + ProductSlug;

        public SausageFileConverterProductPage(IPage page) : base(page)
        {

        }
    }
}
