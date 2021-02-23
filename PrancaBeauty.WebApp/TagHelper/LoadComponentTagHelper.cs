using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Threading.Tasks;

namespace PrancaBeauty.WebApp.TagHelper
{
    [HtmlTargetElement("LoadComponent")]
    public class LoadComponentTagHelper : Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
    {
        public string Id { get; set; }
        public string Class { get; set; }
        public string Url { get; set; }
        public object Data { get; set; }
        public HttpContext Context { get; set; }


        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            string htmlData = "";

            if (htmlData == null)
                throw new Exception("");

            output.TagName = "div";
            if (Id != null)
                output.Attributes.SetAttribute("id", Id);

            if (Class != null)
                output.Attributes.SetAttribute("class", Class);

            output.Content.SetHtmlContent(htmlData);

            /*
             * اگر ما
             * async
             * نداشتیم و فقط
             * Task
             * داشتیم میشد این طوری
             * Task
             * برگردوند
             */
            //return Task.FromResult(0);
        }
    }
}
