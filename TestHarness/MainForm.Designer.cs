namespace TestHarness
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.generateButton = new System.Windows.Forms.Button();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.parseButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.displayTabPage = new System.Windows.Forms.TabPage();
            this.displayWebBrowser = new System.Windows.Forms.WebBrowser();
            this.label2 = new System.Windows.Forms.Label();
            this.sourceTabPage = new System.Windows.Forms.TabPage();
            this.sourceTextBox = new System.Windows.Forms.TextBox();
            this.nodesTabPage = new System.Windows.Forms.TabPage();
            this.nodesTreeView = new System.Windows.Forms.TreeView();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.displayTabPage.SuspendLayout();
            this.sourceTabPage.SuspendLayout();
            this.nodesTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(815, 589);
            this.panel2.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(10, 10);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.inputTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(795, 569);
            this.splitContainer1.SplitterDistance = 279;
            this.splitContainer1.TabIndex = 1;
            // 
            // inputTextBox
            // 
            this.inputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputTextBox.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputTextBox.Location = new System.Drawing.Point(0, 0);
            this.inputTextBox.Multiline = true;
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.inputTextBox.Size = new System.Drawing.Size(795, 236);
            this.inputTextBox.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.generateButton);
            this.panel3.Controls.Add(this.radioButton2);
            this.panel3.Controls.Add(this.radioButton1);
            this.panel3.Controls.Add(this.parseButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 236);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.panel3.Size = new System.Drawing.Size(795, 43);
            this.panel3.TabIndex = 1;
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(259, 10);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(75, 23);
            this.generateButton.TabIndex = 6;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(172, 13);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(81, 17);
            this.radioButton2.TabIndex = 5;
            this.radioButton2.Text = "Proportional";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(81, 13);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(78, 17);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Fixed width";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // parseButton
            // 
            this.parseButton.Location = new System.Drawing.Point(0, 10);
            this.parseButton.Name = "parseButton";
            this.parseButton.Size = new System.Drawing.Size(75, 23);
            this.parseButton.TabIndex = 3;
            this.parseButton.Text = "Parse";
            this.parseButton.UseVisualStyleBackColor = true;
            this.parseButton.Click += new System.EventHandler(this.parseButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.displayTabPage);
            this.tabControl1.Controls.Add(this.sourceTabPage);
            this.tabControl1.Controls.Add(this.nodesTabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(795, 286);
            this.tabControl1.TabIndex = 0;
            // 
            // displayTabPage
            // 
            this.displayTabPage.Controls.Add(this.displayWebBrowser);
            this.displayTabPage.Controls.Add(this.label2);
            this.displayTabPage.Location = new System.Drawing.Point(4, 22);
            this.displayTabPage.Name = "displayTabPage";
            this.displayTabPage.Padding = new System.Windows.Forms.Padding(10);
            this.displayTabPage.Size = new System.Drawing.Size(787, 260);
            this.displayTabPage.TabIndex = 0;
            this.displayTabPage.Text = "Display";
            this.displayTabPage.UseVisualStyleBackColor = true;
            // 
            // displayWebBrowser
            // 
            this.displayWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.displayWebBrowser.Location = new System.Drawing.Point(10, 26);
            this.displayWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.displayWebBrowser.Name = "displayWebBrowser";
            this.displayWebBrowser.Size = new System.Drawing.Size(767, 224);
            this.displayWebBrowser.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(752, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = " 0........1.........2.........3.........4.........5.........6.........7.........8" +
    ".........9..";
            // 
            // sourceTabPage
            // 
            this.sourceTabPage.Controls.Add(this.sourceTextBox);
            this.sourceTabPage.Location = new System.Drawing.Point(4, 22);
            this.sourceTabPage.Name = "sourceTabPage";
            this.sourceTabPage.Padding = new System.Windows.Forms.Padding(10);
            this.sourceTabPage.Size = new System.Drawing.Size(787, 260);
            this.sourceTabPage.TabIndex = 1;
            this.sourceTabPage.Text = "Source";
            this.sourceTabPage.UseVisualStyleBackColor = true;
            // 
            // sourceTextBox
            // 
            this.sourceTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourceTextBox.Font = new System.Drawing.Font("Courier New", 9F);
            this.sourceTextBox.Location = new System.Drawing.Point(10, 10);
            this.sourceTextBox.Multiline = true;
            this.sourceTextBox.Name = "sourceTextBox";
            this.sourceTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.sourceTextBox.Size = new System.Drawing.Size(755, 211);
            this.sourceTextBox.TabIndex = 1;
            // 
            // nodesTabPage
            // 
            this.nodesTabPage.Controls.Add(this.nodesTreeView);
            this.nodesTabPage.Location = new System.Drawing.Point(4, 22);
            this.nodesTabPage.Name = "nodesTabPage";
            this.nodesTabPage.Padding = new System.Windows.Forms.Padding(10);
            this.nodesTabPage.Size = new System.Drawing.Size(787, 260);
            this.nodesTabPage.TabIndex = 2;
            this.nodesTabPage.Text = "Nodes";
            this.nodesTabPage.UseVisualStyleBackColor = true;
            // 
            // nodesTreeView
            // 
            this.nodesTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nodesTreeView.Location = new System.Drawing.Point(10, 10);
            this.nodesTreeView.Name = "nodesTreeView";
            this.nodesTreeView.Size = new System.Drawing.Size(755, 211);
            this.nodesTreeView.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 589);
            this.Controls.Add(this.panel2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MEDITECH Document Builder Test Harness";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.displayTabPage.ResumeLayout(false);
            this.displayTabPage.PerformLayout();
            this.sourceTabPage.ResumeLayout(false);
            this.sourceTabPage.PerformLayout();
            this.nodesTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button parseButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage displayTabPage;
        private System.Windows.Forms.WebBrowser displayWebBrowser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage sourceTabPage;
        private System.Windows.Forms.TextBox sourceTextBox;
        private System.Windows.Forms.TabPage nodesTabPage;
        private System.Windows.Forms.TreeView nodesTreeView;
        private System.Windows.Forms.Button generateButton;
    }
}

