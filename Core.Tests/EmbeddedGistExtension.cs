﻿using FluentAssertions;
using Markdig;
using Markdig.Parsers;
using Markdig.Renderers;
using System;
using System.IO;
using System.Linq;
using Xunit;
using Core = MarkdigEmbeddedGistExtension.Core;
using HtmlAgilityPack;

namespace MarkdigEmbeddedGistExtension.Core.Tests
{
    public class EmbeddedGistExtension
    {
        private readonly string _renderFragment = "TEST_FRAGMENT";
        private readonly string _alternateBaseUrl = "https://test.url.com";
        private HtmlRenderer _renderer;

        public EmbeddedGistExtension()
        {
            _renderer = new HtmlRenderer(new StringWriter());
        }

        [Fact]
        public void CanBeAddedToMarkdownPipeline()
        {
            var _pipelineBuilder = new MarkdownPipelineBuilder()
                .UseEmbeddedGists();

            var _result = _pipelineBuilder.Build();

            _result.Extensions.Should().NotBeEmpty();
            _result.Extensions.First().Should().BeOfType<Core.EmbeddedGistExtension>();
        }

        [Theory]
        [InlineData("[https://gist.github.com/test/234092834098324.js]")]
        [InlineData("[https://test.url.com/test/234092834098324.js]")]
        public void CorrectlyIdentifiesParserMatch(string markdown)
        {
            var _pipeline = new MarkdownPipelineBuilder()
                .UseEmbeddedGists(config =>
                {
                    config.UseMockRender(_renderFragment);
                    config.AddBaseUrl(_alternateBaseUrl);
                }).Build();
            _pipeline.Setup(_renderer);

            var _result = Markdown.ToHtml(markdown, _pipeline);

            _result.Trim().Should().Be($"<p>{_renderFragment}</p>");
        }

        [Theory]
        [InlineData("[https://www.github.com]")]
        [InlineData("[https://www.github.com](https://www.github.com)")]
        public void CorrectlyIgnoresStandardLink(string markdown)
        {
            var _pipeline = new MarkdownPipelineBuilder()
                .UseAutoLinks()
                .UseEmbeddedGists(config =>
                {
                    config.UseMockRender(_renderFragment);
                    config.AddBaseUrl(_alternateBaseUrl);
                }).Build();
            _pipeline.Setup(_renderer);

            var _result = Markdown.ToHtml(markdown, _pipeline);

            _result.Trim().Should().NotBe($"<p>{_renderFragment}</p>");
            _result.Trim().Should().NotContain(_renderFragment);
        }

        [Fact]
        public void RendersParsedHtml()
        {
            string _markdown = $"[file://{Directory.GetCurrentDirectory()}/gist.js]";
            var _pipeline = new MarkdownPipelineBuilder()
                .UseEmbeddedGists(config =>
                {
                    config.AddBaseUrl("file://");
                }).Build();
            _pipeline.Setup(_renderer);

            var _html = Markdown.ToHtml(_markdown, _pipeline);
            var _result = new HtmlDocument();
            _result.LoadHtml($"<!DOCTYPE html><html><body>{_html}</body></html>");

            _html.Trim().Should().NotContain("document.write");
            _result.DocumentNode.SelectNodes("//p/link").Count().Should().Be(1);
            _result.DocumentNode.SelectSingleNode("//p/link").Attributes["test-attribute"].Value.Should().Be("confirmed");
            _result.GetElementbyId("file-test-gist-LC1").InnerText.Should().Be("This is a test gist");
        }
    }
}