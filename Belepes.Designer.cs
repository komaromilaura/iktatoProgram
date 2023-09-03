namespace iktato
{
    partial class Belepes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Belepes));
            this.felhasznalonevLabel = new System.Windows.Forms.Label();
            this.jelszoLabel = new System.Windows.Forms.Label();
            this.felhasznalonevTextBox = new System.Windows.Forms.TextBox();
            this.jelszoTextBox = new System.Windows.Forms.TextBox();
            this.belepButton = new System.Windows.Forms.Button();
            this.megseButton = new System.Windows.Forms.Button();
            this.hibaLabel = new System.Windows.Forms.Label();
            this.belepesPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.belepesPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // felhasznalonevLabel
            // 
            this.felhasznalonevLabel.AutoSize = true;
            this.felhasznalonevLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.felhasznalonevLabel.Location = new System.Drawing.Point(28, 64);
            this.felhasznalonevLabel.Name = "felhasznalonevLabel";
            this.felhasznalonevLabel.Size = new System.Drawing.Size(95, 13);
            this.felhasznalonevLabel.TabIndex = 0;
            this.felhasznalonevLabel.Text = "Felhasználónév";
            // 
            // jelszoLabel
            // 
            this.jelszoLabel.AutoSize = true;
            this.jelszoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.jelszoLabel.Location = new System.Drawing.Point(28, 131);
            this.jelszoLabel.Name = "jelszoLabel";
            this.jelszoLabel.Size = new System.Drawing.Size(42, 13);
            this.jelszoLabel.TabIndex = 1;
            this.jelszoLabel.Text = "Jelszó";
            // 
            // felhasznalonevTextBox
            // 
            this.felhasznalonevTextBox.Location = new System.Drawing.Point(129, 61);
            this.felhasznalonevTextBox.Name = "felhasznalonevTextBox";
            this.felhasznalonevTextBox.Size = new System.Drawing.Size(176, 20);
            this.felhasznalonevTextBox.TabIndex = 2;
            this.felhasznalonevTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.felhasznalonevTextBox_KeyPress);
            // 
            // jelszoTextBox
            // 
            this.jelszoTextBox.Location = new System.Drawing.Point(129, 128);
            this.jelszoTextBox.Name = "jelszoTextBox";
            this.jelszoTextBox.Size = new System.Drawing.Size(176, 20);
            this.jelszoTextBox.TabIndex = 3;
            this.jelszoTextBox.Enter += new System.EventHandler(this.jelszoTextBox_Enter);
            this.jelszoTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.jelszoTextBox_KeyPress);
            // 
            // belepButton
            // 
            this.belepButton.BackColor = System.Drawing.Color.DarkBlue;
            this.belepButton.FlatAppearance.BorderSize = 0;
            this.belepButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.belepButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.belepButton.ForeColor = System.Drawing.Color.LightCyan;
            this.belepButton.Location = new System.Drawing.Point(31, 246);
            this.belepButton.Name = "belepButton";
            this.belepButton.Size = new System.Drawing.Size(75, 23);
            this.belepButton.TabIndex = 4;
            this.belepButton.Text = "Belépés";
            this.belepButton.UseVisualStyleBackColor = false;
            this.belepButton.Click += new System.EventHandler(this.belepButton_Click);
            // 
            // megseButton
            // 
            this.megseButton.BackColor = System.Drawing.Color.DarkBlue;
            this.megseButton.FlatAppearance.BorderSize = 0;
            this.megseButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.megseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.megseButton.ForeColor = System.Drawing.Color.LightCyan;
            this.megseButton.Location = new System.Drawing.Point(230, 246);
            this.megseButton.Name = "megseButton";
            this.megseButton.Size = new System.Drawing.Size(75, 23);
            this.megseButton.TabIndex = 5;
            this.megseButton.Text = "Mégse";
            this.megseButton.UseVisualStyleBackColor = false;
            this.megseButton.Click += new System.EventHandler(this.megseButton_Click);
            // 
            // hibaLabel
            // 
            this.hibaLabel.AutoSize = true;
            this.hibaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.hibaLabel.ForeColor = System.Drawing.Color.Red;
            this.hibaLabel.Location = new System.Drawing.Point(28, 189);
            this.hibaLabel.Name = "hibaLabel";
            this.hibaLabel.Size = new System.Drawing.Size(0, 13);
            this.hibaLabel.TabIndex = 6;
            // 
            // belepesPictureBox
            // 
            this.belepesPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("belepesPictureBox.Image")));
            this.belepesPictureBox.Location = new System.Drawing.Point(342, 2);
            this.belepesPictureBox.Name = "belepesPictureBox";
            this.belepesPictureBox.Size = new System.Drawing.Size(292, 318);
            this.belepesPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.belepesPictureBox.TabIndex = 8;
            this.belepesPictureBox.TabStop = false;
            // 
            // Belepes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(633, 315);
            this.Controls.Add(this.belepesPictureBox);
            this.Controls.Add(this.hibaLabel);
            this.Controls.Add(this.megseButton);
            this.Controls.Add(this.belepButton);
            this.Controls.Add(this.jelszoTextBox);
            this.Controls.Add(this.felhasznalonevTextBox);
            this.Controls.Add(this.jelszoLabel);
            this.Controls.Add(this.felhasznalonevLabel);
            this.Name = "Belepes";
            this.Text = "Belépés";
            ((System.ComponentModel.ISupportInitialize)(this.belepesPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label felhasznalonevLabel;
        private System.Windows.Forms.Label jelszoLabel;
        private System.Windows.Forms.TextBox felhasznalonevTextBox;
        private System.Windows.Forms.TextBox jelszoTextBox;
        private System.Windows.Forms.Button belepButton;
        private System.Windows.Forms.Button megseButton;
        private System.Windows.Forms.Label hibaLabel;
        private System.Windows.Forms.PictureBox belepesPictureBox;
    }
}

