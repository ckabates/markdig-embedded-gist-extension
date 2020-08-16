using Markdig.Renderers;
using Markdig.Renderers.Html;
using System;

namespace MarkdigEmbeddedGistExtension.Core
{
    public class EmbeddedGistRenderer : HtmlObjectRenderer<EmbeddedGist>
    {
        private readonly EmbeddedGistConfiguration _configuration;

        public EmbeddedGistRenderer(EmbeddedGistConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Write(HtmlRenderer renderer, EmbeddedGist obj)
        {
            if(_configuration.IsMockRender)
            {
                renderer.ImplicitParagraph = false;
                renderer.Write(_configuration.MockRenderFragment);
            }
        }
    }
}
