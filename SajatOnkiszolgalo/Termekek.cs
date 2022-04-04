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
        Onkiszolgalo onkisziolgaloForm;

        static string nev = "";
        static long vonalkodSzam = 0;
        public Termekek(DB adatbazis, Onkiszolgalo onkisziolgaloForm)
        {
            InitializeComponent();
            this.adatbazis = adatbazis;
            this.onkisziolgaloForm = onkisziolgaloForm;
            string eleresiUtvonal = Path.GetDirectoryName(Application.ExecutablePath);
            TableLayoutPanel panel = new TableLayoutPanel() { Dock = DockStyle.Fill };
            panel.ColumnCount = 3;
            panel.RowCount = 1;
            
            

            try
            {
                adatbazis.Conn.Open();
                string sqlJelenlegi = $"SELECT nev, vonalkod_szam FROM arucikkek WHERE gyumolcszoldseg = 1;";
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
                        vonalkodSzam = olvasoJelenlegi.GetInt64(1);
                        BunifuTileButton gomb = new BunifuTileButton() { BackColor = Color.FromArgb(26, 37, 47), color = Color.FromArgb(26, 37, 47), colorActive = Color.FromArgb(55, 81, 108), Cursor = Cursors.Hand, Font = new Font("Century Gothic", 15.75F), ForeColor = Color.White, Image = Image.FromFile(Path.Combine(eleresiUtvonal, $@"kepek\{nev}.jpg")), ImagePosition = 20, ImageZoom = 50, LabelPosition = 41, LabelText = nev, Size = new Size(150, 150), Anchor = AnchorStyles.None, Name = Convert.ToString(vonalkodSzam)};

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

            int arucikkekID = 0;
            int pultokID = 0;
            try
            {
                adatbazis.Conn.Open();
                MySqlCommand parancs = new MySqlCommand($"SELECT id FROM pultok WHERE vonalkod_szam = {onkisziolgaloForm.randomSzam};", adatbazis.Conn);

                MySqlDataReader olvaso = parancs.ExecuteReader();
                if (olvaso.HasRows)
                {
                    olvaso.Read();
                    pultokID = olvaso.GetInt32(0);
                    adatbazis.Conn.Close();
                }
                adatbazis.Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                adatbazis.Conn.Close();
            }
            try
            {

                adatbazis.Conn.Open();
                MySqlCommand parancs1 = new MySqlCommand($"SELECT aruid FROM arucikkek WHERE vonalkod_szam = {Convert.ToInt64((sender as BunifuTileButton).Name)};", adatbazis.Conn);
                MySqlDataReader olvaso1 = parancs1.ExecuteReader();
                if (olvaso1.HasRows)
                {
                    olvaso1.Read();
                    arucikkekID = olvaso1.GetInt32(0);
                    adatbazis.Conn.Close();
                    adatbazis.Conn.Open();
                    MySqlCommand parancs2 = new MySqlCommand($"SELECT id, termekDarab FROM vasarlok WHERE arucikkekID = '{arucikkekID}' AND pultokID = '{pultokID}';", adatbazis.Conn);
                    MySqlDataReader olvaso2 = parancs2.ExecuteReader();
                    if (olvaso2.HasRows)
                    {
                        olvaso2.Read();
                        int id = olvaso2.GetInt32(0);
                        int darab = olvaso2.GetInt32(1) + 1;
                        adatbazis.Conn.Close();
                        adatbazis.Conn.Open();
                        MySqlCommand parancs3 = new MySqlCommand($"UPDATE `vasarlok` SET `pultokID` = '{pultokID}', `arucikkekID` = '{arucikkekID}', `termekDarab` = '{darab}', `aktiv` = '1' WHERE `vasarlok`.`id` = '{id}';", adatbazis.Conn);
                        parancs3.ExecuteNonQuery();
                        adatbazis.Conn.Close();
                        onkisziolgaloForm.ListboxDeklaralas();
                        onkisziolgaloForm.JelenlegiTermekBeallitas();
                        Close();
                    }
                    else
                    {
                        adatbazis.Conn.Close();
                        adatbazis.Conn.Open();
                        MySqlCommand parancs4 = new MySqlCommand($"INSERT INTO `vasarlok` (`id`, `pultokID`, `arucikkekID`, `termekDarab`, `aktiv`) VALUES (NULL, '{pultokID}', '{arucikkekID}', '1', '1');", adatbazis.Conn);
                        parancs4.ExecuteNonQuery();
                        adatbazis.Conn.Close();
                        onkisziolgaloForm.ListboxDeklaralas();
                        onkisziolgaloForm.JelenlegiTermekBeallitas();
                        Close();
                    }
                    adatbazis.Conn.Close();
                }
                else
                {
                    MessageBox.Show($"Az adatbázisban nem szerepel ez az árucikk!", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }

        private void Termekek_Load(object sender, EventArgs e)
        {

        }
    }
}
