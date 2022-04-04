using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using MySql.Data.MySqlClient;

namespace SajatOnkiszolgalo
{
    public partial class Termekek : Form
    {
        DB adatbazis;

        static string nev = "";
        public Termekek(DB adatbazis)
        {
            InitializeComponent();
            this.adatbazis = adatbazis;
            string eleresiUtvonal = Path.GetDirectoryName(Application.ExecutablePath);
            TableLayoutPanel panel = new TableLayoutPanel() { Dock = DockStyle.Fill };
            panel.ColumnCount = 3;
            panel.RowCount = 1;
            
            

            try
            {
                adatbazis.Conn.Open();
                string sqlJelenlegi = $"SELECT nev FROM arucikkek WHERE gyumolcszoldseg = 1;";
                var parancsJelenlegi = new MySqlCommand(sqlJelenlegi, adatbazis.Conn);
                var olvasoJelenlegi = parancsJelenlegi.ExecuteReader();
                int index = 0;
                if (olvasoJelenlegi.HasRows)
                {
                    while (olvasoJelenlegi.Read())
                    {
                        panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
                        int i = 0;
                        int j = 0;
                        if (j == 3)
                        {
                            i++;
                            j = 0;
                            panel.RowStyles.Add(new ColumnStyle(SizeType.Percent, 50));
                        }
                        nev = olvasoJelenlegi.GetString(0);
                        BunifuTileButton gomb = new BunifuTileButton() { BackColor = Color.FromArgb(26, 37, 47), color = Color.FromArgb(26, 37, 47), colorActive = Color.FromArgb(55, 81, 108), Cursor = Cursors.Hand, Font = new Font("Century Gothic", 15.75F), ForeColor = Color.White, Image = Image.FromFile(Path.Combine(eleresiUtvonal, $@"kepek\{nev}.jpg")), ImagePosition = 20, ImageZoom = 50, LabelPosition = 41, LabelText = nev, Size = new Size(150, 150), Anchor = AnchorStyles.None };

                        panel.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
                        panel.Controls.Add(gomb, j, i);
                        gomb.Click += new EventHandler(click);

                        index++;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                adatbazis.Conn.Close();
            }
            
            
            


            this.Controls.Add(panel);
            panel.Dock = DockStyle.Fill;

        }

        private void click(object sender, EventArgs e)
        {
            
            MessageBox.Show($"{(sender as BunifuTileButton).LabelText}");
        }

        private void Termekek_Load(object sender, EventArgs e)
        {

        }
    }
}
