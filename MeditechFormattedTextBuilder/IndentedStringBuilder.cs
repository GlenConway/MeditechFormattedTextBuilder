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
using System.Text;

namespace MeditechUtilities
{
    public sealed class IndentedStringBuilder : IDisposable
    {
        private StringBuilder sb;
        private string indentationString = "  ";
        private string completeIndentationString = "";
        private int indent;

        /// <summary>
        ///  Creates an IndentedStringBuilder
        /// </summary>
        public IndentedStringBuilder() {
            sb = new StringBuilder();
        }

        /// <summary>
        /// Appends a string
        /// </summary>
        /// <param name="value"></param>
        public void Append(string value) {
            if (this.ToString().EndsWith("\n", StringComparison.OrdinalIgnoreCase))
                sb.Append(completeIndentationString + value);
            else
                sb.Append(value);
        }

        /// <summary>
        /// Appends a line
        /// </summary>
        /// <param name="value"></param>
        public void AppendLine(string value) {
            Append(value + Environment.NewLine);
        }

        /// <summary>
        /// The string/chars to use for indentation, \t by default
        /// </summary>
        public string IndentationString {
            get {
                return indentationString;
            }
            set {
                indentationString = value;

                updateCompleteIndentationString();
            }
        }

        /// <summary>
        /// Creates the actual indentation string
        /// </summary>
        private void updateCompleteIndentationString() {
            completeIndentationString = "";

            for (int i = 0; i < indent; i++)
                completeIndentationString += indentationString;
        }

        /// <summary>
        /// Increases indentation, returns a reference to an IndentedStringBuilder instance which is only to be used for disposal
        /// </summary>
        /// <returns></returns>
        public IndentedStringBuilder IncreaseIndent() {
            indent++;

            updateCompleteIndentationString();

            return this;
        }

        /// <summary>
        /// Decreases indentation, may only be called if indentation > 1
        /// </summary>
        public void DecreaseIndent() {
            if (indent > 0) {
                indent--;

                updateCompleteIndentationString();
            }
        }

        /// <summary>
        /// Decreases indentation
        /// </summary>
        public void Dispose() {
            DecreaseIndent();
        }

        /// <summary>
        /// Returns the text of the internal StringBuilder
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return sb.ToString();
        }
    }
}
