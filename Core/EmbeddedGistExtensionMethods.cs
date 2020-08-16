using Markdig;

namespace MarkdigEmbeddedGistExtension.Core
{
    public static class EmbeddedGistExtensionMethods
    {
        public static MarkdownPipelineBuilder UseEmbeddedGists(this MarkdownPipelineBuilder pipeline)
        {
            if (!pipeline.Extensions.Contains<EmbeddedGistExtension>())
            {
                pipeline.Extensions.Add(new EmbeddedGistExtension());
            }
            return pipeline;
        }
    }
}
