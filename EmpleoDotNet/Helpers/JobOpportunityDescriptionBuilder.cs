using System;
using System.Text;
using System.Text.RegularExpressions;

namespace EmpleoDotNet.Helpers
{
    public static class JobOpportunityDescriptionBuilder
    {
        public static string BuildDescription(string rawDescription)
        {
            var result = new StringBuilder();

            var splitedDescription = rawDescription.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            foreach (var line in splitedDescription)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    result.AppendLine();
                    continue;
                }

                var lineWithLink = Regex.Replace(line,
                @"((http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?)",
                "<a target='_blank' href='$1'>$1</a>");

                result.AppendLine(line.Contains("http") 
                    ? BuildHtmlTag("p", lineWithLink) 
                    : BuildHtmlTag("p", line));
            }

            return result.ToString();
        }
        private static string BuildHtmlTag(string tag, string value)
        {
            return $"<{tag}>{value}</{tag}>";
        }
    }
}