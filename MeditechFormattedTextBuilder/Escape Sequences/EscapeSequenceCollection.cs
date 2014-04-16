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
using System.Collections.ObjectModel;
using System.Linq;

namespace MeditechUtilities
{
    /// <summary>
    /// A collection of MEDITECH escape sequences
    /// </summary>
    public class EscapeSequenceCollection : Collection<EscapeSequence>
    {
        static EscapeSequenceCollection supportedSequences;
        /// <summary>
        /// A collection of supported escape sequences.
        /// </summary>
        public static EscapeSequenceCollection SupportedSequences {
            get {
                if (supportedSequences == null) {
                    supportedSequences = new EscapeSequenceCollection();

                    supportedSequences.Add(new HighlightEscapeSequence());
                    supportedSequences.Add(new NormalEscapeSequence());
                    supportedSequences.Add(new ItalicEscapeSequence());
                    supportedSequences.Add(new UnderlineEscapeSequence());
                }

                return supportedSequences;
            }
        }

        public EscapeSequenceCollection() {
        }

        public EscapeSequence this[string code] {
            get {
                return this.Where(p => p.Code.Equals(code, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            }
        }
    }
}
