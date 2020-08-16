using Markdig;
using Markdig.Parsers.Inlines;
using Markdig.Renderers;

namespace MarkdigEmbeddedGistExtension.Core
{
    public class EmbeddedGistExtension : IMarkdownExtension
    {
        public void Setup(MarkdownPipelineBuilder pipeline)
        {
            if (!pipeline.InlineParsers.Contains<EmbeddedGistInlineParser>())
            {
                pipeline.InlineParsers.InsertBefore<LinkInlineParser>(new EmbeddedGistInlineParser());
            }
        }

        public void Setup(MarkdownPipeline pipeline, IMarkdownRenderer renderer)
        {
            var _htmlRenderer = renderer as HtmlRenderer;
            if (_htmlRenderer != null && !_htmlRenderer.ObjectRenderers.Contains<EmbeddedGistRenderer>())
            {
                _htmlRenderer.ObjectRenderers.Add(new EmbeddedGistRenderer());
            }
        }
    }
}
