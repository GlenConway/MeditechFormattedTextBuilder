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
    public class EscapeDocumentNode : DocumentNode
    {
        public EscapeDocumentNode() {
            NodeType = NodeType.Escape;
        }

        private EscapeSequenceCollection escapeSequences;
        /// <summary>
        /// Gets a collection of escape sequences.
        /// </summary>
        public EscapeSequenceCollection EscapeSequences {
            get {
                if (escapeSequences == null)
                    escapeSequences = new EscapeSequenceCollection();

                return escapeSequences;
            }
        }

        /// <summary>
        /// Populates the escape sequences based on the contents of the node value.
        /// </summary>
        public void BuildEscapeSequences() {
            if (NodeType != NodeType.Escape)
                throw new InvalidOperationException("Invalid Node Type");

            if (string.IsNullOrEmpty(Value))
                throw new InvalidOperationException("Value cannot be empty.");

            escapeSequences = null;

            for (int i = 0; i <= Value.Length - 1; i++) {
                var sequence = EscapeSequenceCollection.SupportedSequences[Value[i].ToString()];

                if (sequence == null)
                    continue;

                EscapeSequences.Add(sequence);
            }
        }

        /// <summary>
        /// Returns the MEDITECH formatting codes based on the escape sequences.
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            if (EscapeSequences.Count == 0)
                return base.ToString();

            var result = new StringBuilder();

            result.Append(EscapeSequence.EscapeCharacter);

            foreach (var sequence in EscapeSequences) {
                result.Append(sequence.Code);
            }

            result.Append(EscapeSequence.EscapeCharacter);

            return result.ToString();
        }
    }
}
