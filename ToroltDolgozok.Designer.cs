namespace iktato
{
    partial class ToroltDolgozok
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
            this.dolgozoTorlesVisszavonasaButton = new System.Windows.Forms.Button();
            this.toroltDolgozokDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.toroltDolgozokDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dolgozoTorlesVisszavonasaButton
            // 
            this.dolgozoTorlesVisszavonasaButton.BackColor = System.Drawing.Color.DarkBlue;
            this.dolgozoTorlesVisszavonasaButton.FlatAppearance.BorderSize = 0;
            this.dolgozoTorlesVisszavonasaButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.dolgozoTorlesVisszavonasaButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dolgozoTorlesVisszavonasaButton.ForeColor = System.Drawing.Color.LightCyan;
            this.dolgozoTorlesVisszavonasaButton.Location = new System.Drawing.Point(333, 415);
            this.dolgozoTorlesVisszavonasaButton.Name = "dolgozoTorlesVisszavonasaButton";
            this.dolgozoTorlesVisszavonasaButton.Size = new System.Drawing.Size(133, 23);
            this.dolgozoTorlesVisszavonasaButton.TabIndex = 0;
            this.dolgozoTorlesVisszavonasaButton.Text = "Törlés visszavonása";
            this.dolgozoTorlesVisszavonasaButton.UseVisualStyleBackColor = false;
            this.dolgozoTorlesVisszavonasaButton.Click += new System.EventHandler(this.dolgozoTorlesVisszavonasaButton_Click);
            // 
            // toroltDolgozokDataGridView
            // 
            this.toroltDolgozokDataGridView.AllowUserToAddRows = false;
            this.toroltDolgozokDataGridView.AllowUserToDeleteRows = false;
            this.toroltDolgozokDataGridView.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toroltDolgozokDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.toroltDolgozokDataGridView.Location = new System.Drawing.Point(31, 22);
            this.toroltDolgozokDataGridView.Name = "toroltDolgozokDataGridView";
            this.toroltDolgozokDataGridView.ReadOnly = true;
            this.toroltDolgozokDataGridView.Size = new System.Drawing.Size(739, 366);
            this.toroltDolgozokDataGridView.TabIndex = 1;
            this.toroltDolgozokDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.toroltDolgozokDataGridView_CellClick);
            // 
            // ToroltDolgozok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toroltDolgozokDataGridView);
            this.Controls.Add(this.dolgozoTorlesVisszavonasaButton);
            this.Name = "ToroltDolgozok";
            this.Text = "Törölt Dolgozók";
            this.Load += new System.EventHandler(this.ToroltDolgozok_Load);
            ((System.ComponentModel.ISupportInitialize)(this.toroltDolgozokDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button dolgozoTorlesVisszavonasaButton;
        private System.Windows.Forms.DataGridView toroltDolgozokDataGridView;
    }
}