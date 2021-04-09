namespace ProjectChatApp.ClientSide
{
    partial class Chat
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
            this.send = new System.Windows.Forms.Button();
            this.input = new System.Windows.Forms.TextBox();
            this.chatBox = new System.Windows.Forms.RichTextBox();
            this.leave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // send
            // 
            this.send.Location = new System.Drawing.Point(660, 395);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(128, 43);
            this.send.TabIndex = 0;
            this.send.Text = "Send";
            this.send.UseVisualStyleBackColor = true;
            this.send.Click += new System.EventHandler(this.send_Click);
            // 
            // input
            // 
            this.input.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.input.Location = new System.Drawing.Point(12, 396);
            this.input.Multiline = true;
            this.input.Name = "input";
            this.input.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.input.Size = new System.Drawing.Size(638, 41);
            this.input.TabIndex = 1;
            // 
            // chatBox
            // 
            this.chatBox.Location = new System.Drawing.Point(10, 42);
            this.chatBox.Multiline = true;
            this.chatBox.Name = "chatBox";
            this.chatBox.ScrollBars = (System.Windows.Forms.RichTextBoxScrollBars)System.Windows.Forms.ScrollBars.Vertical;
            this.chatBox.Size = new System.Drawing.Size(776, 350);
            this.chatBox.TabIndex = 2;
            // 
            // leave
            // 
            this.leave.Location = new System.Drawing.Point(684, 5);
            this.leave.Name = "leave";
            this.leave.Size = new System.Drawing.Size(103, 30);
            this.leave.TabIndex = 1;
            this.leave.Text = "Leave";
            this.leave.UseVisualStyleBackColor = true;
            this.leave.Click += new System.EventHandler(this.leaveChat_Click);
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chatBox);
            this.Controls.Add(this.input);
            this.Controls.Add(this.send);
            this.Controls.Add(this.leave);
            this.Name = this.name;
            this.Text = this.name;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button send;
        private System.Windows.Forms.TextBox input;
        private System.Windows.Forms.RichTextBox chatBox;
        private System.Windows.Forms.Button leave;
    }
}