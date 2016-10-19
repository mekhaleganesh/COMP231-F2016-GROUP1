namespace PasswordApplication
{
    partial class NewRecordForm
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
            this.CreateNewRecordLabel = new System.Windows.Forms.Label();
            this.CategoryLabel = new System.Windows.Forms.Label();
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.VerifyPwLabel = new System.Windows.Forms.Label();
            this.NoteLabel = new System.Windows.Forms.Label();
            this.SaveNewRecordButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.CategoryOptionComboBox = new System.Windows.Forms.ComboBox();
            this.UserNameTextBox = new System.Windows.Forms.TextBox();
            this.NoteTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.VerifyPasswordTextBox = new System.Windows.Forms.TextBox();
            this.GenerateNewCateButton = new System.Windows.Forms.Button();
            this.GeneratePwButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CreateNewRecordLabel
            // 
            this.CreateNewRecordLabel.AutoSize = true;
            this.CreateNewRecordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateNewRecordLabel.Location = new System.Drawing.Point(20, 45);
            this.CreateNewRecordLabel.Name = "CreateNewRecordLabel";
            this.CreateNewRecordLabel.Size = new System.Drawing.Size(181, 24);
            this.CreateNewRecordLabel.TabIndex = 0;
            this.CreateNewRecordLabel.Text = "Create New Record:";
            // 
            // CategoryLabel
            // 
            this.CategoryLabel.AutoSize = true;
            this.CategoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CategoryLabel.Location = new System.Drawing.Point(74, 98);
            this.CategoryLabel.Name = "CategoryLabel";
            this.CategoryLabel.Size = new System.Drawing.Size(77, 20);
            this.CategoryLabel.TabIndex = 1;
            this.CategoryLabel.Text = "Category:";
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNameLabel.Location = new System.Drawing.Point(58, 140);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(93, 20);
            this.UserNameLabel.TabIndex = 2;
            this.UserNameLabel.Text = "User Name:";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLabel.Location = new System.Drawing.Point(69, 182);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(82, 20);
            this.PasswordLabel.TabIndex = 3;
            this.PasswordLabel.Text = "Password:";
            // 
            // VerifyPwLabel
            // 
            this.VerifyPwLabel.AutoSize = true;
            this.VerifyPwLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VerifyPwLabel.Location = new System.Drawing.Point(25, 224);
            this.VerifyPwLabel.Name = "VerifyPwLabel";
            this.VerifyPwLabel.Size = new System.Drawing.Size(126, 20);
            this.VerifyPwLabel.TabIndex = 4;
            this.VerifyPwLabel.Text = "Verify Password:";
            // 
            // NoteLabel
            // 
            this.NoteLabel.AutoSize = true;
            this.NoteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoteLabel.Location = new System.Drawing.Point(104, 266);
            this.NoteLabel.Name = "NoteLabel";
            this.NoteLabel.Size = new System.Drawing.Size(47, 20);
            this.NoteLabel.TabIndex = 5;
            this.NoteLabel.Text = "Note:";
            // 
            // SaveNewRecordButton
            // 
            this.SaveNewRecordButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveNewRecordButton.Location = new System.Drawing.Point(157, 437);
            this.SaveNewRecordButton.Name = "SaveNewRecordButton";
            this.SaveNewRecordButton.Size = new System.Drawing.Size(91, 28);
            this.SaveNewRecordButton.TabIndex = 6;
            this.SaveNewRecordButton.Text = "Save";
            this.SaveNewRecordButton.UseVisualStyleBackColor = true;
            this.SaveNewRecordButton.Click += new System.EventHandler(this.SaveNewRecordButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.Location = new System.Drawing.Point(297, 437);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(82, 28);
            this.CancelButton.TabIndex = 7;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // CategoryOptionComboBox
            // 
            this.CategoryOptionComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CategoryOptionComboBox.FormattingEnabled = true;
            this.CategoryOptionComboBox.Location = new System.Drawing.Point(158, 98);
            this.CategoryOptionComboBox.Name = "CategoryOptionComboBox";
            this.CategoryOptionComboBox.Size = new System.Drawing.Size(178, 28);
            this.CategoryOptionComboBox.TabIndex = 8;
            // 
            // UserNameTextBox
            // 
            this.UserNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNameTextBox.Location = new System.Drawing.Point(158, 139);
            this.UserNameTextBox.Name = "UserNameTextBox";
            this.UserNameTextBox.Size = new System.Drawing.Size(178, 26);
            this.UserNameTextBox.TabIndex = 9;
            // 
            // NoteTextBox
            // 
            this.NoteTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoteTextBox.Location = new System.Drawing.Point(158, 266);
            this.NoteTextBox.Multiline = true;
            this.NoteTextBox.Name = "NoteTextBox";
            this.NoteTextBox.Size = new System.Drawing.Size(321, 127);
            this.NoteTextBox.TabIndex = 10;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTextBox.Location = new System.Drawing.Point(158, 182);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(178, 26);
            this.PasswordTextBox.TabIndex = 11;
            // 
            // VerifyPasswordTextBox
            // 
            this.VerifyPasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VerifyPasswordTextBox.Location = new System.Drawing.Point(157, 226);
            this.VerifyPasswordTextBox.Name = "VerifyPasswordTextBox";
            this.VerifyPasswordTextBox.PasswordChar = '*';
            this.VerifyPasswordTextBox.Size = new System.Drawing.Size(179, 26);
            this.VerifyPasswordTextBox.TabIndex = 12;
            // 
            // GenerateNewCateButton
            // 
            this.GenerateNewCateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenerateNewCateButton.Location = new System.Drawing.Point(351, 98);
            this.GenerateNewCateButton.Name = "GenerateNewCateButton";
            this.GenerateNewCateButton.Size = new System.Drawing.Size(97, 28);
            this.GenerateNewCateButton.TabIndex = 13;
            this.GenerateNewCateButton.Text = "New Category";
            this.GenerateNewCateButton.UseVisualStyleBackColor = true;
            // 
            // GeneratePwButton
            // 
            this.GeneratePwButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GeneratePwButton.Location = new System.Drawing.Point(351, 182);
            this.GeneratePwButton.Name = "GeneratePwButton";
            this.GeneratePwButton.Size = new System.Drawing.Size(128, 28);
            this.GeneratePwButton.TabIndex = 14;
            this.GeneratePwButton.Text = "Generate Password";
            this.GeneratePwButton.UseVisualStyleBackColor = true;
            // 
            // NewRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(538, 503);
            this.Controls.Add(this.GeneratePwButton);
            this.Controls.Add(this.GenerateNewCateButton);
            this.Controls.Add(this.VerifyPasswordTextBox);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.NoteTextBox);
            this.Controls.Add(this.UserNameTextBox);
            this.Controls.Add(this.CategoryOptionComboBox);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveNewRecordButton);
            this.Controls.Add(this.NoteLabel);
            this.Controls.Add(this.VerifyPwLabel);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UserNameLabel);
            this.Controls.Add(this.CategoryLabel);
            this.Controls.Add(this.CreateNewRecordLabel);
            this.Name = "NewRecordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Record";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CreateNewRecordLabel;
        private System.Windows.Forms.Label CategoryLabel;
        private System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label VerifyPwLabel;
        private System.Windows.Forms.Label NoteLabel;
        private System.Windows.Forms.Button SaveNewRecordButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.ComboBox CategoryOptionComboBox;
        private System.Windows.Forms.TextBox UserNameTextBox;
        private System.Windows.Forms.TextBox NoteTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.TextBox VerifyPasswordTextBox;
        private System.Windows.Forms.Button GenerateNewCateButton;
        private System.Windows.Forms.Button GeneratePwButton;
    }
}