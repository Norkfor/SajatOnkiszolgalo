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
    public partial class KoszonjukVasarlas : Form
    {
        static int ido = 4;
        Onkiszolgalo onkiszolgaloForm;
        public KoszonjukVasarlas(Onkiszolgalo onkiszolgaloForm)
        {
            InitializeComponent();
            this.onkiszolgaloForm = onkiszolgaloForm;
            if (onkiszolgaloForm.MagyarIdoVan)
            {
                lblKoszonjuk.Text = "Köszönjük a vásárlását!";
            }
            else
            {
                lblKoszonjuk.Text = "Thank you for your purchase!";
            }
        }

        private void trVisszaSzamol_Tick(object sender, EventArgs e)
        {
            
            if (ido == 0)
            {
                Close();
            }
            else
            {
                ido--;
            }
        }
    }
}
