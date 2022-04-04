﻿using System;
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
    
    public partial class MunkaFelulet : Form
    {
        private Onkiszolgalo onkiszolgaloForm;
        private Segitseg_keres segitseg;
        public MunkaFelulet(Onkiszolgalo onkiszolgaloForm, Segitseg_keres segitseg)
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

        private void btnEngedely_Click(object sender, EventArgs e)
        {
            segitseg.Hide();
            onkiszolgaloForm.Enabled = true;
            btnEngedely.Enabled = false;
        }
    }
}
