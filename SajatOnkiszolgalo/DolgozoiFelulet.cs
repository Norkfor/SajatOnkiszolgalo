using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql;

namespace SajatOnkiszolgalo
{
    public partial class frmDolgozo : Form
    {
        private Onkiszolgalo onkiszolgaloForm;
        DB adatbazis;
        public frmDolgozo(string nev, Onkiszolgalo onkisziolgaloForm, DB adatbazis)
        {
            InitializeComponent();
            this.onkiszolgaloForm = onkisziolgaloForm;
            this.adatbazis = adatbazis;
            lblNev.Text = nev;
        }

        private void btnKilep_Click(object sender, EventArgs e)
        {
            onkiszolgaloForm.NincsDolgozo();
            onkiszolgaloForm.kivalasztottTermek = -1;
            Close();
        }

        private void btnTermekModosit_Click(object sender, EventArgs e)
        {
            if (onkiszolgaloForm.lbNev.Items.Count != 0)
            {
                AdminGombokBeKi();
                Hide();
            }
            else
            {
                NincsTermek nincsTermek = new NincsTermek();
                nincsTermek.ShowDialog();
            }
        }

        public void AdminGombokBeKi()
        {
            onkiszolgaloForm.lbAr.Enabled = !onkiszolgaloForm.lbAr.Enabled;
            onkiszolgaloForm.lbNev.Enabled = !onkiszolgaloForm.lbNev.Enabled;
            onkiszolgaloForm.tlpTermekTorles.Visible = !onkiszolgaloForm.tlpTermekTorles.Visible;
            onkiszolgaloForm.btnKilepes.Visible = !onkiszolgaloForm.btnKilepes.Visible;
            onkiszolgaloForm.btnSegitseg.Visible = !onkiszolgaloForm.btnSegitseg.Visible;
        }

        private void btnKeziBevitel_Click(object sender, EventArgs e)
        {
            KeziBevitel frmKeziBevitel = new KeziBevitel(adatbazis, onkiszolgaloForm);
            frmKeziBevitel.ShowDialog();
        }
    }
}
