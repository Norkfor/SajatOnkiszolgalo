using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SajatOnkiszolgalo
{
    public partial class Termekek : Form
    {
        DB adatbazis;
        public Termekek(DB adatbazis)
        {
            InitializeComponent();
            this.adatbazis = adatbazis;

            TableLayoutPanel panel = new TableLayoutPanel();
            panel.ColumnCount = 3;
            panel.RowCount = 1;
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 150F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 150F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 150F));

            // For Add New Row (Loop this code for add multiple rows)
            //try
            //{
            //    adatbazis.Conn.Open();
            //    string sqlJelenlegi = $"SELECT a.nev, a.mennyiseg, am.mertekegyseg, v.id FROM vasarlok as v INNER JOIN arucikkek as a ON v.arucikkekID = a.aruid INNER JOIN aru_mertekegyseg AS am ON a.mertekegyseg_id = am.id INNER JOIN pultok as p ON v.pultokID = p.id WHERE a.nev LIKE '%{kivalasztottNev}%' AND p.vonalkod_szam = '{randomSzam}';";
            //    var parancsJelenlegi = new MySqlCommand(sqlJelenlegi, adatbazis.Conn);
            //    var olvasoJelenlegi = parancsJelenlegi.ExecuteReader();
            //    if (olvasoJelenlegi.HasRows)
            //    {
            //        olvasoJelenlegi.Read();
            //        string jelenlegiNev = olvasoJelenlegi.GetString(0);
            //        double jelenlegiMennyiseg = olvasoJelenlegi.GetDouble(1);
            //        string jelenlegiMertekegyseg = olvasoJelenlegi.GetString(2);
            //        vasarloID = olvasoJelenlegi.GetInt32(3);
            //        lblTermek.Text = $"{jelenlegiNev} {jelenlegiMennyiseg}{jelenlegiMertekegyseg}";
            //        pbTermek.Image = Image.FromFile($@"C:\Users\nyb15KOZÁKL\Desktop\SajatOnkiszolgalo\SajatOnkiszolgalo\kepek\{jelenlegiNev}.jpg");
            //        adatbazis.Conn.Close();
            //    }
            //    adatbazis.Conn.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //finally
            //{
            //    adatbazis.Conn.Close();
            //}


            panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 150F));
            panel.Controls.Add(new Bunifu.Framework.UI.BunifuTileButton() { BackColor = Color.FromArgb(26, 37, 47), color = Color.FromArgb(26, 37, 47), colorActive = Color.FromArgb(55, 81, 108), Cursor = Cursors.Hand, Font = new Font("Century Gothic", 15.75F), ForeColor = Color.White, Image = Properties.Resources.angol, ImagePosition = 20, ImageZoom = 50, LabelPosition = 41, LabelText = "kenyér", Size = new Size(150, 150) }, 0, panel.RowCount - 1);
            panel.Controls.Add(new Bunifu.Framework.UI.BunifuTileButton() { BackColor = Color.FromArgb(26, 37, 47), color = Color.FromArgb(26, 37, 47), colorActive = Color.FromArgb(55, 81, 108), Cursor = Cursors.Hand, Font = new Font("Century Gothic", 15.75F), ForeColor = Color.White, Image = Properties.Resources.angol, ImagePosition = 20, ImageZoom = 50, LabelPosition = 41, LabelText = "kenyér", Size = new Size(150, 150) }, 1, panel.RowCount - 1);


            this.Controls.Add(panel);
            panel.Dock = DockStyle.Fill;

        }
    }
}
