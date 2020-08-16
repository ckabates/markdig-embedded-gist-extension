using System;
using System.Collections.Generic;
using System.Text;

namespace MarkdigEmbeddedGistExtension.Core
{
    public class EmbeddedGistConfiguration
    {
        public List<string> BaseUrls { get; set; } = new List<string> { "https://gist.github.com" };

        public bool IsMockRender => MockRenderFragment != string.Empty;

        public string MockRenderFragment { get; set; } = string.Empty;

        public void UseMockRender(string renderFragment)
        {
            MockRenderFragment = renderFragment;
        }

        public void AddBaseUrl(string url)
        {
            if (!BaseUrls.Contains(url))
            {
                BaseUrls.Add(url);
            }
        }
    }
}
