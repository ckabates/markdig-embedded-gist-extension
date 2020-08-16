using Markdig;
using Markdig.Parsers.Inlines;
using Markdig.Renderers;

namespace MarkdigEmbeddedGistExtension.Core
{
    public class EmbeddedGistExtension : IMarkdownExtension
    {
        private EmbeddedGistConfiguration _configuration;
        
        public EmbeddedGistExtension()
        {
            _configuration = new EmbeddedGistConfiguration();
        }

        public EmbeddedGistExtension(EmbeddedGistConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Setup(MarkdownPipelineBuilder pipeline)
        {
            if (!pipeline.InlineParsers.Contains<EmbeddedGistInlineParser>())
            {
                pipeline.InlineParsers.InsertBefore<LinkInlineParser>(new EmbeddedGistInlineParser(_configuration));
            }
        }

        public void Setup(MarkdownPipeline pipeline, IMarkdownRenderer renderer)
        {
            var _htmlRenderer = renderer as HtmlRenderer;
            if (_htmlRenderer != null && !_htmlRenderer.ObjectRenderers.Contains<EmbeddedGistRenderer>())
            {
                _htmlRenderer.ObjectRenderers.Add(new EmbeddedGistRenderer(_configuration));
            }
        }
    }
}
