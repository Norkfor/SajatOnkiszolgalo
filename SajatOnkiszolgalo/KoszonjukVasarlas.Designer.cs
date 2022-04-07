namespace SajatOnkiszolgalo
{
    partial class KoszonjukVasarlas
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblKoszonjuk = new System.Windows.Forms.Label();
            this.trVisszaSzamol = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(37)))), ((int)(((byte)(47)))));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblKoszonjuk, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 271F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(565, 271);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lblKoszonjuk
            // 
            this.lblKoszonjuk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblKoszonjuk.AutoSize = true;
            this.lblKoszonjuk.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lblKoszonjuk.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblKoszonjuk.Location = new System.Drawing.Point(140, 121);
            this.lblKoszonjuk.Name = "lblKoszonjuk";
            this.lblKoszonjuk.Size = new System.Drawing.Size(285, 29);
            this.lblKoszonjuk.TabIndex = 8;
            this.lblKoszonjuk.Text = "Köszönjük a vásárlását!";
            this.lblKoszonjuk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trVisszaSzamol
            // 
            this.trVisszaSzamol.Enabled = true;
            this.trVisszaSzamol.Interval = 1000;
            this.trVisszaSzamol.Tick += new System.EventHandler(this.trVisszaSzamol_Tick);
            // 
            // KoszonjukVasarlas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 271);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "KoszonjukVasarlas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KoszonjukVasarlas";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblKoszonjuk;
        private System.Windows.Forms.Timer trVisszaSzamol;
    }
}