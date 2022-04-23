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
    public partial class DolgozoiFelulet : Form
    {
        private Onkiszolgalo onkiszolgaloForm;
        private Segitseg_keres segitseg;
        public DolgozoiFelulet(Onkiszolgalo onkiszolgaloForm, Segitseg_keres segitseg)
        {
            InitializeComponent();
            this.segitseg = segitseg;
            this.onkiszolgaloForm = onkiszolgaloForm;
            
            if (Screen.AllScreens.Length > 1)
            {
                if (WindowState == FormWindowState.Normal || WindowState == FormWindowState.Minimized)
                {
                    WindowState = FormWindowState.Maximized;
                }
                Location = Screen.AllScreens[1].WorkingArea.Location;
            }
        }

        public void ListboxFrissit()
        {
            lbNev.Items.Clear();
            lbAr.Items.Clear();
            lbNev.Items.AddRange(onkiszolgaloForm.lbNev.Items);
            lbAr.Items.AddRange(onkiszolgaloForm.lbAr.Items);
        }

        private void btnEngedely_Click(object sender, EventArgs e)
        {
            segitseg.Hide();
            onkiszolgaloForm.Enabled = true;
            btnEngedely.Enabled = false;
        }

    }
}
