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
namespace MeditechUtilities
{
    /// <summary>
    /// Represents a MEDITECH escape sequence
    /// </summary>
    public class EscapeSequence
    {
        /// <summary>
        /// Gets or sets the MEDITECH escape code
        /// </summary>
        public string Code {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the description of the escape code
        /// </summary>
        public string Description {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the opening HTML tag
        /// </summary>
        public string OpenHtmlTag {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the closing HTML tag
        /// </summary>
        public string CloseHtmlTag {
            get;
            set;
        }

        /// <summary>
        /// Gets the character used to detect escape mode
        /// </summary>
        public static char EscapeCharacter {
            get {
                return @"\".ToCharArray()[0];
            }
        }

        /// <summary>
        /// Gets a character used to detect local mode
        /// </summary>
        public static char LocalCharacter {
            get {
                return "Z".ToCharArray()[0];
            }
        }
    }
}
