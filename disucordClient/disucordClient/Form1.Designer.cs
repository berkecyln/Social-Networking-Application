namespace disucordClient
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
            this.textbox_ip = new System.Windows.Forms.TextBox();
            this.label_ip = new System.Windows.Forms.Label();
            this.textbox_username = new System.Windows.Forms.TextBox();
            this.label_username = new System.Windows.Forms.Label();
            this.button_connect = new System.Windows.Forms.Button();
            this.button_disconnect = new System.Windows.Forms.Button();
            this.label_channel = new System.Windows.Forms.Label();
            this.combobox_channel = new System.Windows.Forms.ComboBox();
            this.button_subscribe = new System.Windows.Forms.Button();
            this.button_unsubscribe = new System.Windows.Forms.Button();
            this.label_message = new System.Windows.Forms.Label();
            this.textbox_message = new System.Windows.Forms.TextBox();
            this.button_send = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label_if100 = new System.Windows.Forms.Label();
            this.label_sps101 = new System.Windows.Forms.Label();
            this.if100_logs = new System.Windows.Forms.RichTextBox();
            this.label_app = new System.Windows.Forms.Label();
            this.sps101_logs = new System.Windows.Forms.RichTextBox();
            this.label_port = new System.Windows.Forms.Label();
            this.textbox_port = new System.Windows.Forms.TextBox();
            this.logs = new System.Windows.Forms.RichTextBox();
            this.label_server = new System.Windows.Forms.Label();
            this.label_status = new System.Windows.Forms.Label();
            this.pictureBox_status = new System.Windows.Forms.PictureBox();
            this.comboBox_message = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_status)).BeginInit();
            this.SuspendLayout();
            // 
            // textbox_ip
            // 
            this.textbox_ip.Location = new System.Drawing.Point(255, 181);
            this.textbox_ip.Name = "textbox_ip";
            this.textbox_ip.Size = new System.Drawing.Size(220, 31);
            this.textbox_ip.TabIndex = 0;
            // 
            // label_ip
            // 
            this.label_ip.AutoSize = true;
            this.label_ip.Location = new System.Drawing.Point(87, 184);
            this.label_ip.Name = "label_ip";
            this.label_ip.Size = new System.Drawing.Size(37, 25);
            this.label_ip.TabIndex = 1;
            this.label_ip.Text = "IP:";
            // 
            // textbox_username
            // 
            this.textbox_username.Location = new System.Drawing.Point(255, 298);
            this.textbox_username.Name = "textbox_username";
            this.textbox_username.Size = new System.Drawing.Size(220, 31);
            this.textbox_username.TabIndex = 2;
            // 
            // label_username
            // 
            this.label_username.AutoSize = true;
            this.label_username.Location = new System.Drawing.Point(87, 301);
            this.label_username.Name = "label_username";
            this.label_username.Size = new System.Drawing.Size(116, 25);
            this.label_username.TabIndex = 3;
            this.label_username.Text = "Username:";
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(102, 361);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(150, 50);
            this.button_connect.TabIndex = 4;
            this.button_connect.Text = "Connect";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // button_disconnect
            // 
            this.button_disconnect.Enabled = false;
            this.button_disconnect.Location = new System.Drawing.Point(293, 361);
            this.button_disconnect.Name = "button_disconnect";
            this.button_disconnect.Size = new System.Drawing.Size(150, 50);
            this.button_disconnect.TabIndex = 5;
            this.button_disconnect.Text = "Disconnect";
            this.button_disconnect.UseVisualStyleBackColor = true;
            this.button_disconnect.Click += new System.EventHandler(this.button_disconnect_Click);
            // 
            // label_channel
            // 
            this.label_channel.AutoSize = true;
            this.label_channel.Location = new System.Drawing.Point(87, 537);
            this.label_channel.Name = "label_channel";
            this.label_channel.Size = new System.Drawing.Size(164, 25);
            this.label_channel.TabIndex = 6;
            this.label_channel.Text = "Select Channel:";
            // 
            // combobox_channel
            // 
            this.combobox_channel.Enabled = false;
            this.combobox_channel.FormattingEnabled = true;
            this.combobox_channel.Items.AddRange(new object[] {
            "IF100",
            "SPS101"});
            this.combobox_channel.Location = new System.Drawing.Point(293, 534);
            this.combobox_channel.Name = "combobox_channel";
            this.combobox_channel.Size = new System.Drawing.Size(182, 33);
            this.combobox_channel.TabIndex = 7;
            // 
            // button_subscribe
            // 
            this.button_subscribe.Enabled = false;
            this.button_subscribe.Location = new System.Drawing.Point(102, 599);
            this.button_subscribe.Name = "button_subscribe";
            this.button_subscribe.Size = new System.Drawing.Size(150, 50);
            this.button_subscribe.TabIndex = 8;
            this.button_subscribe.Text = "Subscribe";
            this.button_subscribe.UseVisualStyleBackColor = true;
            this.button_subscribe.Click += new System.EventHandler(this.button_subscribe_Click);
            // 
            // button_unsubscribe
            // 
            this.button_unsubscribe.Enabled = false;
            this.button_unsubscribe.Location = new System.Drawing.Point(293, 599);
            this.button_unsubscribe.Name = "button_unsubscribe";
            this.button_unsubscribe.Size = new System.Drawing.Size(150, 50);
            this.button_unsubscribe.TabIndex = 9;
            this.button_unsubscribe.Text = "Unsubscribe";
            this.button_unsubscribe.UseVisualStyleBackColor = true;
            this.button_unsubscribe.Click += new System.EventHandler(this.button_unsubscribe_Click);
            // 
            // label_message
            // 
            this.label_message.Location = new System.Drawing.Point(97, 702);
            this.label_message.Name = "label_message";
            this.label_message.Size = new System.Drawing.Size(190, 30);
            this.label_message.TabIndex = 13;
            this.label_message.Text = "Send message to";
            // 
            // textbox_message
            // 
            this.textbox_message.Enabled = false;
            this.textbox_message.Location = new System.Drawing.Point(135, 768);
            this.textbox_message.Multiline = true;
            this.textbox_message.Name = "textbox_message";
            this.textbox_message.Size = new System.Drawing.Size(284, 88);
            this.textbox_message.TabIndex = 11;
            // 
            // button_send
            // 
            this.button_send.Enabled = false;
            this.button_send.Location = new System.Drawing.Point(209, 893);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(100, 50);
            this.button_send.TabIndex = 12;
            this.button_send.Text = "Send";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 20;
            // 
            // label_if100
            // 
            this.label_if100.AutoSize = true;
            this.label_if100.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_if100.Location = new System.Drawing.Point(970, 150);
            this.label_if100.Name = "label_if100";
            this.label_if100.Size = new System.Drawing.Size(165, 25);
            this.label_if100.TabIndex = 14;
            this.label_if100.Text = "IF100 Channel";
            // 
            // label_sps101
            // 
            this.label_sps101.AutoSize = true;
            this.label_sps101.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_sps101.Location = new System.Drawing.Point(970, 583);
            this.label_sps101.Name = "label_sps101";
            this.label_sps101.Size = new System.Drawing.Size(190, 25);
            this.label_sps101.TabIndex = 16;
            this.label_sps101.Text = "SPS101 Channel";
            // 
            // if100_logs
            // 
            this.if100_logs.BackColor = System.Drawing.SystemColors.Window;
            this.if100_logs.Enabled = false;
            this.if100_logs.Location = new System.Drawing.Point(975, 181);
            this.if100_logs.Name = "if100_logs";
            this.if100_logs.ReadOnly = true;
            this.if100_logs.Size = new System.Drawing.Size(500, 350);
            this.if100_logs.TabIndex = 17;
            this.if100_logs.Text = "";
            // 
            // label_app
            // 
            this.label_app.AutoSize = true;
            this.label_app.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.875F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_app.Location = new System.Drawing.Point(600, 50);
            this.label_app.Name = "label_app";
            this.label_app.Size = new System.Drawing.Size(260, 61);
            this.label_app.TabIndex = 18;
            this.label_app.Text = "DiSUcord";
            // 
            // sps101_logs
            // 
            this.sps101_logs.BackColor = System.Drawing.SystemColors.Window;
            this.sps101_logs.Enabled = false;
            this.sps101_logs.Location = new System.Drawing.Point(975, 611);
            this.sps101_logs.Name = "sps101_logs";
            this.sps101_logs.ReadOnly = true;
            this.sps101_logs.Size = new System.Drawing.Size(500, 350);
            this.sps101_logs.TabIndex = 19;
            this.sps101_logs.Text = "";
            // 
            // label_port
            // 
            this.label_port.AutoSize = true;
            this.label_port.Location = new System.Drawing.Point(87, 242);
            this.label_port.Name = "label_port";
            this.label_port.Size = new System.Drawing.Size(57, 25);
            this.label_port.TabIndex = 21;
            this.label_port.Text = "Port:";
            // 
            // textbox_port
            // 
            this.textbox_port.Location = new System.Drawing.Point(255, 239);
            this.textbox_port.Name = "textbox_port";
            this.textbox_port.Size = new System.Drawing.Size(220, 31);
            this.textbox_port.TabIndex = 22;
            // 
            // logs
            // 
            this.logs.BackColor = System.Drawing.SystemColors.Window;
            this.logs.Location = new System.Drawing.Point(534, 184);
            this.logs.Name = "logs";
            this.logs.ReadOnly = true;
            this.logs.Size = new System.Drawing.Size(383, 777);
            this.logs.TabIndex = 23;
            this.logs.Text = "";
            // 
            // label_server
            // 
            this.label_server.AutoSize = true;
            this.label_server.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_server.Location = new System.Drawing.Point(663, 150);
            this.label_server.Name = "label_server";
            this.label_server.Size = new System.Drawing.Size(97, 25);
            this.label_server.TabIndex = 24;
            this.label_server.Text = "Actions:";
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Location = new System.Drawing.Point(87, 440);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(200, 25);
            this.label_status.TabIndex = 25;
            this.label_status.Text = "Connection Status: ";
            // 
            // pictureBox_status
            // 
            this.pictureBox_status.BackColor = System.Drawing.Color.Red;
            this.pictureBox_status.Location = new System.Drawing.Point(293, 440);
            this.pictureBox_status.Name = "pictureBox_status";
            this.pictureBox_status.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_status.TabIndex = 26;
            this.pictureBox_status.TabStop = false;
            // 
            // comboBox_message
            // 
            this.comboBox_message.Enabled = false;
            this.comboBox_message.FormattingEnabled = true;
            this.comboBox_message.Items.AddRange(new object[] {
            "IF100",
            "SPS101"});
            this.comboBox_message.Location = new System.Drawing.Point(293, 699);
            this.comboBox_message.Name = "comboBox_message";
            this.comboBox_message.Size = new System.Drawing.Size(182, 33);
            this.comboBox_message.TabIndex = 27;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1574, 1029);
            this.Controls.Add(this.comboBox_message);
            this.Controls.Add(this.pictureBox_status);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.label_server);
            this.Controls.Add(this.logs);
            this.Controls.Add(this.textbox_port);
            this.Controls.Add(this.label_port);
            this.Controls.Add(this.sps101_logs);
            this.Controls.Add(this.label_app);
            this.Controls.Add(this.if100_logs);
            this.Controls.Add(this.label_sps101);
            this.Controls.Add(this.label_if100);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_send);
            this.Controls.Add(this.textbox_message);
            this.Controls.Add(this.label_message);
            this.Controls.Add(this.button_unsubscribe);
            this.Controls.Add(this.button_subscribe);
            this.Controls.Add(this.combobox_channel);
            this.Controls.Add(this.label_channel);
            this.Controls.Add(this.button_disconnect);
            this.Controls.Add(this.button_connect);
            this.Controls.Add(this.label_username);
            this.Controls.Add(this.textbox_username);
            this.Controls.Add(this.label_ip);
            this.Controls.Add(this.textbox_ip);
            this.Name = "Form1";
            this.Text = "DiSUcord";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_status)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textbox_ip;
        private System.Windows.Forms.Label label_ip;
        private System.Windows.Forms.TextBox textbox_username;
        private System.Windows.Forms.Label label_username;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.Button button_disconnect;
        private System.Windows.Forms.Label label_channel;
        private System.Windows.Forms.ComboBox combobox_channel;
        private System.Windows.Forms.Button button_subscribe;
        private System.Windows.Forms.Button button_unsubscribe;
        private System.Windows.Forms.Label label_message;
        private System.Windows.Forms.TextBox textbox_message;
        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_if100;
        private System.Windows.Forms.Label label_sps101;
        private System.Windows.Forms.RichTextBox if100_logs;
        private System.Windows.Forms.Label label_app;
        private System.Windows.Forms.RichTextBox sps101_logs;
        private System.Windows.Forms.Label label_port;
        private System.Windows.Forms.TextBox textbox_port;
        private System.Windows.Forms.RichTextBox logs;
        private System.Windows.Forms.Label label_server;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.PictureBox pictureBox_status;
        private System.Windows.Forms.ComboBox comboBox_message;
    }
}

