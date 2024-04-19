//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


//namespace DGVToCSV {
//    public class ExportHelper {

//        public static bool Export(DataGridView dgv) {

//            bool exported = false;

//            //list of rows
//            List<string> lines = new List<string>();
//            //header
//            DataGridViewColumnCollection header = dgv.Columns;

//            bool firstDone = false;
//            StringBuilder headerLine = new StringBuilder();
//            foreach (DataGridViewColumn col in header) {

//                if (!firstDone) {
//                    headerLine.Append(col.DataPropertyName);
//                    firstDone = true;
//                } else {
//                    headerLine.Append("," + col);

//                }
//            }

//            lines.Add(headerLine.ToString());
//            //data lines

//            foreach (DataGridViewRow row in dgv.Rows) {
//                StringBuilder dataLine = new StringBuilder();
//                firstDone = false;
//                foreach (DataGridViewCell cell in row.Cells) {
//                    if (!firstDone) {
//                        dataLine.Append(cell.Value);
//                        firstDone = true;
//                    } else {
//                        dataLine.Append("," + cell.Value);
//                    }

//                }
//                lines.Add(dataLine.ToString());
//            }


//            string file = @"C:\Users\MCA\source\repos\MSBeverageRecordApp\TextFile1.csv";
//            //loop to get whole list
//            System.IO.File.WriteAllText(file, lines[0]);
//            System.Diagnostics.Process.Start(file);

//            return exported;
//        }


//    }
//}