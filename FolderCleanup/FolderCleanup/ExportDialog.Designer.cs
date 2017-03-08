namespace FolderCleanup
{
    partial class ExportDialog
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ExportItemList = new System.Windows.Forms.CheckedListBox();
            this.ExportPathBox = new System.Windows.Forms.TextBox();
            this.ExportPathButton = new System.Windows.Forms.Button();
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
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(506, 312);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.CancelButton);
            this.panel2.Controls.Add(this.OkButton);
            this.panel2.Location = new System.Drawing.Point(339, 277);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(164, 32);
            this.panel2.TabIndex = 0;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(85, 4);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(4, 4);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 0;
            this.OkButton.Text = "Ok";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ExportPathButton);
            this.panel3.Controls.Add(this.ExportPathBox);
            this.panel3.Controls.Add(this.ExportItemList);
            this.panel3.Location = new System.Drawing.Point(4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(499, 267);
            this.panel3.TabIndex = 1;
            // 
            // ExportItemList
            // 
            this.ExportItemList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ExportItemList.FormattingEnabled = true;
            this.ExportItemList.Location = new System.Drawing.Point(4, 4);
            this.ExportItemList.Name = "ExportItemList";
            this.ExportItemList.Size = new System.Drawing.Size(200, 259);
            this.ExportItemList.TabIndex = 0;
            // 
            // ExportPathBox
            // 
            this.ExportPathBox.Location = new System.Drawing.Point(211, 4);
            this.ExportPathBox.Name = "ExportPathBox";
            this.ExportPathBox.ReadOnly = true;
            this.ExportPathBox.Size = new System.Drawing.Size(249, 20);
            this.ExportPathBox.TabIndex = 1;
            // 
            // ExportPathButton
            // 
            this.ExportPathButton.Location = new System.Drawing.Point(466, 2);
            this.ExportPathButton.Name = "ExportPathButton";
            this.ExportPathButton.Size = new System.Drawing.Size(29, 23);
            this.ExportPathButton.TabIndex = 2;
            this.ExportPathButton.Text = "...";
            this.ExportPathButton.UseVisualStyleBackColor = true;
            this.ExportPathButton.Click += new System.EventHandler(this.ExportPathButton_Click);
            // 
            // ExportDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 336);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ExportDialog";
            this.Text = "ExportDialog";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckedListBox ExportItemList;
        private System.Windows.Forms.Button ExportPathButton;
        private System.Windows.Forms.TextBox ExportPathBox;
    }
}