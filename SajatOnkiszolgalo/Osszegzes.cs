using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;
using System.Globalization;
using Spire.Xls;
using System.Drawing.Printing;
using System.IO;

namespace SajatOnkiszolgalo
{
    public partial class Osszegzes : Form
    {
        Onkiszolgalo onkiszolgaloForm;
        DB adatbazis;
        string eleresiUtvonal = Path.GetDirectoryName(Application.ExecutablePath);
        public Osszegzes(Onkiszolgalo onkiszolgaloForm, DB adatbazis)
        {
            InitializeComponent();
            this.onkiszolgaloForm = onkiszolgaloForm;
            this.adatbazis = adatbazis;
            lbNev.Items.AddRange(onkiszolgaloForm.lbNev.Items);
            lbAr.Items.AddRange(onkiszolgaloForm.lbAr.Items);
            if (onkiszolgaloForm.MagyarIdoVan)
            {
                lblOsszegzes.Text = "Összegzés";
                btnFizetes.Text = "Fizetés";
                btnVissza.Text = "Vissza";
                lblOssz.Text = onkiszolgaloForm.lblOssz.Text;
            }
            else
            {
                lblOsszegzes.Text = "Summery";
                btnFizetes.Text = "Pay";
                btnVissza.Text = "Back";
                lblOssz.Text = onkiszolgaloForm.lblOssz.Text;
            }
        }

        private void btnVissza_Click(object sender, EventArgs e)
        {
            onkiszolgaloForm.AdatbazisEllenorzes.Enabled = true;
            Close();
        }

        private void btnFizetes_Click(object sender, EventArgs e)
        {
            AddNewRowsToExcelFile();

            Workbook workbook = new Workbook();
            workbook.LoadFromFile(Path.Combine(eleresiUtvonal,"sablon.xlsx"));
            PrintDocument pd = workbook.PrintDocument;
            pd.Print();
            onkiszolgaloForm.ujVasarlas();
            Close();
            KoszonjukVasarlas koszonjukVasarlasForm = new KoszonjukVasarlas(onkiszolgaloForm);
            koszonjukVasarlasForm.ShowDialog();
            

        }

        public void AddNewRowsToExcelFile()
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(Path.Combine(eleresiUtvonal, "sablon.xlsx"), 0, false, 5, "", "", false,
                Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            Excel.Range xlRange = xlWorkSheet.UsedRange;
            for (int i = 7; i <= 30; i++)
            {
                for (int j = 1; j <= 4; j++)
                {
                    xlWorkSheet.Cells[i, j] = "";
                }
            }

            try
            {
                adatbazis.Conn.Open();
                string sqlAru = $"SELECT a.aruid, a.vonalkod_szam, a.nev, a.mennyiseg, am.mertekegyseg, a.ara, v.termekDarab, a.gyumolcszoldseg FROM vasarlok as v INNER JOIN arucikkek as a ON v.arucikkekID = a.aruid INNER JOIN aru_mertekegyseg AS am ON a.mertekegyseg_id = am.id INNER JOIN pultok as p ON v.pultokID = p.id WHERE p.vonalkod_szam = '{onkiszolgaloForm.randomSzam}' ORDER BY v.id ASC";
                var parancsAru = new MySqlCommand(sqlAru, adatbazis.Conn);
                var olvasoAru = parancsAru.ExecuteReader();

                if (olvasoAru.HasRows)
                {
                    int index = 7;
                    while (olvasoAru.Read())
                    {
                        int aruid = olvasoAru.GetInt32(0);
                        long vonalkodszam = olvasoAru.GetInt64(1);
                        string arunev = olvasoAru.GetString(2);
                        double mennyiseg = olvasoAru.GetDouble(3);
                        string mertekegyseg = olvasoAru.GetString(4);
                        int ara = olvasoAru.GetInt32(5);
                        double darab = olvasoAru.GetDouble(6);
                        int gyumolcszoldseg = olvasoAru.GetInt32(7);
                        if (gyumolcszoldseg == 1)
                        {
                            xlWorkSheet.Cells[index, 1] = $"{arunev}";
                            xlWorkSheet.Cells[index, 2] = $"{darab.ToString(new CultureInfo("en-us"))} {mertekegyseg}";
                            xlWorkSheet.Cells[index, 3] = $"{darab}*{ara}";
                            int jelenlegiAr = Convert.ToInt32(ara * darab);
                            xlWorkSheet.Cells[index, 4] = $"{jelenlegiAr.ToString(new CultureInfo("en-us"))}";
                        }
                        else
                        {
                            xlWorkSheet.Cells[index, 1] = $"{arunev}";
                            xlWorkSheet.Cells[index, 2] = $"{mennyiseg.ToString(new CultureInfo("en-us"))} {mertekegyseg}";
                            xlWorkSheet.Cells[index, 3] = $"{darab.ToString()}*{ara}";
                            int jelenlegiAr = Convert.ToInt32(ara * darab);
                            xlWorkSheet.Cells[index, 4] = $"{jelenlegiAr.ToString(new CultureInfo("en-us"))}";
                        }

                        index++;
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





            xlApp.DisplayAlerts = false;
            xlWorkBook.SaveAs(Path.Combine(eleresiUtvonal, "sablon.xlsx"), Excel.XlFileFormat.xlOpenXMLWorkbook,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlNoChange,
                Excel.XlSaveConflictResolution.xlLocalSessionChanges, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value);
            xlWorkBook.Close();
            xlApp.Quit();
            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);
        }
    }
}
