using Markdig.Renderers;
using Markdig.Renderers.Html;
using System;

namespace MarkdigEmbeddedGistExtension.Core
{
    public class EmbeddedGistRenderer : HtmlObjectRenderer<EmbeddedGist>
    {
        protected override void Write(HtmlRenderer renderer, EmbeddedGist obj)
        {
            throw new NotImplementedException();
        }
    }
}
