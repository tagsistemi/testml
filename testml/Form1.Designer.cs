namespace testml
{
    partial class Form1
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
            this.buttonLogin = new System.Windows.Forms.Button();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.labelUser = new System.Windows.Forms.Label();
            this.labelPass = new System.Windows.Forms.Label();
            this.textBoxPass = new System.Windows.Forms.TextBox();
            this.richTextBoxEsito = new System.Windows.Forms.RichTextBox();
            this.buttonReport = new System.Windows.Forms.Button();
            this.richTextBoxPdfString = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(30, 74);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(491, 30);
            this.buttonLogin.TabIndex = 0;
            this.buttonLogin.Text = "Login+SetData";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // textBoxUser
            // 
            this.textBoxUser.Location = new System.Drawing.Point(30, 51);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(177, 20);
            this.textBoxUser.TabIndex = 1;
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(30, 32);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(32, 13);
            this.labelUser.TabIndex = 2;
            this.labelUser.Text = "User ";
            // 
            // labelPass
            // 
            this.labelPass.AutoSize = true;
            this.labelPass.Location = new System.Drawing.Point(222, 32);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(30, 13);
            this.labelPass.TabIndex = 4;
            this.labelPass.Text = "Pass";
            // 
            // textBoxPass
            // 
            this.textBoxPass.Location = new System.Drawing.Point(222, 51);
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.Size = new System.Drawing.Size(177, 20);
            this.textBoxPass.TabIndex = 3;
            // 
            // richTextBoxEsito
            // 
            this.richTextBoxEsito.Location = new System.Drawing.Point(33, 110);
            this.richTextBoxEsito.Name = "richTextBoxEsito";
            this.richTextBoxEsito.Size = new System.Drawing.Size(488, 123);
            this.richTextBoxEsito.TabIndex = 5;
            this.richTextBoxEsito.Text = "";
            // 
            // buttonReport
            // 
            this.buttonReport.Location = new System.Drawing.Point(33, 253);
            this.buttonReport.Name = "buttonReport";
            this.buttonReport.Size = new System.Drawing.Size(488, 36);
            this.buttonReport.TabIndex = 6;
            this.buttonReport.Text = "Execute PDF report";
            this.buttonReport.UseVisualStyleBackColor = true;
            this.buttonReport.Click += new System.EventHandler(this.buttonReport_Click);
            // 
            // richTextBoxPdfString
            // 
            this.richTextBoxPdfString.Location = new System.Drawing.Point(33, 314);
            this.richTextBoxPdfString.Name = "richTextBoxPdfString";
            this.richTextBoxPdfString.Size = new System.Drawing.Size(488, 125);
            this.richTextBoxPdfString.TabIndex = 7;
            this.richTextBoxPdfString.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 462);
            this.Controls.Add(this.richTextBoxPdfString);
            this.Controls.Add(this.buttonReport);
            this.Controls.Add(this.richTextBoxEsito);
            this.Controls.Add(this.labelPass);
            this.Controls.Add(this.textBoxPass);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.textBoxUser);
            this.Controls.Add(this.buttonLogin);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.TextBox textBoxPass;
        private System.Windows.Forms.RichTextBox richTextBoxEsito;
        private System.Windows.Forms.Button buttonReport;
        private System.Windows.Forms.RichTextBox richTextBoxPdfString;
    }
}