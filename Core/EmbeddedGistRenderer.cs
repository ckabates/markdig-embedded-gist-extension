using Markdig.Renderers;
using Markdig.Renderers.Html;
using System;
using System.Net;
using System.Text.RegularExpressions;

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
            else
            {
                using (var wc = new WebClient())
                {
                    var _html = "";
                    var _code = Regex.Unescape(wc.DownloadString(obj.Url));
                    var _matchCollection = Regex.Matches(_code, @"document.write\('([^'\)]*)");
                    foreach (Match _match in _matchCollection)
                    {
                        _html += _match.Groups[1].Value;
                    }

                    renderer.Write(_html);
                }
            }
        }
    }
}