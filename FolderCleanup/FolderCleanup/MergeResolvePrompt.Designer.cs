namespace FolderCleanup
{
    partial class MergeResolvePrompt
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.MergeButton = new System.Windows.Forms.Button();
            this.OverwriteButton = new System.Windows.Forms.Button();
            this.DiscardButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(493, 204);
            this.panel1.TabIndex = 0;
            // 
            // MergeButton
            // 
            this.MergeButton.Location = new System.Drawing.Point(3, 4);
            this.MergeButton.Name = "MergeButton";
            this.MergeButton.Size = new System.Drawing.Size(75, 23);
            this.MergeButton.TabIndex = 0;
            this.MergeButton.Text = "Merge";
            this.MergeButton.UseVisualStyleBackColor = true;
            this.MergeButton.Click += new System.EventHandler(this.MergeButton_Click);
            // 
            // OverwriteButton
            // 
            this.OverwriteButton.Location = new System.Drawing.Point(84, 4);
            this.OverwriteButton.Name = "OverwriteButton";
            this.OverwriteButton.Size = new System.Drawing.Size(75, 23);
            this.OverwriteButton.TabIndex = 1;
            this.OverwriteButton.Text = "Overwrite";
            this.OverwriteButton.UseVisualStyleBackColor = true;
            this.OverwriteButton.Click += new System.EventHandler(this.OverwriteButton_Click);
            // 
            // DiscardButton
            // 
            this.DiscardButton.Location = new System.Drawing.Point(165, 4);
            this.DiscardButton.Name = "DiscardButton";
            this.DiscardButton.Size = new System.Drawing.Size(75, 23);
            this.DiscardButton.TabIndex = 2;
            this.DiscardButton.Text = "Discard";
            this.DiscardButton.UseVisualStyleBackColor = true;
            this.DiscardButton.Click += new System.EventHandler(this.DiscardButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(246, 4);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 3;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.MergeButton);
            this.panel2.Controls.Add(this.CancelButton);
            this.panel2.Controls.Add(this.OverwriteButton);
            this.panel2.Controls.Add(this.DiscardButton);
            this.panel2.Location = new System.Drawing.Point(164, 171);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(326, 30);
            this.panel2.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.richTextBox1);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(487, 162);
            this.panel3.TabIndex = 5;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(481, 156);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // MergeResolvePrompt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 229);
            this.Controls.Add(this.panel1);
            this.Name = "MergeResolvePrompt";
            this.Text = "MergeResolvePrompt";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button MergeButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OverwriteButton;
        private System.Windows.Forms.Button DiscardButton;
    }
}