using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using Microsoft.Office.Interop.Word;
using System.IO;


namespace SajatOnkiszolgalo
{
    public partial class Osszegzes : Form
    {
        Onkiszolgalo onkiszolgaloForm;
        public Osszegzes(Onkiszolgalo onkiszolgaloForm)
        {
            InitializeComponent();
            this.onkiszolgaloForm = onkiszolgaloForm;
            tableLayoutPanel2.Controls.Add(onkiszolgaloForm.lbNev, 0,0);
            tableLayoutPanel2.Controls.Add(onkiszolgaloForm.lbAr, 1, 0);
        }

        private void btnVissza_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnFizetes_Click(object sender, EventArgs e)
        {

        }

        private void blokkPrint_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void CreateDocument()
        {
            using (FileStream fileStream = new FileStream(Path.GetFullPath(@"../../../Template.docx"), FileMode.Open, FileAccess.ReadWrite))
            {
                //Opens the template document.
                using (WordDocument document = new WordDocument(fileStream, FormatType.Docx))
                {
                    string[] fieldNames = new string[] { "EmployeeId", "Name", "Phone", "City" };
                    string[] fieldValues = new string[] { "1001", "Peter", "+122-2222222", "London" };
                    //Performs the mail merge.
                    document.MailMerge.Execute(fieldNames, fieldValues);
                    //Creates file stream.
                    using (FileStream outputStream = new FileStream(Path.GetFullPath(@"../../../Result.docx"), FileMode.Create, FileAccess.ReadWrite))
                    {
                        //Saves the Word document to file stream.
                        document.Save(outputStream, FormatType.Docx);
                    }
                }
            }
        }
    }
}
