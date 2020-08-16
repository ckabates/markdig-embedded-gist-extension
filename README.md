# markdig-embedded-gist-extension

Markdig is an excellent .Net library that allows you to process markdown.  It is easily extensible and in keeping with that this is an extension that allows for the parsing and rendering of embedded gists.

Github provides users with a javascript file embed link for any gists they create.  Using this extension this gist url can be placed in the markdown within [....] and the extension will download the content of the script, strip the document.write calls out of it and render the remaining Html as part of your processed markdown.

You can find Markdig here - https://github.com/lunet-io/markdig

Adding a new extension is fairly easy and there are some great examples out there.  I found this blog by Richard Moss to be a great step by step guide - 
https://www.cyotek.com/blog/writing-custom-markdig-extensions.
