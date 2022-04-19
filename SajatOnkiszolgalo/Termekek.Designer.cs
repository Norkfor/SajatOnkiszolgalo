namespace SajatOnkiszolgalo
{
    partial class Termekek
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
            this.tlp = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnVissza = new Guna.UI2.WinForms.Guna2Button();
            this.tlp.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp
            // 
            this.tlp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tlp.ColumnCount = 1;
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp.Location = new System.Drawing.Point(0, 0);
            this.tlp.Name = "tlp";
            this.tlp.RowCount = 2;
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.625F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.375F));
            this.tlp.Size = new System.Drawing.Size(1024, 768);
            this.tlp.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(37)))), ((int)(((byte)(47)))));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnVissza, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 699);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1018, 66);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnVissza
            // 
            this.btnVissza.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnVissza.Animated = true;
            this.btnVissza.BorderRadius = 4;
            this.btnVissza.CheckedState.Parent = this.btnVissza;
            this.btnVissza.CustomImages.Parent = this.btnVissza;
            this.btnVissza.FillColor = System.Drawing.Color.Firebrick;
            this.btnVissza.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.btnVissza.ForeColor = System.Drawing.Color.Black;
            this.btnVissza.HoverState.Parent = this.btnVissza;
            this.btnVissza.Location = new System.Drawing.Point(439, 9);
            this.btnVissza.Name = "btnVissza";
            this.btnVissza.ShadowDecoration.Color = System.Drawing.Color.Gray;
            this.btnVissza.ShadowDecoration.Depth = 10;
            this.btnVissza.ShadowDecoration.Parent = this.btnVissza;
            this.btnVissza.Size = new System.Drawing.Size(140, 47);
            this.btnVissza.TabIndex = 5;
            this.btnVissza.Text = "Vissza";
            this.btnVissza.Click += new System.EventHandler(this.btnVissza_Click);
            // 
            // Termekek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.tlp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Termekek";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Termekek";
            this.tlp.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public Guna.UI2.WinForms.Guna2Button btnVissza;
    }
}