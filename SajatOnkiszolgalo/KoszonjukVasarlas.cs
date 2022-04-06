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
        public KoszonjukVasarlas()
        {
            InitializeComponent();
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
