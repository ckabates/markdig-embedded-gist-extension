using Markdig;
using Markdig.Renderers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarkdigEmbeddedGistExtension.Core
{
    public class EmbeddedGistExtension : IMarkdownExtension
    {
        public void Setup(MarkdownPipelineBuilder pipeline)
        {
            throw new NotImplementedException();
        }

        public void Setup(MarkdownPipeline pipeline, IMarkdownRenderer renderer)
        {
            throw new NotImplementedException();
        }
    }
}
