using Markdig.Helpers;
using Markdig.Parsers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarkdigEmbeddedGistExtension.Core
{
    public class EmbeddedGistInlineParser : InlineParser
    {
        public override bool Match(InlineProcessor processor, ref StringSlice slice)
        {
            throw new NotImplementedException();
        }
    }
}
