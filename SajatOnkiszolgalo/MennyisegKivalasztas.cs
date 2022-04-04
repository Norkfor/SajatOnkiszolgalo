using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SajatOnkiszolgalo
{
    public partial class MennyisegKivalasztas : Form
    {
        private Onkiszolgalo onkiszolgaloForm;
        private DB adatbazis;
        int darab;
        public MennyisegKivalasztas(int darab, Onkiszolgalo onkiszolgaloForm, DB adatbazis)
        {
            InitializeComponent();
            this.darab = darab;
            this.onkiszolgaloForm = onkiszolgaloForm;
            this.adatbazis = adatbazis;
            lblDarab.Text = $"{this.darab} db";
        }

        private void btnMegsem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPlusz_Click(object sender, EventArgs e)
        {
            darab++;
            lblDarab.Text = $"{darab} db";
        }

        private void btnMinusz_Click(object sender, EventArgs e)
        {
            if (darab > 1)
            {
                darab--;
                lblDarab.Text = $"{darab} db";
            }
        }

        private void btnMentes_Click(object sender, EventArgs e)
        {
            MennyisegBeallitas();
            onkiszolgaloForm.ListboxDeklaralas();
            Close();
        }

        private void MennyisegBeallitas()
        {
            try
            {
                adatbazis.Conn.Open();
                string sqlDolgozo = $"UPDATE `vasarlok` SET `termekDarab` = '{darab}' WHERE `vasarlok`.`id` = {onkiszolgaloForm.vasarloID};";
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
    }
}
