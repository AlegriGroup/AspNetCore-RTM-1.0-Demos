using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetCore_Mvc_TagHelper_CoreFx.Helpers
{
    [HtmlTargetElement("random-string", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class RandomStringTagHelper : TagHelper
    {
        // attribute
        [HtmlAttributeName(nameof(Length))]
        public int Length { get; set; }

        [HtmlAttributeName(nameof(Chars))]
        public String Chars { get; set; }

        // fields
        private const string DefaultChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private static readonly Random Random = new Random(Guid.NewGuid().GetHashCode());

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "span";
            output.TagMode = TagMode.StartTagAndEndTag;

            var availableChars = !String.IsNullOrEmpty(Chars) ? Chars : DefaultChars;

            IEnumerable<char> randomChars = Enumerable.Repeat(availableChars, Length)
                                                .Select(s => s[Random.Next(s.Length)]);

            string randomString = String.Concat(randomChars);

            output.Content.SetContent(randomString);
        }


    }
}

