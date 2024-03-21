namespace discordServer
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
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.logs_server = new System.Windows.Forms.RichTextBox();
            this.serverUsers = new System.Windows.Forms.RichTextBox();
            this.label_port = new System.Windows.Forms.Label();
            this.button_listen = new System.Windows.Forms.Button();
            this.label_server = new System.Windows.Forms.Label();
            this.label_serverUsers = new System.Windows.Forms.Label();
            this.logs_if100 = new System.Windows.Forms.RichTextBox();
            this.label_if100 = new System.Windows.Forms.Label();
            this.if100Users = new System.Windows.Forms.RichTextBox();
            this.label_if100users = new System.Windows.Forms.Label();
            this.logs_sps101 = new System.Windows.Forms.RichTextBox();
            this.label_sps101 = new System.Windows.Forms.Label();
            this.sps101Users = new System.Windows.Forms.RichTextBox();
            this.label_sps101users = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(105, 44);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(188, 22);
            this.textBox_port.TabIndex = 20;
            // 
            // logs_server
            // 
            this.logs_server.Location = new System.Drawing.Point(49, 109);
            this.logs_server.Name = "logs_server";
            this.logs_server.Size = new System.Drawing.Size(194, 253);
            this.logs_server.TabIndex = 21;
            this.logs_server.Text = "";
            // 
            // serverUsers
            // 
            this.serverUsers.Location = new System.Drawing.Point(249, 107);
            this.serverUsers.Name = "serverUsers";
            this.serverUsers.Size = new System.Drawing.Size(85, 255);
            this.serverUsers.TabIndex = 22;
            this.serverUsers.Text = "";
            // 
            // label_port
            // 
            this.label_port.AutoSize = true;
            this.label_port.Location = new System.Drawing.Point(46, 49);
            this.label_port.Name = "label_port";
            this.label_port.Size = new System.Drawing.Size(38, 17);
            this.label_port.TabIndex = 23;
            this.label_port.Text = "Port:";
            // 
            // button_listen
            // 
            this.button_listen.Location = new System.Drawing.Point(329, 41);
            this.button_listen.Name = "button_listen";
            this.button_listen.Size = new System.Drawing.Size(80, 29);
            this.button_listen.TabIndex = 24;
            this.button_listen.Text = "Listen";
            this.button_listen.UseVisualStyleBackColor = true;
            this.button_listen.Click += new System.EventHandler(this.button_listen_Click_1);
            // 
            // label_server
            // 
            this.label_server.AutoSize = true;
            this.label_server.Location = new System.Drawing.Point(46, 89);
            this.label_server.Name = "label_server";
            this.label_server.Size = new System.Drawing.Size(50, 17);
            this.label_server.TabIndex = 25;
            this.label_server.Text = "Server";
            // 
            // label_serverUsers
            // 
            this.label_serverUsers.AutoSize = true;
            this.label_serverUsers.Location = new System.Drawing.Point(246, 87);
            this.label_serverUsers.Name = "label_serverUsers";
            this.label_serverUsers.Size = new System.Drawing.Size(91, 17);
            this.label_serverUsers.TabIndex = 26;
            this.label_serverUsers.Text = "Server Users";
            // 
            // logs_if100
            // 
            this.logs_if100.Location = new System.Drawing.Point(456, 107);
            this.logs_if100.Name = "logs_if100";
            this.logs_if100.Size = new System.Drawing.Size(192, 255);
            this.logs_if100.TabIndex = 27;
            this.logs_if100.Text = "";
            // 
            // label_if100
            // 
            this.label_if100.AutoSize = true;
            this.label_if100.Location = new System.Drawing.Point(453, 89);
            this.label_if100.Name = "label_if100";
            this.label_if100.Size = new System.Drawing.Size(43, 17);
            this.label_if100.TabIndex = 28;
            this.label_if100.Text = "IF100";
            // 
            // if100Users
            // 
            this.if100Users.Location = new System.Drawing.Point(654, 107);
            this.if100Users.Name = "if100Users";
            this.if100Users.Size = new System.Drawing.Size(85, 255);
            this.if100Users.TabIndex = 29;
            this.if100Users.Text = "";
            // 
            // label_if100users
            // 
            this.label_if100users.AutoSize = true;
            this.label_if100users.Location = new System.Drawing.Point(651, 89);
            this.label_if100users.Name = "label_if100users";
            this.label_if100users.Size = new System.Drawing.Size(84, 17);
            this.label_if100users.TabIndex = 30;
            this.label_if100users.Text = "IF100 Users";
            // 
            // logs_sps101
            // 
            this.logs_sps101.Location = new System.Drawing.Point(828, 107);
            this.logs_sps101.Name = "logs_sps101";
            this.logs_sps101.Size = new System.Drawing.Size(192, 255);
            this.logs_sps101.TabIndex = 31;
            this.logs_sps101.Text = "";
            // 
            // label_sps101
            // 
            this.label_sps101.AutoSize = true;
            this.label_sps101.Location = new System.Drawing.Point(825, 89);
            this.label_sps101.Name = "label_sps101";
            this.label_sps101.Size = new System.Drawing.Size(59, 17);
            this.label_sps101.TabIndex = 32;
            this.label_sps101.Text = "SPS101";
            // 
            // sps101Users
            // 
            this.sps101Users.Location = new System.Drawing.Point(1026, 107);
            this.sps101Users.Name = "sps101Users";
            this.sps101Users.Size = new System.Drawing.Size(97, 255);
            this.sps101Users.TabIndex = 33;
            this.sps101Users.Text = "";
            // 
            // label_sps101users
            // 
            this.label_sps101users.AutoSize = true;
            this.label_sps101users.Location = new System.Drawing.Point(1023, 89);
            this.label_sps101users.Name = "label_sps101users";
            this.label_sps101users.Size = new System.Drawing.Size(100, 17);
            this.label_sps101users.TabIndex = 34;
            this.label_sps101users.Text = "SPS101 Users";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 430);
            this.Controls.Add(this.label_sps101users);
            this.Controls.Add(this.sps101Users);
            this.Controls.Add(this.label_sps101);
            this.Controls.Add(this.logs_sps101);
            this.Controls.Add(this.label_if100users);
            this.Controls.Add(this.if100Users);
            this.Controls.Add(this.label_if100);
            this.Controls.Add(this.logs_if100);
            this.Controls.Add(this.label_serverUsers);
            this.Controls.Add(this.label_server);
            this.Controls.Add(this.button_listen);
            this.Controls.Add(this.label_port);
            this.Controls.Add(this.serverUsers);
            this.Controls.Add(this.logs_server);
            this.Controls.Add(this.textBox_port);
            this.Name = "Form1";
            this.Text = "discordServer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.RichTextBox logs_server;
        private System.Windows.Forms.RichTextBox serverUsers;
        private System.Windows.Forms.Label label_port;
        private System.Windows.Forms.Button button_listen;
        private System.Windows.Forms.Label label_server;
        private System.Windows.Forms.Label label_serverUsers;
        private System.Windows.Forms.RichTextBox logs_if100;
        private System.Windows.Forms.Label label_if100;
        private System.Windows.Forms.RichTextBox if100Users;
        private System.Windows.Forms.Label label_if100users;
        private System.Windows.Forms.RichTextBox logs_sps101;
        private System.Windows.Forms.Label label_sps101;
        private System.Windows.Forms.RichTextBox sps101Users;
        private System.Windows.Forms.Label label_sps101users;
    }
}

