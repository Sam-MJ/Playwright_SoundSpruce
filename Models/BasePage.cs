using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright_SoundSpruce.Models
{
    public abstract class BasePage
    {
        protected readonly IPage _page;
        public string BaseUrl { get; }
        public abstract string PageUrl { get; }

        public BasePage(IPage page)
        {
            _page = page;
            BaseUrl = "http://127.0.0.1:8000/";
        }
        public async Task GoTo()
        {
            await _page.GotoAsync(this.PageUrl);
        }
    }
}
