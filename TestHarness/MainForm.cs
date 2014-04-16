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
using System.Globalization;
using System.Windows.Forms;

namespace TestHarness
{
    public partial class MainForm : Form
    {
        public MainForm() {
            InitializeComponent();
        }

        /// <summary>
        /// Parses the text in the input text box and displays a MEDITECH document node collection and HTML representation
        /// </summary>
        private void parse() {
            var document = new MeditechUtilities.FormattedTextDocument();
            document.MeditechText = inputTextBox.Text;
            document.BodyStyle = radioButton1.Checked ? document.BodyStyleFixed : document.BodyStyleProportional;
            document.ToHtml();

            sourceTextBox.Text = document.HtmlText;
            displayWebBrowser.DocumentText = document.HtmlText;
            populateTreeView(document.Nodes);
        }

        /// <summary>
        /// Builds a tree of the MEDITECH nodes
        /// </summary>
        /// <param name="documentNodes"></param>
        private void populateTreeView(MeditechUtilities.DocumentNodeCollection documentNodes) {
            nodesTreeView.Nodes.Clear();

            var parentNode = new TreeNode("Document");

            foreach (var documentNode in documentNodes) {
                var node = new TreeNode(documentNode.DisplayName);

                if (documentNode.NodeType == MeditechUtilities.NodeType.Escape || documentNode.NodeType == MeditechUtilities.NodeType.Text) {
                    var childNode = new TreeNode(string.Format(CultureInfo.CurrentCulture, "\"{0}\"", documentNode.ToString()));
                    node.Nodes.Add(childNode);
                }

                parentNode.Nodes.Add(node);
            }

            parentNode.Expand();
            nodesTreeView.Nodes.Add(parentNode);
        }

        private void parseButton_Click(object sender, EventArgs e) {
            parse();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e) {
            updateHtmlDisplay();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e) {
            updateHtmlDisplay();
        }

        private void updateHtmlDisplay() {
            label2.Visible = radioButton1.Checked;

            parse();
        }

        private void generateButton_Click(object sender, EventArgs e) {
            generate();
            parse();
        }

        /// <summary>
        /// Generates a sample MEDITECH document
        /// </summary>
        private void generate() {
            // create the document
            var document = new MeditechUtilities.FormattedTextDocument();
            // allow local escape codes (for example italic)
            document.SupportsLocalEscapeCodes = true;

            // work with the node collection to build the document
            var nodes = document.Nodes;
            // create a new document
            nodes.StartDocument();

            // highlighted document title
            nodes.StartHighlight();
            nodes.AddText("***** DIAGNOSTIC REPORT******");
            nodes.StartNormalText();

            nodes.AddLineBreak();

            nodes.StartUnderline();
            nodes.AddText("Attending Physician");
            nodes.StartNormalText();
            nodes.AddText(": LARRY CARLIN");
            nodes.AddLineBreak();

            // this block has inline italics
            nodes.AddText("Compared to a prior study of ");
            nodes.StartItalic();
            nodes.AddText("02/22/94");
            nodes.StartNormalText();
            nodes.AddText(".  A small pneumothorax is seen at the");
            // we break here as the line will exceed the maximum line length
            nodes.AddText(" right apex.  Atelecatic changes are seen in the right mid lung and also in the left base.");
            nodes.AddLineBreak();

            nodes.AddText("Mediastinal and right thoracic chest tubes are also noted as before.");
            nodes.AddNewLine();
            nodes.AddText("Multiple surgical clips are seen in the lower thoracic region due to prior esophageal surgery.");
            nodes.AddLineBreak();

            nodes.AddText("No evidence of florid CHF.  No evidence of new parenchymal opacity since the prior study. The NG tube is also visualized as before.");
            nodes.AddLineBreak();

            nodes.AddLine("  Signed: R.A. Kolarshky, M.D.");
            nodes.AddLine("Cosigned: Victoria V. Venestia, M.D.");

            // end the document
            nodes.EndDocument();

            // build the MEDITECH formatted text codes
            inputTextBox.Text = document.ToMeditech();
        }

        private void helloWorld() {
            // create the document
            var document = new MeditechUtilities.FormattedTextDocument();
            // allow local escape codes (for example italic)
            document.SupportsLocalEscapeCodes = true;

            // work with the node collection to build the document
            var nodes = document.Nodes;
            // create a new document
            nodes.StartDocument();

            // highlighted document title
            nodes.StartHighlight();
            nodes.AddText("Hello World!");
            nodes.StartNormalText();

            // end the document
            nodes.EndDocument();

            // build the MEDITECH formatted text codes
            inputTextBox.Text = document.ToMeditech();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            helloWorld();
        }
    }
}
