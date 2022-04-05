using MySql.Data.MySqlClient;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace SajatOnkiszolgalo
{
    public partial class SulyMegadas : Form
    {
        string suly = "";
        DB adatbazis;
        Onkiszolgalo onkisziolgaloForm;
        Termekek termekekForm;
        long vonalkod;
        
        public SulyMegadas(DB adatbazis, Onkiszolgalo onkisziolgaloForm, long vonalkod, Termekek termekekForm)
        {
            InitializeComponent();
            this.adatbazis = adatbazis;
            this.onkisziolgaloForm = onkisziolgaloForm;
            this.vonalkod = vonalkod;
            this.termekekForm = termekekForm;
        }
        public SulyMegadas(DB adatbazis, Onkiszolgalo onkisziolgaloForm, long vonalkod)
        {
            InitializeComponent();
            this.adatbazis = adatbazis;
            this.onkisziolgaloForm = onkisziolgaloForm;
            this.vonalkod = vonalkod;
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            suly += "0";
            lblSuly.Text = $"{Convert.ToInt32(suly):N0}g";

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            suly += "1";
            lblSuly.Text = $"{Convert.ToInt32(suly):N0}g";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            suly += "2";
            lblSuly.Text = $"{Convert.ToInt32(suly):N0}g";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            suly += "3";
            lblSuly.Text = $"{Convert.ToInt32(suly):N0}g";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            suly += "4";
            lblSuly.Text = $"{Convert.ToInt32(suly):N0}g";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            suly += "5";
            lblSuly.Text = $"{Convert.ToInt32(suly):N0}g";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            suly += "6";
            lblSuly.Text = $"{Convert.ToInt32(suly):N0}g";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            suly += "7";
            lblSuly.Text = $"{Convert.ToInt32(suly):N0}g";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            suly += "8";
            lblSuly.Text = $"{Convert.ToInt32(suly):N0}g";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            suly += "9";
            lblSuly.Text = $"{Convert.ToInt32(suly):N0}g";
        }

        private void btnTorles_Click(object sender, EventArgs e)
        {

            if (suly.Length - 1 > 0)
            {
                suly = suly.Remove(suly.Length - 1);
                lblSuly.Text = $"{Convert.ToInt32(suly):N0}g";

            }
            else
            {
                suly = "0";
                lblSuly.Text = $"{suly}g";
            }
        }

        private void btnKilep_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnHozzaad_Click(object sender, EventArgs e)
        {
            int pultokID = 0;
            int arucikkekID = 0;
            double sulyKilogramm = Convert.ToDouble(suly) / 1000;
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
                MySqlCommand parancs1 = new MySqlCommand($"SELECT aruid FROM arucikkek WHERE vonalkod_szam = {vonalkod};", adatbazis.Conn);
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
                        adatbazis.Conn.Open();
                        MySqlCommand parancs5 = new MySqlCommand($"UPDATE `arucikkek` SET `mennyiseg` = '{sulyKilogramm.ToString(new CultureInfo("en-US"))}' WHERE `arucikkek`.`aruid` = {arucikkekID};", adatbazis.Conn);
                        parancs5.ExecuteNonQuery();
                        adatbazis.Conn.Close();
                        onkisziolgaloForm.ListboxDeklaralas();
                        onkisziolgaloForm.JelenlegiTermekBeallitas();
                        Close();
                        termekekForm.Close();
                    }
                    else
                    {
                        adatbazis.Conn.Close();
                        adatbazis.Conn.Open();
                        MySqlCommand parancs4 = new MySqlCommand($"INSERT INTO `vasarlok` (`id`, `pultokID`, `arucikkekID`, `termekDarab`, `aktiv`) VALUES (NULL, '{pultokID}', '{arucikkekID}', '1', '1');", adatbazis.Conn);
                        parancs4.ExecuteNonQuery();
                        adatbazis.Conn.Close();
                        adatbazis.Conn.Open();
                        MySqlCommand parancs6 = new MySqlCommand($"UPDATE `arucikkek` SET `mennyiseg` = '{sulyKilogramm.ToString(new CultureInfo("en-US"))}' WHERE `arucikkek`.`aruid` = {arucikkekID};", adatbazis.Conn);
                        parancs6.ExecuteNonQuery();
                        adatbazis.Conn.Close();
                        onkisziolgaloForm.ListboxDeklaralas();
                        onkisziolgaloForm.JelenlegiTermekBeallitas();
                        Close();
                        termekekForm.Close();
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
    }
}
