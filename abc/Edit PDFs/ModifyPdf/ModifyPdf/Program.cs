using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace ModifyPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //PDF Sharp
                //OpenFileWithPDFSharp();



                //Thoat Word
                foreach (var process in Process.GetProcessesByName("WINWORD"))
                {
                    process.Kill();
                }

                //Chuyen txt to Dictionary

                Dictionary<string, string> myDicToReplace = new Dictionary<string, string>();

                //ReadFileTN1
                string pathFile_TN1 = @"C:\Users\NAMTRUNG205\Desktop\toExe\Templates\OutPut_TN5.txt";

                string[] lines_TN1 = System.IO.File.ReadAllLines(pathFile_TN1);

                // Display the file contents by using a foreach loop.
                System.Console.WriteLine("Contents of WriteLines2.txt = ");
                foreach (string line in lines_TN1)
                {
                    if (line.Count(f => f == '|') == 1)
                    {
                        List<string> listKeyValue = line.Split('|').ToList();

                        if (!myDicToReplace.Keys.Contains(listKeyValue[0]))
                        {
                            myDicToReplace.Add(listKeyValue[0], listKeyValue[1]);
                        }
                        else
                        {
                            myDicToReplace[listKeyValue[0]] = listKeyValue[1];
                        }
                    }
                }



                //ReadFileTN3
                string pathFile_TN3 = @"C:\OutPut_TN3.txt";

                string[] lines_TN3 = System.IO.File.ReadAllLines(pathFile_TN3);

                // Display the file contents by using a foreach loop.
                System.Console.WriteLine("Contents of WriteLines2.txt = ");
                foreach (string line in lines_TN3)
                {
                    if(line.Count(f => f == '|') == 1)
                    {
                        List<string> listKeyValue = line.Split('|').ToList();

                        if (!myDicToReplace.Keys.Contains(listKeyValue[0]))
                        {
                            myDicToReplace.Add(listKeyValue[0], listKeyValue[1]);
                        }
                        else
                        {
                            myDicToReplace[listKeyValue[0]] = listKeyValue[1];
                        }
                    }
                }

                object fileName = Path.Combine("", @"C:\\Bao cao TN SB Template.docx");
                Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application { Visible = false };
                Microsoft.Office.Interop.Word.Document aDoc = wordApp.Documents.Open(fileName, ReadOnly: false, Visible: false);
                aDoc.Activate();
                //Dac trung hinh hoc



                foreach (string myField in myDicToReplace.Keys)
                {
                    FindAndReplace(wordApp, myField, myDicToReplace[myField]);
                }

                

                string myNow = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + " " + DateTime.Now.ToLongDateString();
                string studentName = "Nguyen Van A";
                string docxName = "C:\\" + studentName + " At" + myNow + ".docx";
                string pdfName = "C:\\" + studentName + " At" + myNow + ".pdf";
                aDoc.SaveAs2(@docxName);

                Microsoft.Office.Interop.Word.Document wordDocument = wordApp.Documents.Open(@docxName);
                wordDocument.ExportAsFixedFormat(@pdfName, WdExportFormat.wdExportFormatPDF);
                wordApp.Quit();

                Process proc = new Process();
                proc.StartInfo = new ProcessStartInfo(@pdfName);
                proc.Start();


            }
            catch
            {
                MessageBox.Show("File abc.docx đang được mở, đóng file đang mở và thử lại...");
            }

        }

        private static void FindAndReplace(Microsoft.Office.Interop.Word.Application doc, object findText, object replaceWithText)
        {
            //options
            object matchCase = false;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundsLike = false;
            object matchAllWordForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiacritics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;
            //execute find and replace
            doc.Selection.Find.Execute(ref findText, ref matchCase, ref matchWholeWord,
                ref matchWildCards, ref matchSoundsLike, ref matchAllWordForms, ref forward, ref wrap, ref format, ref replaceWithText, ref replace,
                ref matchKashida, ref matchDiacritics, ref matchAlefHamza, ref matchControl);
        }


        private static void OpenFileWithPDFSharp()
        {
            PdfDocument PDFDocTemplate = PdfReader.Open(@"D:\Template_TN1.pdf", PdfDocumentOpenMode.Import);
            PdfDocument PDFNewDocForSubmit = new PdfDocument();





            PDFNewDocForSubmit.Save(@"D:\Test2.pdf");
        }

        
    }


}
