namespace iktato
{
    partial class ToroltPartnerek
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
            this.toroltPartnerekDataGridView = new System.Windows.Forms.DataGridView();
            this.TorlesVisszavonasButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.toroltPartnerekDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // toroltPartnerekDataGridView
            // 
            this.toroltPartnerekDataGridView.AllowUserToAddRows = false;
            this.toroltPartnerekDataGridView.AllowUserToDeleteRows = false;
            this.toroltPartnerekDataGridView.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toroltPartnerekDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.toroltPartnerekDataGridView.Location = new System.Drawing.Point(30, 20);
            this.toroltPartnerekDataGridView.Name = "toroltPartnerekDataGridView";
            this.toroltPartnerekDataGridView.ReadOnly = true;
            this.toroltPartnerekDataGridView.Size = new System.Drawing.Size(738, 370);
            this.toroltPartnerekDataGridView.TabIndex = 0;
            this.toroltPartnerekDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.toroltPartnerekDataGridView_CellClick);
            // 
            // TorlesVisszavonasButton
            // 
            this.TorlesVisszavonasButton.BackColor = System.Drawing.Color.DarkBlue;
            this.TorlesVisszavonasButton.FlatAppearance.BorderSize = 0;
            this.TorlesVisszavonasButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.TorlesVisszavonasButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TorlesVisszavonasButton.ForeColor = System.Drawing.Color.LightCyan;
            this.TorlesVisszavonasButton.Location = new System.Drawing.Point(335, 415);
            this.TorlesVisszavonasButton.Name = "TorlesVisszavonasButton";
            this.TorlesVisszavonasButton.Size = new System.Drawing.Size(130, 23);
            this.TorlesVisszavonasButton.TabIndex = 1;
            this.TorlesVisszavonasButton.Text = "Törés visszavonása";
            this.TorlesVisszavonasButton.UseVisualStyleBackColor = false;
            this.TorlesVisszavonasButton.Click += new System.EventHandler(this.TorlesVisszavonasButton_Click);
            // 
            // ToroltPartnerek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TorlesVisszavonasButton);
            this.Controls.Add(this.toroltPartnerekDataGridView);
            this.Name = "ToroltPartnerek";
            this.Text = "Törölt partnerek";
            this.Load += new System.EventHandler(this.ToroltPartnerek_Load);
            ((System.ComponentModel.ISupportInitialize)(this.toroltPartnerekDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView toroltPartnerekDataGridView;
        private System.Windows.Forms.Button TorlesVisszavonasButton;
    }
}