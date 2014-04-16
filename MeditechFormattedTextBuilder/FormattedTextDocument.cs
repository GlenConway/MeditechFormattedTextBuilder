//Copyright (C) 2011 by Glen Conway

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in
//all copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//THE SOFTWARE
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MeditechUtilities
{
    /// <summary>
    /// Represents a MEDITECH formatted text document.
    /// </summary>
    public class FormattedTextDocument
    {
        private bool disposed;

        public void Dispose() {
            Dispose(true);
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing) {
            // Check to see if Dispose has already been called.
            if (this.disposed)
                return;

            // If disposing equals true, dispose all managed
            // and unmanaged resources.
            if (disposing) {
                // Dispose managed resources.
                if (reader != null) {
                    reader.Close();
                    reader.Dispose();
                }
            }

            // Note disposing has been done.
            disposed = true;
        }

        /// <summary>
        /// If false, local escape codes are suppressed.
        /// </summary>
        public bool SupportsLocalEscapeCodes {
            get;
            set;
        }

        private StringReader reader;
        private StringReader Reader {
            get {
                if (reader == null)
                    reader = new StringReader(MeditechText.Replace("\r\n", " "));

                return reader;
            }
        }

        private DocumentNodeCollection nodes;
        /// <summary>
        /// Gets a collection of document nodes
        /// </summary>
        public DocumentNodeCollection Nodes {
            get {
                if (nodes == null) {
                    nodes = new DocumentNodeCollection();
                    nodes.SupportsLocalEscapeCodes = SupportsLocalEscapeCodes;
                }

                return nodes;
            }
        }

        /// <summary>
        /// Gets or sets the text of the MEDITECH document
        /// </summary>
        public string MeditechText {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the HTML text that represents a MEDITECH document
        /// </summary>
        public string HtmlText {
            get;
            set;
        }

        private void buildNodesFromMeditech() {
            reader = null;

            DocumentNode currentNode = new StartDocumentNode();
            Nodes.Add(currentNode);

            currentNode = null;

            if (!string.IsNullOrEmpty(MeditechText))
                while (true) {
                    var ascii = Reader.Read();

                    if (ascii == -1)
                        break;

                    var isEscape = ascii.Equals((int)EscapeSequence.EscapeCharacter);
                    var isNewLine = ascii.Equals((int)NewLineDocumentNode.NewLineCharacter);

                    if (isEscape) {
                        if (currentNode == null) {
                            // need to start a new escape node
                            currentNode = new EscapeDocumentNode();
                        }
                        else {
                            Nodes.Add(currentNode);

                            currentNode = currentNode.NodeType == NodeType.Escape ? null : new EscapeDocumentNode();
                        }
                    }
                    else {
                        if (isNewLine) {
                            if (currentNode != null)
                                Nodes.Add(currentNode);

                            currentNode = new NewLineDocumentNode();
                            Nodes.Add(currentNode);
                            currentNode = null;
                        }
                        else {
                            if (currentNode == null)
                                currentNode = new TextDocumentNode();
                        }
                    }

                    if (currentNode == null || isEscape || isNewLine)
                        continue;

                    switch (ascii) {
                        case 10:
                        case 13: {
                                break;
                            }
                        default: {
                                currentNode.Value += ((char)ascii);

                                break;
                            }
                    }
                }

            currentNode = new EndDocumentNode();

            Nodes.Add(currentNode);

            foreach (var node in Nodes) {
                if (node.NodeType != NodeType.Escape || string.IsNullOrEmpty(node.Value))
                    continue;

                ((EscapeDocumentNode)node).BuildEscapeSequences();
            }
        }

        public string ToMeditech() {
            var result = new StringBuilder();

            foreach (var node in Nodes) {
                result.Append(node.ToString());
            }

            MeditechText = result.ToString();

            return MeditechText;
        }

        #region Html

        /// <summary>
        /// Converts MEDITECH text to an HTML document.
        /// </summary>
        /// <returns></returns>
        public string ToHtml() {
            if (Nodes.Count == 0)
                buildNodesFromMeditech();

            var closing = new Stack<EscapeSequence>();

            using (var result = new IndentedStringBuilder()) {
                result.AppendLine(BeginHtmlDocument);

                using (result.IncreaseIndent()) {
                    result.AppendLine(BeginHtmlHead);
                    result.AppendLine(EndHtmlHead);
                    result.AppendLine(BeginHtmlBody);

                    using (result.IncreaseIndent()) {
                        foreach (var node in Nodes) {
                            if (node.NodeType == NodeType.NewLine) {
                                if (!result.ToString().EndsWith("\n", StringComparison.OrdinalIgnoreCase))
                                    result.AppendLine("");

                                result.AppendLine("<BR />");
                            }

                            if (node.NodeType == NodeType.Text)
                                result.Append(node.Value.Replace("  ", "&nbsp;&nbsp;").Replace("&nbsp; ", "&nbsp;&nbsp;"));

                            if (node.NodeType != NodeType.Escape)
                                continue;

                            foreach (var sequence in ((EscapeDocumentNode)node).EscapeSequences) {
                                if (sequence.GetType().Equals(typeof(NormalEscapeSequence)))
                                    while (closing.Count > 0)
                                        result.Append(closing.Pop().CloseHtmlTag);
                                else
                                    closing.Push(sequence);

                                result.Append(sequence.OpenHtmlTag);
                            }
                        }
                    }

                    result.AppendLine(EndHtmlBody);
                }

                result.AppendLine(EndHtmlDocument);

                HtmlText = result.ToString();
            }

            return HtmlText;
        }

        private string BeginHtmlDocument {
            get {
                return "<html>";
            }
        }

        private string EndHtmlDocument {
            get {
                return "</html>";
            }
        }

        private string BeginHtmlHead {
            get {
                return "<head>";
            }
        }

        private string EndHtmlHead {
            get {
                return "</head>";
            }
        }

        private string BeginHtmlBody {
            get {
                return string.Format("<body {0}>", BodyStyle);
            }
        }

        private string EndHtmlBody {
            get {
                return "</body>";
            }
        }

        public string BodyStyle {
            get;
            set;
        }

        public string BodyStyleFixed {
            get {
                return "style=\"font-family: 'Courier New'; font-size: 10pt; background-color: #FFF; color: #000;\"";
            }
        }

        public string BodyStyleProportional {
            get {
                return "style=\"font-family: Arial; font-size: 10pt; background-color: #FFF; color: #000;\"";
            }
        }

        #endregion
    }
}
