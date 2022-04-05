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
        public SulyMegadas(DB adatbazis, Onkiszolgalo onkisziolgaloForm, long vonalkod, double jelenlegiSuly)
        {
            InitializeComponent();
            this.adatbazis = adatbazis;
            this.onkisziolgaloForm = onkisziolgaloForm;
            this.vonalkod = vonalkod;
            onkisziolgaloForm.modositas = true;
            suly = Convert.ToInt32(jelenlegiSuly * 1000).ToString();
            lblSuly.Text = $"{Convert.ToInt32(suly):N0}g\n({Convert.ToDouble(suly) / 1000}kg)";
            btnHozzaad.Text = "Módosítás";
            btnHozzaad.Enabled = true;
        }
        private void SulyKiiras(string szam)
        {
            suly += szam;
            lblSuly.Text = $"{Convert.ToInt32(suly):N0}g\n({Convert.ToDouble(suly) / 1000}kg)";
            if (szam != "0")
            {
                btnHozzaad.Enabled = true;
            }

        }
        private void btn0_Click(object sender, EventArgs e)
        {
            SulyKiiras("0");

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            SulyKiiras("1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            SulyKiiras("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            SulyKiiras("3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            SulyKiiras("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            SulyKiiras("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            SulyKiiras("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            SulyKiiras("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            SulyKiiras("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            SulyKiiras("9");
        }

        private void btnTorles_Click(object sender, EventArgs e)
        {

            if (suly.Length - 1 > 0)
            {
                suly = suly.Remove(suly.Length - 1);
                lblSuly.Text = $"{Convert.ToInt32(suly):N0}g\n({Convert.ToDouble(suly) / 1000}kg)";

            }
            else
            {
                suly = "0";
                lblSuly.Text = $"0g\n(0kg)";
                btnHozzaad.Enabled = false;
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
                    if (onkisziolgaloForm.modositas == false)
                    {
                        adatbazis.Conn.Open();
                        MySqlCommand parancs4 = new MySqlCommand($"INSERT INTO `vasarlok` (`id`, `pultokID`, `arucikkekID`, `termekDarab`, `aktiv`) VALUES (NULL, '{pultokID}', '{arucikkekID}', '{sulyKilogramm.ToString(new CultureInfo("en-US"))}', '1');", adatbazis.Conn);
                        parancs4.ExecuteNonQuery();
                        adatbazis.Conn.Close();
                        onkisziolgaloForm.ListboxDeklaralas();
                        onkisziolgaloForm.JelenlegiTermekBeallitas();
                        Close();
                        termekekForm.Close();
                    }
                    else
                    {
                        adatbazis.Conn.Open();
                        MySqlCommand parancs4 = new MySqlCommand($"UPDATE `vasarlok` SET `pultokID` = '{pultokID}', `arucikkekID` = '{arucikkekID}', `termekDarab` = '{sulyKilogramm.ToString(new CultureInfo("en-US"))}', `aktiv` = '1' WHERE `vasarlok`.`id` = '{onkisziolgaloForm.vasarloID}';", adatbazis.Conn);
                        parancs4.ExecuteNonQuery();
                        adatbazis.Conn.Close();
                        onkisziolgaloForm.ListboxDeklaralas();
                        onkisziolgaloForm.JelenlegiTermekBeallitas();
                        onkisziolgaloForm.modositas = false;
                        Close();
                    }
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
