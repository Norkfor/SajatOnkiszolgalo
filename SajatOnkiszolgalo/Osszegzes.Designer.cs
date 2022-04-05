namespace SajatOnkiszolgalo
{
    partial class Osszegzes
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
            this.tlpLent = new System.Windows.Forms.TableLayoutPanel();
            this.btnVissza = new Guna.UI2.WinForms.Guna2Button();
            this.btnFizetes = new Guna.UI2.WinForms.Guna2Button();
            this.blokkPrint = new System.Drawing.Printing.PrintDocument();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTetelek = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tlpLent.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpLent
            // 
            this.tlpLent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(37)))), ((int)(((byte)(47)))));
            this.tlpLent.ColumnCount = 3;
            this.tlpLent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.04636F));
            this.tlpLent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.95364F));
            this.tlpLent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.tlpLent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpLent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpLent.Controls.Add(this.btnVissza, 0, 0);
            this.tlpLent.Controls.Add(this.btnFizetes, 2, 0);
            this.tlpLent.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpLent.Location = new System.Drawing.Point(0, 608);
            this.tlpLent.Name = "tlpLent";
            this.tlpLent.RowCount = 1;
            this.tlpLent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLent.Size = new System.Drawing.Size(674, 73);
            this.tlpLent.TabIndex = 1;
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
            this.btnVissza.Location = new System.Drawing.Point(27, 13);
            this.btnVissza.Name = "btnVissza";
            this.btnVissza.ShadowDecoration.Color = System.Drawing.Color.Gray;
            this.btnVissza.ShadowDecoration.Depth = 10;
            this.btnVissza.ShadowDecoration.Parent = this.btnVissza;
            this.btnVissza.Size = new System.Drawing.Size(140, 47);
            this.btnVissza.TabIndex = 4;
            this.btnVissza.Text = "Vissza";
            this.btnVissza.Click += new System.EventHandler(this.btnVissza_Click);
            // 
            // btnFizetes
            // 
            this.btnFizetes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFizetes.Animated = true;
            this.btnFizetes.BorderRadius = 4;
            this.btnFizetes.CheckedState.Parent = this.btnFizetes;
            this.btnFizetes.CustomImages.Parent = this.btnFizetes;
            this.btnFizetes.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(106)))));
            this.btnFizetes.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.btnFizetes.ForeColor = System.Drawing.Color.Black;
            this.btnFizetes.HoverState.Parent = this.btnFizetes;
            this.btnFizetes.Location = new System.Drawing.Point(493, 13);
            this.btnFizetes.Name = "btnFizetes";
            this.btnFizetes.ShadowDecoration.Color = System.Drawing.Color.Gray;
            this.btnFizetes.ShadowDecoration.Depth = 10;
            this.btnFizetes.ShadowDecoration.Parent = this.btnFizetes;
            this.btnFizetes.Size = new System.Drawing.Size(140, 47);
            this.btnFizetes.TabIndex = 4;
            this.btnFizetes.Text = "Fizetés";
            this.btnFizetes.Click += new System.EventHandler(this.btnFizetes_Click);
            // 
            // blokkPrint
            // 
            this.blokkPrint.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.blokkPrint_PrintPage);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(37)))), ((int)(((byte)(47)))));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.04636F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lblTetelek, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(674, 62);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // lblTetelek
            // 
            this.lblTetelek.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTetelek.AutoSize = true;
            this.lblTetelek.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lblTetelek.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTetelek.Location = new System.Drawing.Point(266, 16);
            this.lblTetelek.Name = "lblTetelek";
            this.lblTetelek.Size = new System.Drawing.Size(141, 29);
            this.lblTetelek.TabIndex = 1;
            this.lblTetelek.Text = "Összegzés";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 62);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(674, 546);
            this.tableLayoutPanel2.TabIndex = 3;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // Osszegzes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 681);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tlpLent);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Osszegzes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Osszegzes";
            this.tlpLent.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpLent;
        public Guna.UI2.WinForms.Guna2Button btnVissza;
        internal Guna.UI2.WinForms.Guna2Button btnFizetes;
        private System.Drawing.Printing.PrintDocument blokkPrint;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblTetelek;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}