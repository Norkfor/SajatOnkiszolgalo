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
    public partial class NincsTermek : Form
    {
        Onkiszolgalo onkiszolgaloForm;
        public NincsTermek(Onkiszolgalo onkiszolgaloForm)
        {
            InitializeComponent();
            this.onkiszolgaloForm = onkiszolgaloForm;
            if (onkiszolgaloForm.MagyarIdoVan)
            {
                lblNincs.Text = "Jelenleg nincs hozzáadott termék az önkiszolgálóban. Kérem, olvasson be egy terméket az árucikk módosításához.";
            }
            else
            {
                lblNincs.Text = "There are currently no products added to the self-service. Please scan a product to change the item.";
            }
        }

        private void btnMegsem_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
