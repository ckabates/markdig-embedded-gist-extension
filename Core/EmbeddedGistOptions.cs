using System;
using System.Collections.Generic;
using System.Text;

namespace MarkdigEmbeddedGistExtension.Core
{
    public class EmbeddedGistOptions
    {
        public List<string> BaseUrls { get; set; } = new List<string> { "https://gist.github.com" };
    }
}
