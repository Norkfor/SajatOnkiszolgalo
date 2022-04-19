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
            tlp.Controls.Add(panel, 0, 0);
            panel.ColumnCount = 3;
            panel.RowCount = 1;
            
            try
            {
                adatbazis.Conn.Open();
                string sqlJelenlegi = $"SELECT a.nev, a.vonalkod_szam, a.gyumolcszoldseg, a.mennyiseg, am.mertekegyseg, a.kep FROM arucikkek as a JOIN aru_mertekegyseg AS am ON a.mertekegyseg_id = am.id WHERE nincsVonalkod = 1;";
                var parancsJelenlegi = new MySqlCommand(sqlJelenlegi, adatbazis.Conn);
                var olvasoJelenlegi = parancsJelenlegi.ExecuteReader();
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
                        int gyumolcszoldseg = olvasoJelenlegi.GetInt32(2);
                        double mennyiseg = olvasoJelenlegi.GetDouble(3);
                        string mertekegyseg = olvasoJelenlegi.GetString(4);
                        Byte[] kep = (Byte[]) olvasoJelenlegi.GetValue(5);
                        if (gyumolcszoldseg == 0)
                        {
                            BunifuTileButton gomb = new BunifuTileButton() { BackColor = Color.FromArgb(26, 37, 47), color = Color.FromArgb(26, 37, 47), colorActive = Color.FromArgb(55, 81, 108), Cursor = Cursors.Hand, Font = new Font("Century Gothic", 15.75F), ForeColor = Color.White, Image = ByteKepbe(kep), ImagePosition = 20, ImageZoom = 50, LabelPosition = 41, LabelText = $"{nev} {mennyiseg}{mertekegyseg}", Size = new Size(150, 150), Anchor = AnchorStyles.None, Name = Convert.ToString(vonalkodSzam) };

                            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
                            panel.Controls.Add(gomb, j, i);
                            gomb.Click += new EventHandler(click);
                        }
                        else
                        {
                            BunifuTileButton gomb = new BunifuTileButton() { BackColor = Color.FromArgb(26, 37, 47), color = Color.FromArgb(26, 37, 47), colorActive = Color.FromArgb(55, 81, 108), Cursor = Cursors.Hand, Font = new Font("Century Gothic", 15.75F), ForeColor = Color.White, Image = ByteKepbe(kep), ImagePosition = 20, ImageZoom = 50, LabelPosition = 41, LabelText = nev, Size = new Size(150, 150), Anchor = AnchorStyles.None, Name = Convert.ToString(vonalkodSzam) };
                            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
                            panel.Controls.Add(gomb, j, i);
                            gomb.Click += new EventHandler(click);
                        }
                        j++;
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
        }
        public static Bitmap ByteKepbe(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }
        private void click(object sender, EventArgs e)
        {

            int arucikkekID = 0;
            int pultokID = 0;
            int gyumolcszoldseg = 0;
            long vonalkod = Convert.ToInt64((sender as BunifuTileButton).Name);
            try
            {
                adatbazis.Conn.Open();
                MySqlCommand parancs = new MySqlCommand($"SELECT gyumolcszoldseg FROM arucikkek WHERE vonalkod_szam = {vonalkod};", adatbazis.Conn);

                MySqlDataReader olvaso = parancs.ExecuteReader();
                if (olvaso.HasRows)
                {
                    olvaso.Read();
                    gyumolcszoldseg = olvaso.GetInt32(0);
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
            if (gyumolcszoldseg == 0)
            {
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
            else
            {
                SulyMegadas frmSulyMegadas = new SulyMegadas(adatbazis, onkisziolgaloForm, vonalkod, this);
                frmSulyMegadas.ShowDialog();
            }
            
        }

        private void btnVissza_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
