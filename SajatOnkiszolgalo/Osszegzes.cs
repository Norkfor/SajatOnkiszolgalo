using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Drawing.Printing;
using Spire.Doc;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;


namespace SajatOnkiszolgalo
{
    public partial class Osszegzes : Form
    {
        Onkiszolgalo onkiszolgaloForm;

        public Osszegzes(Onkiszolgalo onkiszolgaloForm)
        {
            InitializeComponent();
            this.onkiszolgaloForm = onkiszolgaloForm;

            lbNev.Items.AddRange(onkiszolgaloForm.lbNev.Items);
            lbAr.Items.AddRange(onkiszolgaloForm.lbAr.Items);
        }

        private void btnVissza_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnFizetes_Click(object sender, EventArgs e)
        {
            //Spire.Doc.Document doc = new Spire.Doc.Document();
            //doc.LoadFromFile("sample.docx");
            //PrintDialog dialog = new PrintDialog();
            //dialog.AllowPrintToFile = true;
            //dialog.AllowCurrentPage = true;
            //dialog.AllowSomePages = true;
            //dialog.UseEXDialog = true;
            //doc.PrintDialog = dialog;
            //PrintDocument printDoc = doc.PrintDocument;
            //if (dialog.ShowDialog() == DialogResult.OK)
            //{
            //    printDoc.Print();

            //}
            CreateDocument();
        }


        private void CreateDocument()
        {
            using (FileStream fileStream = new FileStream(Path.GetFullPath(@"Template.docx"), FileMode.Open, FileAccess.ReadWrite))
            {
                //Opens the template document.
                using (WordDocument document = new WordDocument(fileStream, FormatType.Docx))
                {
                    string[] fieldNames = new string[] { "EmployeeId", "Name", "Phone", "City" };
                    string[] fieldValues = new string[] { "1001", "Peter", "+122-2222222", "London" };
                    //Performs the mail merge.
                    document.MailMerge.Execute(fieldNames, fieldValues);
                    //Creates file stream.
                    using (FileStream outputStream = new FileStream(Path.GetFullPath(@"Result.docx"), FileMode.Create, FileAccess.ReadWrite))
                    {
                        //Saves the Word document to file stream.
                        document.Save(outputStream, FormatType.Docx);
                    }
                }
            }
        }
    }
}
