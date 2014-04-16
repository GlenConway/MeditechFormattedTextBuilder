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
using System.Globalization;

namespace MeditechUtilities
{
    public enum NodeType
    {
        DocumentStart,
        Escape,
        Text,
        NewLine,
        DocumentEnd
    }

    public class DocumentNode
    {
        /// <summary>
        /// Gets or sets the value of the node.
        /// </summary>
        public string Value {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the type of node.
        /// </summary>
        public NodeType NodeType {
            get;
            set;
        }

        /// <summary>
        /// Returns an empty string.
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return string.Empty;
        }

        /// <summary>
        /// Returns the length of this type of node.
        /// </summary>
        public int NodeLength {
            get {
                var text = ToString();

                if (string.IsNullOrEmpty(text))
                    return 0;

                return text.Length;
            }
        }

        public string DisplayName {
            get {
                return string.Format(CultureInfo.InvariantCulture, "Type = {0}, Length = {1}, Value = '{2}'", NodeType.ToString(), NodeLength.ToString(), Value);
            }
        }
    }
}
