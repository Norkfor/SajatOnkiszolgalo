using MySql.Data.MySqlClient;
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
    public partial class KeziBevitel : Form
    {
        DB adatbazis;
        Onkiszolgalo onkiszolgaloForm;
        public KeziBevitel(DB adatbazis, Onkiszolgalo onkiszolgaloForm)
        {
            InitializeComponent();
            lblKodSor.Text = "";
            this.adatbazis = adatbazis;
            this.onkiszolgaloForm = onkiszolgaloForm;
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            lblKodSor.Text += "0";
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            lblKodSor.Text += "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            lblKodSor.Text += "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            lblKodSor.Text += "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            lblKodSor.Text += "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            lblKodSor.Text += "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            lblKodSor.Text += "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            lblKodSor.Text += "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            lblKodSor.Text += "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            lblKodSor.Text += "9";
        }

        private void btnTorles_Click(object sender, EventArgs e)
        {
            string s = lblKodSor.Text;
            if (s.Length>0)
            {
                string result = s.Remove(s.Length - 1);
                lblKodSor.Text = result;
            }
        }

        private void btnKilep_Click(object sender, EventArgs e)
        {
            onkiszolgaloForm.AdatbazisEllenorzes.Enabled = true;
            Close();
        }

        private void btnHozzaad_Click(object sender, EventArgs e)
        {
            int arucikkekID = 0;
            int pultokID = 0;
            try
            {
                adatbazis.Conn.Open();
                MySqlCommand parancs = new MySqlCommand($"SELECT id FROM pultok WHERE vonalkod_szam = {onkiszolgaloForm.randomSzam};", adatbazis.Conn);

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
                MySqlCommand parancs1 = new MySqlCommand($"SELECT aruid, gyumolcszoldseg FROM arucikkek WHERE vonalkod_szam = {Convert.ToInt64(lblKodSor.Text)};", adatbazis.Conn);
                MySqlDataReader olvaso1 = parancs1.ExecuteReader();
                if (olvaso1.HasRows)
                {
                    olvaso1.Read();
                    arucikkekID = olvaso1.GetInt32(0);
                    int gyumolcszoldseg = olvaso1.GetInt32(1);
                    adatbazis.Conn.Close();
                    adatbazis.Conn.Open();
                    MySqlCommand parancs2 = new MySqlCommand($"SELECT id, termekDarab FROM vasarlok WHERE arucikkekID = '{arucikkekID}' AND pultokID = '{pultokID}';", adatbazis.Conn);
                    MySqlDataReader olvaso2 = parancs2.ExecuteReader();
                    if (olvaso2.HasRows && gyumolcszoldseg != 1)
                    {
                        olvaso2.Read();
                        int id = olvaso2.GetInt32(0);
                        double darab = olvaso2.GetDouble(1);
                        adatbazis.Conn.Close();
                        adatbazis.Conn.Open();
                        MySqlCommand parancs3 = new MySqlCommand($"UPDATE `vasarlok` SET `pultokID` = '{pultokID}', `arucikkekID` = '{arucikkekID}', `termekDarab` = '{darab}', `aktiv` = '1' WHERE `vasarlok`.`id` = '{id}';", adatbazis.Conn);
                        parancs3.ExecuteNonQuery();
                        MessageBox.Show("A termék hozzáadása sikeresen megtörtént!", "Információ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        adatbazis.Conn.Close();
                        onkiszolgaloForm.ListboxDeklaralas();
                        onkiszolgaloForm.JelenlegiTermekBeallitas();
                        lblKodSor.Text = "";
                    }
                    else
                    {
                        adatbazis.Conn.Close();
                        adatbazis.Conn.Open();
                        MySqlCommand parancs4 = new MySqlCommand($"INSERT INTO `vasarlok` (`id`, `pultokID`, `arucikkekID`, `termekDarab`, `aktiv`) VALUES (NULL, '{pultokID}', '{arucikkekID}', '1', '1');", adatbazis.Conn);
                        parancs4.ExecuteNonQuery();
                        MessageBox.Show("A termék hozzáadása sikeresen megtörtént!", "Információ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        adatbazis.Conn.Close();
                        onkiszolgaloForm.ListboxDeklaralas();
                        onkiszolgaloForm.JelenlegiTermekBeallitas();
                        lblKodSor.Text = "";
                    }
                    adatbazis.Conn.Close();
                }
                else
                {
                    MessageBox.Show($"Az adatbázisban nem szerepel ez az árucikk!", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblKodSor.Text = "";
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
    }
}

