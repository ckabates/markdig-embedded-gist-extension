using Markdig.Syntax.Inlines;

namespace MarkdigEmbeddedGistExtension.Core
{
    public class EmbeddedGist : LeafInline
    {
        public string Url { get; set; }
    }
}
