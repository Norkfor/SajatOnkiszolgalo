using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using ZXing;

namespace SajatOnkiszolgalo
{
    public partial class Onkiszolgalo : Form
    {
        Segitseg_keres segitseg = new Segitseg_keres();
        MunkaFelulet dolgozoi;
        DB adatbazis;

        bool MagyarIdoVan = true;
        public double osszesen;
        int lbNevSzeles;
        public int vasarloID = 0;
        public long randomSzam = 0;
        int vanDolgozo = 0;
        int dolgozoID = 0;
        public int kivalasztottTermek = -1;
        public string kivalasztottNev = "";
        string dolgozoNev = "";
        string eleresiUtvonal = Path.GetDirectoryName(Application.ExecutablePath);
        public bool modositas = false;
        public long jelenlegiVonalkod = 0;
        public double jelenlegiSuly = 0;
        frmDolgozo dolgozo;

        public Onkiszolgalo()
        {

            InitializeComponent();
            adatbazis = new DB();
            onKiszolgaloMegjelenit();
            dolgozoi = new MunkaFelulet(this, segitseg);
            dolgozoi.Show();
            dolgozoi.btnEngedely.Enabled = false;
            ujVasarlas();
        }
        public void ujVasarlas()
        {
            lblTermek.Text = "";
            pbTermek.Image = null;
            lbNev.Items.Clear();
            lbAr.Items.Clear();
            dolgozoi.lbNev.Items.Clear();
            dolgozoi.lbAr.Items.Clear();
            MagyarIdoVan = true;
            osszesen = 0;
            vasarloID = 0;
            randomSzam = 0;
            vanDolgozo = 0;
            dolgozoID = 0;
            kivalasztottTermek = -1;
            kivalasztottNev = "";
            dolgozoNev = "";
            modositas = false;
            jelenlegiVonalkod = 0;
            jelenlegiSuly = 0;
            lblOssz.Text = "Összesen: 0Ft";
            RandomKodGeneralas();
        }
        private void RandomKodGeneralas()
        {
            Random randomKod = new Random();
            randomSzam = Convert.ToInt64($"{2660}{randomKod.Next(11111, 99999)}");
            BarcodeWriter vonalkodIro = new BarcodeWriter() { Format = BarcodeFormat.AZTEC };
            pbVonalkod.Image = vonalkodIro.Write($"{randomSzam}");
            try
            {
                adatbazis.Conn.Open();
                string sqlDolgozo = $"INSERT INTO `pultok` (`id`, `nev`, `vonalkod_szam`) VALUES (NULL, 'Pult 1', '{randomSzam}');";
                var parancsDolgozo = new MySqlCommand(sqlDolgozo, adatbazis.Conn);
                parancsDolgozo.ExecuteNonQuery();
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

        public void onKiszolgaloMegjelenit()
        {
            if (Screen.AllScreens.Length > 1)
            {
                if (WindowState == FormWindowState.Normal || WindowState == FormWindowState.Minimized)
                {
                    WindowState = FormWindowState.Maximized;
                }
                Location = Screen.AllScreens[0].WorkingArea.Location;
                FormBorderStyle = FormBorderStyle.None;
            }
        }
        private void btnMagyar_Click(object sender, EventArgs e)
        {
            btnMagyar.BorderColor = Color.Cyan;
            btnAngol.BorderColor = Color.Empty;
            btnSegitseg.Text = "Segítségkérés egy munkatársunktól";
            btnMennyiseg.Text = "Mennyiség kiválasztása a jelenlegi terméknél";
            btnTermekek.Text = "Termékek";
            lblTetelek.Text = "Tételek";
            lblOssz.Text = $"Összesen: {osszesen:N3}";
            btnFizetes.Text = "Fizetés";
            segitseg.lblPillanat.Text = "Kérem, várjon egy pillanatot.\r\nMunkatársunk hamarosan megérkezik.\r\n";
            dolgozoi.lblPult.Text = "Pult 1";
            dolgozoi.btnEngedely.Text = "Engedélyezés";
            MagyarIdoVan = true;
        }

        private void btnAngol_Click(object sender, EventArgs e)
        {
            btnAngol.BorderColor = Color.Cyan;
            btnMagyar.BorderColor = Color.Empty;
            btnSegitseg.Text = "Asking for help from an employee";
            btnMennyiseg.Text = "Select quantity for current product";
            btnTermekek.Text = "Products";
            lblTetelek.Text = "Items";
            lblOssz.Text = $"In all: {osszesen:N3}";
            btnFizetes.Text = "Pay";
            segitseg.lblPillanat.Text = "Please wait a moment.\r\nOur workmate will arrive soon.\r\n";
            dolgozoi.lblPult.Text = "Desk 1";
            dolgozoi.btnEngedely.Text = "Enable";
            MagyarIdoVan = false;
        }
        private void Ido_Tick(object sender, EventArgs e)
        {
            IdoFormatum();
        }
        private void IdoFormatum()
        {
            if (MagyarIdoVan)
            {
                MagyarIdo();
            }
            else
            {
                AngolIdo();
            }
        }
        private void AngolIdo()
        {
            lblIdo.Text = DateTime.Now.ToString("hh:mm:ss");
        }
        private void MagyarIdo()
        {
            lblIdo.Text = DateTime.Now.ToString("HH:mm:ss");
        }
        private void btnSegitseg_Click(object sender, EventArgs e)
        {
            segitseg.FormBorderStyle = FormBorderStyle.None;
            segitseg.Show();
            Enabled = false;
            dolgozoi.btnEngedely.Enabled = true;
        }

        private void GorgessLe()
        {
            lbNev.TopIndex = Math.Max(lbNev.Items.Count - lbNev.ClientSize.Height / lbNev.ItemHeight + 1, 0);
            lbAr.TopIndex = Math.Max(lbAr.Items.Count - lbAr.ClientSize.Height / lbAr.ItemHeight + 1, 0);
        }

        public void Onkiszolgalo_Shown(object sender, EventArgs e)
        {
            lbNevSzeles = lbNev.Width / 14;
        }

        public void NincsDolgozo()
        {
            try
            {
                adatbazis.Conn.Open();
                MySqlCommand dolgozo = new MySqlCommand($"UPDATE `dolgozok` SET `aktiv` = '0' WHERE `dolgozok`.`id` = '{dolgozoID}';", adatbazis.Conn);
                dolgozo.ExecuteNonQuery();
                vanDolgozo = 0;
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

        private void AdatbazisEllenorzes_Tick(object sender, EventArgs e)
        {

            lbAr.SelectedIndex = kivalasztottTermek;
            lbNev.SelectedIndex = kivalasztottTermek;
            DolgozoEllenorzo();
            if (vanDolgozo == 0)
            {
                dolgozoi.ListboxFrissit();
                ListboxDeklaralas();
                JelenlegiTermekBeallitas();
            }
            lbAr.SelectedIndex = kivalasztottTermek;
            lbNev.SelectedIndex = kivalasztottTermek;
            GorgessLe();
        }

        private void DolgozoEllenorzo()
        {
            try
            {
                adatbazis.Conn.Close();
                adatbazis.Conn.Open();
                string sqlDolgozo = $"SELECT dolgozok.nev, dolgozok.id FROM dolgozok WHERE dolgozok.aktiv = '1';";
                var parancsDolgozo = new MySqlCommand(sqlDolgozo, adatbazis.Conn);
                var olvasoDolgozo = parancsDolgozo.ExecuteReader();
                if (olvasoDolgozo.HasRows)
                {
                    olvasoDolgozo.Read();
                    dolgozoNev = olvasoDolgozo.GetString(0);
                    dolgozoID = olvasoDolgozo.GetInt32(1);
                    adatbazis.Conn.Close();
                    vanDolgozo = 1;

                    dolgozo = new frmDolgozo(dolgozoNev, this, adatbazis);
                    dolgozo.ShowDialog();
                    NincsDolgozo();
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
        }

        public void JelenlegiTermekBeallitas()
        {
            try
            {
                adatbazis.Conn.Open();
                string sqlJelenlegi = $"SELECT v.id, a.nev, a.mennyiseg, am.mertekegyseg, v.termekDarab, a.gyumolcszoldseg FROM vasarlok as v INNER JOIN arucikkek as a ON v.arucikkekID = a.aruid INNER JOIN aru_mertekegyseg AS am ON a.mertekegyseg_id = am.id INNER JOIN pultok as p ON v.pultokID = p.id WHERE v.aktiv = 1 AND p.vonalkod_szam = '{randomSzam}';";
                var parancsJelenlegi = new MySqlCommand(sqlJelenlegi, adatbazis.Conn);
                var olvasoJelenlegi = parancsJelenlegi.ExecuteReader();
                if (olvasoJelenlegi.HasRows)
                {
                    olvasoJelenlegi.Read();
                    vasarloID = olvasoJelenlegi.GetInt32(0);
                    string jelenlegiNev = olvasoJelenlegi.GetString(1);
                    double jelenlegiMennyiseg = olvasoJelenlegi.GetDouble(2);
                    string jelenlegiMertekegyseg = olvasoJelenlegi.GetString(3);
                    double suly = olvasoJelenlegi.GetDouble(4);
                    int gyumolcszoldseg = olvasoJelenlegi.GetInt32(5);
                    jelenlegiSuly = suly;
                    if (gyumolcszoldseg == 0)
                    {
                        lblTermek.Text = $"{jelenlegiNev} {jelenlegiMennyiseg}{jelenlegiMertekegyseg}";
                        pbTermek.Image = Image.FromFile(Path.Combine(eleresiUtvonal, $@"kepek\{jelenlegiNev}.jpg"));
                        adatbazis.Conn.Close();
                        adatbazis.Conn.Open();
                        string sqlNemAktiv = $"UPDATE `vasarlok` SET `aktiv` = '0' WHERE `vasarlok`.`id` = {vasarloID};";
                        var parancsNemAktiv = new MySqlCommand(sqlNemAktiv, adatbazis.Conn);
                        var olvasoNemAktiv = parancsNemAktiv.ExecuteNonQuery();
                        adatbazis.Conn.Close();

                    }
                    else
                    {
                        lblTermek.Text = $"{jelenlegiNev} {suly}{jelenlegiMertekegyseg}";
                        pbTermek.Image = Image.FromFile(Path.Combine(eleresiUtvonal, $@"kepek\{jelenlegiNev}.jpg"));
                        adatbazis.Conn.Close();
                        adatbazis.Conn.Open();
                        string sqlNemAktiv = $"UPDATE `vasarlok` SET `aktiv` = '0' WHERE `vasarlok`.`id` = {vasarloID};";
                        var parancsNemAktiv = new MySqlCommand(sqlNemAktiv, adatbazis.Conn);
                        var olvasoNemAktiv = parancsNemAktiv.ExecuteNonQuery();
                        adatbazis.Conn.Close();
                    }

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
        }

        public void ListboxDeklaralas()
        {

            try
            {
                adatbazis.Conn.Open();
                string sqlAru = $"SELECT a.aruid, a.vonalkod_szam, a.nev, a.mennyiseg, am.mertekegyseg, a.ara, v.termekDarab, a.gyumolcszoldseg FROM vasarlok as v INNER JOIN arucikkek as a ON v.arucikkekID = a.aruid INNER JOIN aru_mertekegyseg AS am ON a.mertekegyseg_id = am.id INNER JOIN pultok as p ON v.pultokID = p.id WHERE p.vonalkod_szam = '{randomSzam}' ORDER BY v.id ASC";
                var parancsAru = new MySqlCommand(sqlAru, adatbazis.Conn);
                var olvasoAru = parancsAru.ExecuteReader();

                if (olvasoAru.HasRows)
                {
                    lbNev.Items.Clear();
                    lbAr.Items.Clear();
                    osszesen = 0;

                    while (olvasoAru.Read())
                    {
                        int aruid = olvasoAru.GetInt32(0);
                        long vonalkodszam = olvasoAru.GetInt64(1);
                        jelenlegiVonalkod = vonalkodszam;
                        string arunev = olvasoAru.GetString(2);
                        double mennyiseg = olvasoAru.GetDouble(3);
                        string mertekegyseg = olvasoAru.GetString(4);
                        int ara = olvasoAru.GetInt32(5);
                        double darab = olvasoAru.GetDouble(6);
                        int gyumolcszoldseg = olvasoAru.GetInt32(7);
                        if (gyumolcszoldseg == 1)
                        {
                            string hanyszor = $"({darab:N3}*{ara})";
                            string nev = $"{arunev} {hanyszor:N3}";
                            if (nev.Length > lbNevSzeles)
                            {
                                nev = nev.Substring(0, lbNevSzeles - (2 + hanyszor.Length)) + ".." + hanyszor;
                            }
                            lbNev.Items.Add(nev);
                            lbAr.Items.Add($"{(ara * darab):N0}Ft");
                            osszesen += ara * darab;
                            btnFizetes.Enabled = true;
                        }
                        else
                        {
                            string hanyszor = $"({darab}*{ara:N0})";
                            string nev = $"{arunev} {hanyszor}";
                            if (nev.Length > lbNevSzeles)
                            {
                                nev = nev.Substring(0, lbNevSzeles - (2 + hanyszor.Length)) + ".." + hanyszor;
                            }
                            lbNev.Items.Add(nev);
                            lbAr.Items.Add($"{(ara * darab):N0}Ft");
                            osszesen += ara * darab;
                            btnFizetes.Enabled = true;
                        }
                        lblOssz.Text = $"Összesen: {osszesen:N0}Ft";

                    }
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
        }

        private void btnMennyiseg_Click(object sender, EventArgs e)
        {
            double mennyisegDarab = 0;
            bool vanTermek = false;
            int gyumolcszoldseg = 0;

            try
            {
                adatbazis.Conn.Open();
                string sqlDolgozo2 = $"SELECT v.termekDarab, a.gyumolcszoldseg FROM vasarlok as v INNER JOIN arucikkek as a ON v.arucikkekID = a.aruid WHERE v.id = {vasarloID}";
                var parancsDolgozo2 = new MySqlCommand(sqlDolgozo2, adatbazis.Conn);
                var olvasoDolgozo2 = parancsDolgozo2.ExecuteReader();
                if (olvasoDolgozo2.HasRows)
                {
                    olvasoDolgozo2.Read();
                    mennyisegDarab = olvasoDolgozo2.GetDouble(0);
                    gyumolcszoldseg = olvasoDolgozo2.GetInt32(1);
                    vanTermek = true;
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
            if (vanTermek && gyumolcszoldseg == 0)
            {
                MennyisegKivalasztas frmMennyiseg = new MennyisegKivalasztas(mennyisegDarab, this, adatbazis);
                frmMennyiseg.ShowDialog();
            }
            else if (vanTermek && gyumolcszoldseg == 1)
            {
                SulyMegadas sulyMegadas = new SulyMegadas(adatbazis, this, jelenlegiVonalkod, jelenlegiSuly);
                sulyMegadas.ShowDialog();
            }
            else
            {
                NincsTermek frmNincsTermek = new NincsTermek();
                frmNincsTermek.ShowDialog();
            }
        }


        private void lbNev_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbNev.SelectedIndex != -1)
            {
                kivalasztottTermek = lbNev.SelectedIndex;
                lbAr.SelectedIndex = kivalasztottTermek;
                if (!lbNev.SelectedItem.ToString().Contains('.'))
                {
                    kivalasztottNev = lbNev.SelectedItem.ToString().Substring(0, lbNev.SelectedItem.ToString().IndexOf('(') - 1);
                }
                else
                {
                    if (lbNev.SelectedItem.ToString().Substring(0, lbNev.SelectedItem.ToString().IndexOf('.') - 1) == " ")
                    {
                        kivalasztottNev = lbNev.SelectedItem.ToString().Substring(0, lbNev.SelectedItem.ToString().IndexOf('.') - 2);
                    }
                    else
                    {
                        kivalasztottNev = lbNev.SelectedItem.ToString().Substring(0, lbNev.SelectedItem.ToString().IndexOf('.') - 1);
                    }
                }

            }
            try
            {
                adatbazis.Conn.Open();
                string sqlJelenlegi = $"SELECT a.nev, a.mennyiseg, am.mertekegyseg, v.id, a.gyumolcszoldseg, v.termekDarab FROM vasarlok as v INNER JOIN arucikkek as a ON v.arucikkekID = a.aruid INNER JOIN aru_mertekegyseg AS am ON a.mertekegyseg_id = am.id INNER JOIN pultok as p ON v.pultokID = p.id WHERE a.nev LIKE '%{kivalasztottNev}%' AND p.vonalkod_szam = '{randomSzam}';";
                var parancsJelenlegi = new MySqlCommand(sqlJelenlegi, adatbazis.Conn);
                var olvasoJelenlegi = parancsJelenlegi.ExecuteReader();
                if (olvasoJelenlegi.HasRows)
                {
                    olvasoJelenlegi.Read();
                    string jelenlegiNev = olvasoJelenlegi.GetString(0);
                    double jelenlegiMennyiseg = olvasoJelenlegi.GetDouble(1);
                    string jelenlegiMertekegyseg = olvasoJelenlegi.GetString(2);
                    vasarloID = olvasoJelenlegi.GetInt32(3);
                    int gyumolcszoldseg = olvasoJelenlegi.GetInt32(4);
                    double suly = olvasoJelenlegi.GetDouble(5);
                    if (gyumolcszoldseg == 1)
                    {
                        lblTermek.Text = $"{jelenlegiNev} {suly}{jelenlegiMertekegyseg}";
                        pbTermek.Image = Image.FromFile(Path.Combine(eleresiUtvonal, $@"kepek\{jelenlegiNev}.jpg"));
                        adatbazis.Conn.Close();
                    }
                    else
                    {
                        lblTermek.Text = $"{jelenlegiNev} {jelenlegiMennyiseg}{jelenlegiMertekegyseg}";
                        pbTermek.Image = Image.FromFile(Path.Combine(eleresiUtvonal, $@"kepek\{jelenlegiNev}.jpg"));
                        adatbazis.Conn.Close();
                    }

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

        }

        private void lbAr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbAr.SelectedIndex != -1)
            {
                kivalasztottTermek = lbAr.SelectedIndex;
                lbNev.SelectedIndex = kivalasztottTermek;
            }
        }

        private void btnKilepes_Click(object sender, EventArgs e)
        {
            dolgozo.AdminGombokBeKi();
            dolgozo.ShowDialog();

        }

        private void btnTermekek_Click(object sender, EventArgs e)
        {

            Termekek frmTermekek = new Termekek(adatbazis, this);
            frmTermekek.ShowDialog();
        }

        private void btnTermekTorlese_Click(object sender, EventArgs e)
        {
            try
            {
                adatbazis.Conn.Open();
                string termekTorles = $"DELETE FROM vasarlok WHERE `vasarlok`.`id` = {vasarloID};";
                var parancsTorles = new MySqlCommand(termekTorles, adatbazis.Conn);
                parancsTorles.ExecuteNonQuery();
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
                string termekVanEllenoriz = $"SELECT v.arucikkekID FROM vasarlok as v INNER JOIN pultok as p ON v.pultokID = p.id WHERE p.vonalkod_szam = {randomSzam}";
                var termekVanEllenorizParancs = new MySqlCommand(termekVanEllenoriz, adatbazis.Conn);
                var olvasoTermekVanEllenorzes = termekVanEllenorizParancs.ExecuteReader();
                if (olvasoTermekVanEllenorzes.HasRows)
                {
                    adatbazis.Conn.Close();
                    ListboxDeklaralas();
                    lbNev.SelectedIndex = lbNev.Items.Count - 1;
                    kivalasztottNev = lbNev.SelectedItem.ToString();
                    JelenlegiTermekBeallitas();

                }
                else
                {
                    adatbazis.Conn.Close();
                    lbNev.Items.Clear();
                    lbAr.Items.Clear();
                    lblTermek.Text = "";
                    pbTermek.Image = null;
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

        private void btnFizetes_Click(object sender, EventArgs e)
        {
            Osszegzes OsszegzesForm = new Osszegzes(this, adatbazis);
            OsszegzesForm.ShowDialog();

        }
    }
}