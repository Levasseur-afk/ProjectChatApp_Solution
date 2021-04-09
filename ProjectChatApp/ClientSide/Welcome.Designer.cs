namespace ProjectChatApp.ClientSide
{
    partial class Welcome
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.welcome1 = new System.Windows.Forms.Label();
            this.inputLogin = new System.Windows.Forms.TextBox();
            this.buttonLogIn = new System.Windows.Forms.Button();
            this.labelLogin = new System.Windows.Forms.Label();
            this.Console1 = new System.Windows.Forms.TextBox();
            this.inputPassword = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // welcome1
            // 
            this.welcome1.AutoSize = true;
            this.welcome1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.welcome1.Location = new System.Drawing.Point(330, 36);
            this.welcome1.Name = "welcome1";
            this.welcome1.Size = new System.Drawing.Size(120, 29);
            this.welcome1.TabIndex = 0;
            this.welcome1.Text = "Welcome";
            this.welcome1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // inputLogin
            // 
            this.inputLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.inputLogin.Location = new System.Drawing.Point(318, 133);
            this.inputLogin.Name = "inputLogin";
            this.inputLogin.Size = new System.Drawing.Size(146, 26);
            this.inputLogin.TabIndex = 1;
            // 
            // buttonLogIn
            // 
            this.buttonLogIn.Location = new System.Drawing.Point(402, 230);
            this.buttonLogIn.Name = "buttonLogIn";
            this.buttonLogIn.Size = new System.Drawing.Size(75, 39);
            this.buttonLogIn.TabIndex = 2;
            this.buttonLogIn.Text = "Log in";
            this.buttonLogIn.UseVisualStyleBackColor = true;
            this.buttonLogIn.Click += new System.EventHandler(this.buttonLogIn_Click);
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(372, 112);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(43, 17);
            this.labelLogin.TabIndex = 3;
            this.labelLogin.Text = "Login";
            // 
            // Console1
            // 
            this.Console1.Location = new System.Drawing.Point(246, 296);
            this.Console1.Multiline = true;
            this.Console1.Name = "Console1";
            this.Console1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Console1.Size = new System.Drawing.Size(300, 129);
            this.Console1.TabIndex = 4;
            // 
            // inputPassword
            // 
            this.inputPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.inputPassword.Location = new System.Drawing.Point(318, 191);
            this.inputPassword.Name = "inputPassword";
            this.inputPassword.Size = new System.Drawing.Size(146, 26);
            this.inputPassword.TabIndex = 5;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(357, 173);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(69, 17);
            this.labelPassword.TabIndex = 6;
            this.labelPassword.Text = "Password";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(312, 230);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 39);
            this.button1.TabIndex = 8;
            this.button1.Text = "Sign in";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Console1);
            this.Controls.Add(this.buttonLogIn);
            this.Controls.Add(this.inputPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.inputLogin);
            this.Controls.Add(this.welcome1);
            this.Name = "Welcome";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label welcome1;
        private System.Windows.Forms.TextBox inputLogin;
        private System.Windows.Forms.Button buttonLogIn;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.TextBox Console1;
        private System.Windows.Forms.TextBox inputPassword;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Button button1;
    }
}