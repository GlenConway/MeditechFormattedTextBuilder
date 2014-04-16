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
using System.Collections.ObjectModel;
using System.Linq;

namespace MeditechUtilities
{
    public class DocumentNodeCollection : Collection<DocumentNode>
    {
        private int textLength = 0;
        private int lineLength = 92;

        /// <summary>
        /// Represents the maximum length between MEDITECH line breaks (tilde characters).
        /// </summary>
        public int LineLength {
            get {
                return lineLength;
            }
            set {
                if (value != lineLength)
                    lineLength = value;
            }
        }

        public static char[] LineBreaks = { char.Parse(" "), char.Parse(","), char.Parse("."), char.Parse("!"), char.Parse(")"), (char)10, (char)13 };

        public bool SupportsLocalEscapeCodes {
            get;
            set;
        }

        /// <summary>
        /// Adds an escape sequence node to revert back to normal text.
        /// </summary>
        public void StartNormalText() {
            var node = new EscapeDocumentNode();
            node.EscapeSequences.Add(new NormalEscapeSequence());

            if (textLength + node.NodeLength > lineLength)
                AddNewLine();

            this.Add(node);

            textLength += node.NodeLength;
        }

        /// <summary>
        /// Adds a node to start highlighting text.
        /// </summary>
        public void StartHighlight() {
            var node = new EscapeDocumentNode();
            node.EscapeSequences.Add(new HighlightEscapeSequence());

            if (textLength + node.NodeLength > lineLength)
                AddNewLine();

            this.Add(node);

            textLength += node.NodeLength;
        }

        /// <summary>
        /// Adds a node that combines bold and italic formatting.
        /// </summary>
        /// <remarks>Only if the target system supports local escape codes.</remarks>
        public void StartBoldItalic() {
            if (!SupportsLocalEscapeCodes)
                return;

            var node = new EscapeDocumentNode();
            node.EscapeSequences.Add(new LocalEscapeSequence());
            node.EscapeSequences.Add(new HighlightEscapeSequence());
            node.EscapeSequences.Add(new ItalicEscapeSequence());

            if (textLength + node.NodeLength > lineLength)
                AddNewLine();

            this.Add(node);

            textLength += node.NodeLength;
        }

        /// <summary>
        /// Adds a node to start italic text.
        /// </summary>
        /// <remarks>Only if the target system supports local escape codes.</remarks>
        public void StartItalic() {
            if (!SupportsLocalEscapeCodes)
                return;

            var node = new EscapeDocumentNode();
            node.EscapeSequences.Add(new LocalEscapeSequence());
            node.EscapeSequences.Add(new ItalicEscapeSequence());

            if (textLength + node.NodeLength > lineLength)
                AddNewLine();

            this.Add(node);

            textLength += node.NodeLength;
        }

        /// <summary>
        /// Adds a node that combines italic and underline formatting.
        /// </summary>
        /// <remarks>Only if the target system supports local escape codes.</remarks>
        public void StartItalicUnderline() {
            if (!SupportsLocalEscapeCodes)
                return;

            var node = new EscapeDocumentNode();
            node.EscapeSequences.Add(new LocalEscapeSequence());
            node.EscapeSequences.Add(new ItalicEscapeSequence());
            node.EscapeSequences.Add(new UnderlineEscapeSequence());

            if (textLength + node.NodeLength > lineLength)
                AddNewLine();

            this.Add(node);

            textLength += node.NodeLength;
        }

        /// <summary>
        /// Adds a node to start underlined text.
        /// </summary>
        /// <remarks>Only if the target system supports local escape codes.</remarks>
        public void StartUnderline() {
            if (!SupportsLocalEscapeCodes)
                return;

            var node = new EscapeDocumentNode();
            node.EscapeSequences.Add(new LocalEscapeSequence());
            node.EscapeSequences.Add(new UnderlineEscapeSequence());

            if (textLength + node.NodeLength > lineLength)
                AddNewLine();

            this.Add(node);

            textLength += node.NodeLength;
        }

        /// <summary>
        /// Adds a node that combines bold, italic and underline formatting.
        /// </summary>
        /// <remarks>Only if the target system supports local escape codes.</remarks>
        public void StartBoldItalicUnderline() {
            if (!SupportsLocalEscapeCodes)
                return;

            var node = new EscapeDocumentNode();
            node.EscapeSequences.Add(new LocalEscapeSequence());
            node.EscapeSequences.Add(new HighlightEscapeSequence());
            node.EscapeSequences.Add(new ItalicEscapeSequence());
            node.EscapeSequences.Add(new UnderlineEscapeSequence());

            if (textLength + node.NodeLength > lineLength)
                AddNewLine();

            this.Add(node);

            textLength += node.NodeLength;
        }

        /// <summary>
        /// Adds a new text node followed by a new line node.
        /// </summary>
        /// <param name="text"></param>
        public void AddLine(string text) {
            AddText(text);
            AddNewLine();
        }

        /// <summary>
        /// Adds a new text node followed by a new line node.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="indent"></param>
        public void AddLine(string text, int indent) {
            AddText(text, indent);
            AddNewLine();
        }

        /// <summary>
        /// Adds a new text node.
        /// </summary>
        /// <param name="text"></param>
        public void AddText(string text) {
            AddText(text, 0);
        }

        /// <summary>
        /// Adds a new text node.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="indent"></param>
        public void AddText(string text, int indent) {
            //Debug.Assert(this.Count < 224);

            //text = text.Replace("|", @"\F\");
            //text = text.Replace("^", @"\S\");
            //text = text.Replace("&", @"\T\");
            text = text.Replace("~", @"\R\");
            //text = text.Replace(@"\", @"\E\");

            if (indent > 0)
                text = new string(' ', indent) + text.Trim();

            // we are trying to add a some text but
            // it will take us over our allowed line length
            // need to check though that last node wasn't
            // a new line by ensuring that textLength > 0
            if (textLength > 0 && textLength + text.Length > lineLength)
                AddNewLine();

            var node = new TextDocumentNode();

            // check to see if the text we are adding is
            // longer than the allowed line length
            if (text.Length > lineLength) {
                var index = lineLength;

                // look for a natural break point in the text
                while (!DocumentNodeCollection.LineBreaks.Contains(text[index]) && index > 0)
                    index--;

                // split the text
                node.Value = text.Substring(0, index);
                text = text.Remove(0, index);

                // add the left side of the break
                this.Add(node);
                // add a new line ~
                this.AddNewLine();

                // now submit the right side of the text
                AddText(text, indent);
            }
            else {
                node.Value = text;
                this.Add(node);
                textLength += node.Value.Length;
            }
        }

        /// <summary>
        /// Adds a node to define the start of the document.
        /// </summary>
        public void StartDocument() {
            this.Add(new StartDocumentNode());
        }

        /// <summary>
        /// Adds a node to define the end of the document.
        /// </summary>
        public void EndDocument() {
            this.Add(new NewLineDocumentNode());
            this.Add(new EndDocumentNode());
        }

        /// <summary>
        /// Adds a node to start a new line.
        /// </summary>
        public void AddNewLine() {
            this.Add(new NewLineDocumentNode());
            textLength = 0;
        }

        /// <summary>
        /// Adds a line break consisting of two new lines.
        /// </summary>
        public void AddLineBreak() {
            if (this[this.Count - 1].NodeType != NodeType.NewLine)
                this.Add(new NewLineDocumentNode());
            this.Add(new NewLineDocumentNode());
            textLength = 0;
        }

        public void Validate() {
            var length = 0;

            for (int i = 0; i < this.Count; i++) {
                var item = this[i];

                if (item.NodeType == NodeType.NewLine)
                    length = 0;
                else
                    length += item.NodeLength;

                if (length > lineLength)
                    throw new LineLengthException("Line length is greater than the allowed length.", item);
            }
        }
    }
}
