namespace SajatOnkiszolgalo
{
    partial class NincsTermek
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblNincs = new System.Windows.Forms.Label();
            this.btnMegsem = new Guna.UI2.WinForms.Guna2Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblNincs, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnMegsem, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(550, 200);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblNincs
            // 
            this.lblNincs.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNincs.AutoSize = true;
            this.lblNincs.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lblNincs.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblNincs.Location = new System.Drawing.Point(26, 23);
            this.lblNincs.Name = "lblNincs";
            this.lblNincs.Size = new System.Drawing.Size(497, 87);
            this.lblNincs.TabIndex = 8;
            this.lblNincs.Text = "Jelenleg nincs hozzáadott termék az önkiszolgálóban. Kérem, olvasson be egy termé" +
    "ket az árucikk módosításához.";
            this.lblNincs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMegsem
            // 
            this.btnMegsem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMegsem.Animated = true;
            this.btnMegsem.BorderRadius = 4;
            this.btnMegsem.CheckedState.Parent = this.btnMegsem;
            this.btnMegsem.CustomImages.Parent = this.btnMegsem;
            this.btnMegsem.FillColor = System.Drawing.Color.Firebrick;
            this.btnMegsem.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.btnMegsem.ForeColor = System.Drawing.Color.Black;
            this.btnMegsem.HoverState.Parent = this.btnMegsem;
            this.btnMegsem.Location = new System.Drawing.Point(205, 143);
            this.btnMegsem.Name = "btnMegsem";
            this.btnMegsem.ShadowDecoration.Color = System.Drawing.Color.Gray;
            this.btnMegsem.ShadowDecoration.Depth = 10;
            this.btnMegsem.ShadowDecoration.Parent = this.btnMegsem;
            this.btnMegsem.Size = new System.Drawing.Size(140, 47);
            this.btnMegsem.TabIndex = 7;
            this.btnMegsem.Text = "Bezárás";
            this.btnMegsem.Click += new System.EventHandler(this.btnMegsem_Click);
            // 
            // NincsTermek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(37)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(550, 200);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "NincsTermek";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NincsTermek";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        internal Guna.UI2.WinForms.Guna2Button btnMegsem;
        private System.Windows.Forms.Label lblNincs;
    }
}