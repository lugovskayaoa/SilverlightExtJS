using System.Web.Mvc;

namespace ClientServer.Helper
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString Hyperlink(this HtmlHelper helper, string url, string linkText)
        {
            return MvcHtmlString.Create(string.Format("<a href='{0}'>{1}</a>", url, linkText));
        }
    }
}