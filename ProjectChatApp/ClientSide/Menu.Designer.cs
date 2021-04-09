namespace ProjectChatApp
{
    partial class Menu
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
            this.newTopic = new System.Windows.Forms.Button();
            this.joinTopic = new System.Windows.Forms.Button();
            this.privateConv = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // newTopic
            // 
            this.newTopic.Location = new System.Drawing.Point(93, 167);
            this.newTopic.Name = "newTopic";
            this.newTopic.Size = new System.Drawing.Size(118, 115);
            this.newTopic.TabIndex = 0;
            this.newTopic.Text = "New Topic";
            this.newTopic.UseVisualStyleBackColor = true;
            this.newTopic.Click += new System.EventHandler(this.newTopic_Click);
            // 
            // joinTopic
            // 
            this.joinTopic.Location = new System.Drawing.Point(341, 168);
            this.joinTopic.Name = "joinTopic";
            this.joinTopic.Size = new System.Drawing.Size(118, 115);
            this.joinTopic.TabIndex = 1;
            this.joinTopic.Text = "Join Topic";
            this.joinTopic.UseVisualStyleBackColor = true;
            this.joinTopic.Click += new System.EventHandler(this.joinTopic_Click);
            // 
            // privateConv
            // 
            this.privateConv.Location = new System.Drawing.Point(583, 167);
            this.privateConv.Name = "privateConv";
            this.privateConv.Size = new System.Drawing.Size(118, 115);
            this.privateConv.TabIndex = 2;
            this.privateConv.Text = "Private Talk";
            this.privateConv.UseVisualStyleBackColor = true;
            this.privateConv.Click += new System.EventHandler(this.privateConv_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(674, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 48);
            this.button1.TabIndex = 3;
            this.button1.Text = "Disconnect";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.privateConv);
            this.Controls.Add(this.joinTopic);
            this.Controls.Add(this.newTopic);
            this.Name = "Menu";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button newTopic;
        private System.Windows.Forms.Button joinTopic;
        private System.Windows.Forms.Button privateConv;
        private System.Windows.Forms.Button button1;
    }
}