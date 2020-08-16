using Markdig;
using System;

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

        public static MarkdownPipelineBuilder UseEmbeddedGists(
            this MarkdownPipelineBuilder pipeline, 
            Action<EmbeddedGistConfiguration> configuration)
        {
            if (!pipeline.Extensions.Contains<EmbeddedGistExtension>())
            {
                var _options = new EmbeddedGistConfiguration();
                configuration(_options);
                pipeline.Extensions.Add(new EmbeddedGistExtension(_options));
            }
            return pipeline;
        }
    }
}
