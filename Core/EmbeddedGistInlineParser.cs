using Markdig.Helpers;
using Markdig.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarkdigEmbeddedGistExtension.Core
{
    public class EmbeddedGistInlineParser : InlineParser
    {
        private readonly string _gistUrl = "https://gist.github.com";
        private readonly EmbeddedGistConfiguration _configuration;

        public EmbeddedGistInlineParser(EmbeddedGistConfiguration configuration)
        {
            OpeningCharacters = new char[] { '[' };
            _configuration = configuration;
        }

        public override bool Match(InlineProcessor processor, ref StringSlice slice)
        {
            var _isMatch = false;
            int _start, _end;
            var _url = "";
            char _current;
            var _fullSlice = slice.ToString().ToLower().TrimStart(OpeningCharacters);

            if (!slice.PeekCharExtra(-1).IsWhiteSpaceOrZero())
            {
                return _isMatch;
            }

            if(_configuration.BaseUrls.Where(u => _fullSlice.StartsWith(u)).Count() == 0)
            {
                return _isMatch;
            }

            _start = slice.Start;
            _end = _start;
            _current = slice.NextChar();

            while (_current != ']')
            {
                _url += _current;
                _end = slice.Start;
                _current = slice.NextChar();
            }

            if (_current == ']')
            {
                slice.NextChar();

                var _inlineStart = processor.GetSourcePosition(slice.Start, out int _line, out int _column);

                processor.Inline = new EmbeddedGist
                {
                    Span =
                    {
                        Start = _inlineStart,
                        End = _inlineStart + (_end - _start) + 1
                    },
                    Line = _line,
                    Column = _column,
                    Url = _url
                };

                _isMatch = true;
            }

            return _isMatch;
        }
    }
}
