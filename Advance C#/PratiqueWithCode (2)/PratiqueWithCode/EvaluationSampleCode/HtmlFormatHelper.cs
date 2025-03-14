using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSampleCode
{
    public class HtmlFormatHelper
    {
        public string GetBoldFormat(string content)
        {
            return $"<b>{content}</b>";
        }

        public string GetItalicFormat(string content)
        {
            return $"<i>{content}</i>";
        }

        // Plus difficile
        public string GetFormattedListElements(List<string> contents)
        {
            var htmlList = new StringBuilder();
            htmlList.Append("<ul>");

            contents.ForEach(x => {
                htmlList.Append("<li>");
                htmlList.Append(x);
                htmlList.Append("</li>");
            });

            htmlList.Append("</ul>");
            return htmlList.ToString();
        }
    }
}
