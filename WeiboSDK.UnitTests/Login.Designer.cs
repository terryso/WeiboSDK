namespace WeiboSDK.UnitTests
{
    partial class Login
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
            this.txtToken = new System.Windows.Forms.TextBox();
            this.btnGetPin = new System.Windows.Forms.Button();
            this.txtPin = new System.Windows.Forms.TextBox();
            this.ddlWeibo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtToken
            // 
            this.txtToken.Location = new System.Drawing.Point(26, 78);
            this.txtToken.Multiline = true;
            this.txtToken.Name = "txtToken";
            this.txtToken.Size = new System.Drawing.Size(230, 167);
            this.txtToken.TabIndex = 8;
            // 
            // btnGetPin
            // 
            this.btnGetPin.Location = new System.Drawing.Point(181, 49);
            this.btnGetPin.Name = "btnGetPin";
            this.btnGetPin.Size = new System.Drawing.Size(75, 23);
            this.btnGetPin.TabIndex = 13;
            this.btnGetPin.Text = "获取授权码";
            this.btnGetPin.UseVisualStyleBackColor = true;
            this.btnGetPin.Click += new System.EventHandler(this.btnGetPin_Click);
            // 
            // txtPin
            // 
            this.txtPin.Location = new System.Drawing.Point(75, 49);
            this.txtPin.Name = "txtPin";
            this.txtPin.Size = new System.Drawing.Size(100, 21);
            this.txtPin.TabIndex = 12;
            // 
            // ddlWeibo
            // 
            this.ddlWeibo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlWeibo.FormattingEnabled = true;
            this.ddlWeibo.Items.AddRange(new object[] {
            "新浪微博",
            "腾讯微博"});
            this.ddlWeibo.Location = new System.Drawing.Point(75, 19);
            this.ddlWeibo.Name = "ddlWeibo";
            this.ddlWeibo.Size = new System.Drawing.Size(100, 20);
            this.ddlWeibo.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "授权码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "微  博：";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(26, 251);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(230, 51);
            this.btnLogin.TabIndex = 14;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click_1);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 314);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnGetPin);
            this.Controls.Add(this.txtPin);
            this.Controls.Add(this.ddlWeibo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtToken);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录窗口";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtToken;
        private System.Windows.Forms.Button btnGetPin;
        private System.Windows.Forms.TextBox txtPin;
        private System.Windows.Forms.ComboBox ddlWeibo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogin;
    }
}