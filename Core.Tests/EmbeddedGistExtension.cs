using FluentAssertions;
using Markdig;
using System.Linq;
using Xunit;
using Core = MarkdigEmbeddedGistExtension.Core;

namespace MarkdigEmbeddedGistExtension.Core.Tests
{
    public class EmbeddedGistExtension
    {
        [Fact]
        public void CanBeAddedToMarkdownPipeline()
        {
            var _pipelineBuilder = new MarkdownPipelineBuilder()
                .UseEmbeddedGists();

            var _result = _pipelineBuilder.Build();

            _result.Extensions.Should().NotBeEmpty();
            _result.Extensions.First().Should().BeOfType<Core.EmbeddedGistExtension>();
        }
    }
}
