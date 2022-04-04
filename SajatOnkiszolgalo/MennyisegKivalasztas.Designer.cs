
namespace SajatOnkiszolgalo
{
    partial class MennyisegKivalasztas
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
            this.btnMinusz = new Guna.UI2.WinForms.Guna2Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDarab = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnMentes = new Guna.UI2.WinForms.Guna2Button();
            this.btnMegsem = new Guna.UI2.WinForms.Guna2Button();
            this.btnPlusz = new Guna.UI2.WinForms.Guna2Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMinusz
            // 
            this.btnMinusz.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMinusz.Animated = true;
            this.btnMinusz.BorderRadius = 4;
            this.btnMinusz.CheckedState.Parent = this.btnMinusz;
            this.btnMinusz.CustomImages.Parent = this.btnMinusz;
            this.btnMinusz.FillColor = System.Drawing.Color.White;
            this.btnMinusz.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.btnMinusz.ForeColor = System.Drawing.Color.Black;
            this.btnMinusz.HoverState.Parent = this.btnMinusz;
            this.btnMinusz.Location = new System.Drawing.Point(24, 20);
            this.btnMinusz.Name = "btnMinusz";
            this.btnMinusz.ShadowDecoration.Color = System.Drawing.Color.Gray;
            this.btnMinusz.ShadowDecoration.Depth = 10;
            this.btnMinusz.ShadowDecoration.Parent = this.btnMinusz;
            this.btnMinusz.Size = new System.Drawing.Size(52, 55);
            this.btnMinusz.TabIndex = 5;
            this.btnMinusz.Text = "-";
            this.btnMinusz.Click += new System.EventHandler(this.btnMinusz_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.96875F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(506, 185);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.btnPlusz, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblDarab, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnMinusz, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(500, 96);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // lblDarab
            // 
            this.lblDarab.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDarab.AutoSize = true;
            this.lblDarab.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lblDarab.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblDarab.Location = new System.Drawing.Point(228, 33);
            this.lblDarab.Name = "lblDarab";
            this.lblDarab.Size = new System.Drawing.Size(43, 29);
            this.lblDarab.TabIndex = 6;
            this.lblDarab.Text = "db";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.btnMentes, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnMegsem, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 105);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(500, 77);
            this.tableLayoutPanel3.TabIndex = 8;
            // 
            // btnMentes
            // 
            this.btnMentes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMentes.Animated = true;
            this.btnMentes.BorderRadius = 4;
            this.btnMentes.CheckedState.Parent = this.btnMentes;
            this.btnMentes.CustomImages.Parent = this.btnMentes;
            this.btnMentes.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(106)))));
            this.btnMentes.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.btnMentes.ForeColor = System.Drawing.Color.Black;
            this.btnMentes.HoverState.Parent = this.btnMentes;
            this.btnMentes.Location = new System.Drawing.Point(305, 15);
            this.btnMentes.Name = "btnMentes";
            this.btnMentes.ShadowDecoration.Color = System.Drawing.Color.Gray;
            this.btnMentes.ShadowDecoration.Depth = 10;
            this.btnMentes.ShadowDecoration.Parent = this.btnMentes;
            this.btnMentes.Size = new System.Drawing.Size(140, 47);
            this.btnMentes.TabIndex = 5;
            this.btnMentes.Text = "Mentés";
            this.btnMentes.Click += new System.EventHandler(this.btnMentes_Click);
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
            this.btnMegsem.Location = new System.Drawing.Point(55, 15);
            this.btnMegsem.Name = "btnMegsem";
            this.btnMegsem.ShadowDecoration.Color = System.Drawing.Color.Gray;
            this.btnMegsem.ShadowDecoration.Depth = 10;
            this.btnMegsem.ShadowDecoration.Parent = this.btnMegsem;
            this.btnMegsem.Size = new System.Drawing.Size(140, 47);
            this.btnMegsem.TabIndex = 5;
            this.btnMegsem.Text = "Mégsem";
            this.btnMegsem.Click += new System.EventHandler(this.btnMegsem_Click);
            // 
            // btnPlusz
            // 
            this.btnPlusz.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPlusz.Animated = true;
            this.btnPlusz.BorderRadius = 4;
            this.btnPlusz.CheckedState.Parent = this.btnPlusz;
            this.btnPlusz.CustomImages.Parent = this.btnPlusz;
            this.btnPlusz.FillColor = System.Drawing.Color.White;
            this.btnPlusz.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.btnPlusz.ForeColor = System.Drawing.Color.Black;
            this.btnPlusz.HoverState.Parent = this.btnPlusz;
            this.btnPlusz.Location = new System.Drawing.Point(422, 20);
            this.btnPlusz.Name = "btnPlusz";
            this.btnPlusz.ShadowDecoration.Color = System.Drawing.Color.Gray;
            this.btnPlusz.ShadowDecoration.Depth = 10;
            this.btnPlusz.ShadowDecoration.Parent = this.btnPlusz;
            this.btnPlusz.Size = new System.Drawing.Size(55, 55);
            this.btnPlusz.TabIndex = 5;
            this.btnPlusz.Text = "+";
            this.btnPlusz.Click += new System.EventHandler(this.btnPlusz_Click);
            // 
            // MennyisegKivalasztas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(37)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(506, 185);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MennyisegKivalasztas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MennyisegKivalasztas";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        internal Guna.UI2.WinForms.Guna2Button btnMinusz;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblDarab;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        internal Guna.UI2.WinForms.Guna2Button btnMentes;
        internal Guna.UI2.WinForms.Guna2Button btnMegsem;
        internal Guna.UI2.WinForms.Guna2Button btnPlusz;
    }
}