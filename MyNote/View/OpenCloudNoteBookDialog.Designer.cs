namespace MyNote.View
{
    partial class OpenCloudNoteBookDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.InputCloudPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.InputNoteBook = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.InputLocalPath = new System.Windows.Forms.TextBox();
            this.BtnSelectLocalPath = new System.Windows.Forms.Button();
            this.BtnOpen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "云存储路径:";
            // 
            // InputCloudPath
            // 
            this.InputCloudPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InputCloudPath.Location = new System.Drawing.Point(97, 24);
            this.InputCloudPath.Name = "InputCloudPath";
            this.InputCloudPath.Size = new System.Drawing.Size(341, 21);
            this.InputCloudPath.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "笔记本名称:";
            // 
            // InputNoteBook
            // 
            this.InputNoteBook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InputNoteBook.Location = new System.Drawing.Point(97, 56);
            this.InputNoteBook.Name = "InputNoteBook";
            this.InputNoteBook.Size = new System.Drawing.Size(341, 21);
            this.InputNoteBook.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "本地存储路径:";
            // 
            // InputLocalPath
            // 
            this.InputLocalPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InputLocalPath.Location = new System.Drawing.Point(97, 87);
            this.InputLocalPath.Name = "InputLocalPath";
            this.InputLocalPath.Size = new System.Drawing.Size(276, 21);
            this.InputLocalPath.TabIndex = 5;
            // 
            // BtnSelectLocalPath
            // 
            this.BtnSelectLocalPath.Location = new System.Drawing.Point(380, 87);
            this.BtnSelectLocalPath.Name = "BtnSelectLocalPath";
            this.BtnSelectLocalPath.Size = new System.Drawing.Size(59, 23);
            this.BtnSelectLocalPath.TabIndex = 6;
            this.BtnSelectLocalPath.Text = "浏览";
            this.BtnSelectLocalPath.UseVisualStyleBackColor = true;
            this.BtnSelectLocalPath.Click += new System.EventHandler(this.OnSelectLocalPathEvt);
            // 
            // BtnOpen
            // 
            this.BtnOpen.Location = new System.Drawing.Point(183, 137);
            this.BtnOpen.Name = "BtnOpen";
            this.BtnOpen.Size = new System.Drawing.Size(75, 23);
            this.BtnOpen.TabIndex = 7;
            this.BtnOpen.Text = "打开笔记本";
            this.BtnOpen.UseVisualStyleBackColor = true;
            this.BtnOpen.Click += new System.EventHandler(this.OnOpenCloudNetBookEvt);
            // 
            // OpenCloudNoteBookDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 183);
            this.Controls.Add(this.BtnOpen);
            this.Controls.Add(this.BtnSelectLocalPath);
            this.Controls.Add(this.InputLocalPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.InputNoteBook);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.InputCloudPath);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OpenCloudNoteBookDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "打开网络笔记本";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox InputCloudPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox InputNoteBook;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox InputLocalPath;
        private System.Windows.Forms.Button BtnSelectLocalPath;
        private System.Windows.Forms.Button BtnOpen;
    }
}