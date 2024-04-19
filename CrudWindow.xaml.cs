using System.Data;
using System.Net.Http;
//IMPORTING
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


//TODO
//

namespace MSBeverageRecordApp {

    public partial class CrudWindow : Page {

        #region OBJ CONTAINERS

        //THIS IS SETTING UP A PLACE TO STORE EACH OBJECT ATTRIBUTE INSIDE A LIST 
        public class Records {
            public int record_id { get; set; }
            public string categoryName { get; set; }
            public string companyName { get; set; }
            public string model { get; set; }
            public string serial { get; set; }
            public DateTime purchase_date { get; set; }
            public double cost { get; set; }
            public string locationName { get; set; }
            public string sub_location { get; set; }
        }//end class

        //RECORDS CLASS FOR FK'S
        public class PostRecords {
            public int record_id { get; set; }
            public int category { get; set; }
            public int manufacturer { get; set; }
            public string model { get; set; }
            public string serial { get; set; }
            public DateTime purchase_date { get; set; }
            public double cost { get; set; }
            public int location { get; set; }
            public string sub_location { get; set; }
        }//end class

        //main
        public class RootObject {
            public int id { get; set; }

            public List<Records> Items { get; set; }
        }//end class

        //post obj
        public class RootObj {
            public int id { get; set; }
            public PostRecords Items { get; set; }
        }//end class


        #region FK'S CLASSES
        public class Category {
            public int id { get; set; }
            public string categoryName { get; set; }
        }//end class
        public class Manufacture {
            public int id { get; set; }
            public string companyName { get; set; }
        }//end class
        public class Location {
            public int ID { get; set; }
            public string locationName { get; set; }
        }//end class

        //category
        public class Root {
            public int id { get; set; }

            public List<Category> Items { get; set; }
        }//end class

        //location
        public class RootLoc {
            public int id { get; set; }

            public List<Location> Items { get; set; }
        }//end class

        //manufacturer
        public class RootComp {
            public int id { get; set; }

            public List<Manufacture> Items { get; set; }
        }//end class
        #endregion

        #endregion

        #region GLOBAL VARIABLES
        //GLOBAL VARIABLE
        string file = "";
        string[] rows = new string[1];
        int colCount = 0;
        public RootObject deserializeObject = new RootObject();
        string c = "";
        Root root = new Root();
        RootLoc rootLoc = new RootLoc();
        RootComp rootComp = new RootComp();
        //RootObj postObj = new RootObj();
        PostRecords post = new PostRecords();
        double equipmentCost = 0.0;
        Records rep = new Records();
        #endregion

        public CrudWindow() {
            InitializeComponent();
            //SETTING UP NEW INSTANCE OF A TYPE OF DATA
            using HttpClient client = new();
            //GETTING QUERY API LINK FOR OBJECT DATA 
            client.BaseAddress = new Uri("http://localhost:4001/api/records/recordsreal");

            //ADD AN "Accept" HEADER FOR JSON FORMAT.
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));
            //THIS IS VARIABLE TO GET OBJECT DATA FROM API

            var response = client.GetAsync(client.BaseAddress).Result;
            //IF THE RESPONSE VARIABLE IS TRUE RUN THIS CODE.
            if (response.IsSuccessStatusCode) {
                ////CONVERTING OBJECT "response" variable DATA TO STRING 
                string dataobjects = response.Content.ReadAsStringAsync().Result;
                c = dataobjects;
                //NEED ACCESS GLOBALLY TO 
                deserializeObject.Items = JsonSerializer.Deserialize<List<Records>>(dataobjects);
                //HOW TO SET THE QUERY DATA TO THE DATAGRID ELEMENT.

                MSBeverageRecordGrid.ItemsSource = deserializeObject.Items;
                for (int i = 0; i > deserializeObject.Items.Count; i++) {
                   deserializeObject.Items[i].purchase_date.ToString("MM/dd/yy");
                }//END IF

                //PULLING THE DATA FROM EACH TABLE
                Tables();
                Locations();
                Companies();
            }//end if statusOK
        }//end main

        #region SAVE FUNCTIONS
        public void Saving(string filePath, string[] array, int num) {
            //VARIABLE
            int count = 0;
            //loop over rows and append lines
            for (int i = 0; i < array.Length; i++) {
                count++;
                System.IO.File.AppendAllText(file, array[i]);
                //START NEW LINE AFTER PRINTING EACH CELL IN A ROW
                count = 0;
            }//end for loop
        }//end function


        private void btnSave_Click(object sender, RoutedEventArgs e) {
            #region fromfile
            //rows array --> csv
            //var csv = new List<string[]>();
            //var lines = System.IO.File.ReadAllLines(@"C:\Users\MCA\source\repos\MSBeverageRecordApp\test.csv"); // csv file location

            //// loop through all lines and add it in list as string
            //foreach (string line in lines)
            //    csv.Add(line.Split(','));

            ////split string to get first line, header line as JSON properties
            //var properties = lines[0].Split(',');

            //var listObjResult = new List<Dictionary<string, string>>();

            ////loop all remaining lines, except header so starting it from 1
            //// instead of 0
            //var objResult = new Dictionary<string, string>();
            //for (int i = 1; i < lines.Length; i++) {
            //    if (i > 1) {
            //        objResult.Clear();
            //    }
            //    for (int j = 0; j < properties.Length; j++) {

            //        objResult.Add(properties[j], csv[i][j]);
            //        //clear duplicates maybe?
            //         listObjResult.Add(objResult);
            //    }
            //}
            //consoleOutput.Text = listObjResult[0]["id"].ToString(); 
            #endregion

            //FROM OBJECT
            #region from obj
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(deserializeObject.Items);
            System.IO.File.AppendAllText(@"C:\Users\MCA\source\repos\MSBeverageRecordApp\test2.txt", json);
            #endregion
        }//end event


        private void savepdf_Click(object sender, RoutedEventArgs e) {
            System.Windows.Controls.PrintDialog printDlg = new System.Windows.Controls.PrintDialog();
        }//ef
        private void print_Click(object sender, RoutedEventArgs e) {

            //PrintDG print = new PrintDG();

            //print.printDG(deserializeObject ,MSBeverageRecordGrid, "Title");
        }
        public void savecsv_Click(object sender, RoutedEventArgs e) {

            //SAVE TO CSV
            //CREATE A SAVE FILE DIALOG OBJECT
            Microsoft.Win32.SaveFileDialog sfdSave = new Microsoft.Win32.SaveFileDialog();
            //OPEN THE DIALOG AND WAIT FOR THE USER TO MAKE A SELECTION
            //FIX
            sfdSave.InitialDirectory = @"C:\";
            sfdSave.Filter = "CSV file (*.csv)|*.csv|All Files (*.*)|*.*";
            bool fileSelected = (bool)sfdSave.ShowDialog();
            file = sfdSave.FileName;
            if (fileSelected == true) {
                #region CSV
                StringBuilder sb = new StringBuilder();
                decimal totalCost = 0.0m;
                string headerline = "id, category, company, model, serial, purchase date, cost, location, sub-location, ";
                string[] cols = headerline.Split(',');
                colCount = cols.Length;
                rows = new string[deserializeObject.Items.Count + 3];
                //SET HEADERS AS FIRST ROW
                rows[0] = headerline + "\n";
                //loop over list and set values of each row into an array
                for (int i = 1; i <= deserializeObject.Items.Count; i++) {
                    //clear string on each iteration
                    sb.Clear();
                    //ADD VALUES
                    sb.Append(deserializeObject.Items[i - 1].record_id.ToString() + ",");
                    sb.Append(deserializeObject.Items[i - 1].categoryName.ToString() + ",");
                    sb.Append(deserializeObject.Items[i - 1].companyName.ToString() + ",");
                    sb.Append(deserializeObject.Items[i - 1].model.ToString() + ",");
                    sb.Append(deserializeObject.Items[i - 1].serial.ToString() + ",");
                    sb.Append(deserializeObject.Items[i - 1].purchase_date.ToString() + ",");
                    sb.Append(deserializeObject.Items[i - 1].cost.ToString() + ",");
                    sb.Append(deserializeObject.Items[i - 1].locationName.ToString() + ",");
                    sb.Append(deserializeObject.Items[i - 1].sub_location.ToString() + "\n");
                    //GET TOTAL COST
                    totalCost += (decimal)deserializeObject.Items[i - 1].cost;
                    //remove trailing comma on last row
                    if (i == deserializeObject.Items.Count) {
                        sb.Remove(sb.Length - 2, 1);
                    }
                    //ASSIGN CURRENT STRING VALUE TO BE ONE ROW
                    rows[i] = sb.ToString();
                }

                consoleOutput.Text = $"{totalCost:C}";
                sb.Clear();
                sb.Append("\ntotal equipment cost: " + totalCost.ToString());
                rows[deserializeObject.Items.Count + 1] = sb.ToString();
                #endregion
                Saving(file, rows, colCount);
            }//end if
        }//ef
        #endregion

        //UPDATE TO THE DATABASE
        private void UpdateDataBase() {
            //invalid column names 
            var postRec = new PostRecords {
                record_id = post.record_id,
                category = post.category,
                manufacturer = post.manufacturer,
                model = post.model,
                serial = post.serial,
                purchase_date = post.purchase_date,
                cost = post.cost,
                location = post.location,
                sub_location = post.sub_location
            };

            //HTTP CLIENT INSTANCE
            var client = new HttpClient();
            //CONNECTION URL
            client.BaseAddress = new Uri("http://localhost:4001/api/records/modifyid");
            var json = JsonSerializer.Serialize(postRec);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            //NO STATUS CODE?
            var response = client.PostAsync("", content).Result;
            if (response.IsSuccessStatusCode) {
                var responseContent = response.Content.ReadAsStringAsync().Result;
                var postResponse = JsonSerializer.Deserialize<Records>(responseContent);
            }
            else
            {
                System.Windows.MessageBox.Show("Error " + response.StatusCode);
            }
        }//end function


        #region MODIFY RECORDS EVENT
        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e) {

            
            //selects the row that user double clicks
            Records Reports = new Records();
            var row = sender as DataGridRow;
            rep = row.DataContext as Records;

            //FILLS EDIT WINDOW VALUES
            Reports = rep;
            txbCatName.Text = $"{Reports.categoryName}";
            txbCompName.Text = $"{Reports.companyName}";
            txbModel.Text = $"{Reports.model}";
            txbSerial.Text = $"{Reports.serial}";
            txbPurchaseDate.Text = $"{Reports.purchase_date.ToString("d")}";
            txbCost.Text = $"{Reports.cost}";
            txbLocation.Text = $"{Reports.locationName}";
            txbSubLocation.Text = $"{Reports.sub_location}";

            //SWITCH VIEWS TO EDIT WINDOW
            spLabels.Visibility = Visibility.Visible;
            spText.Visibility = Visibility.Visible;
            btnSave.Visibility = Visibility.Visible;
            btnCancel.Visibility = Visibility.Visible;

            MSBeverageRecordGrid.Visibility = Visibility.Collapsed;
            consoleOutput.Visibility = Visibility.Collapsed;
            fileMenu.Visibility = Visibility.Collapsed;
            Filter.Visibility = Visibility.Collapsed;

        }//end event


        private void btnSaveChange_Click(object sender, RoutedEventArgs e) {

            Records Reports = rep;
            for (int i = 0; i < deserializeObject.Items.Count; i++) {

                if (deserializeObject.Items[i].record_id == Reports.record_id) {

                    post.record_id = Reports.record_id;
                    post.manufacturer = rootComp.Items[i].id;
                    post.category = root.Items[i].id;
                    post.model = txbModel.Text;
                    post.serial = txbSerial.Text;
                    post.purchase_date = DateTime.Parse(txbPurchaseDate.Text);
                    post.cost = double.Parse(txbCost.Text);
                    post.location = rootLoc.Items[i].ID;
                    post.sub_location = txbSubLocation.Text;

                    deserializeObject.Items[i].categoryName = txbCatName.Text;
                    deserializeObject.Items[i].companyName = txbCompName.Text;
                    deserializeObject.Items[i].model = txbModel.Text;
                    deserializeObject.Items[i].serial = txbSerial.Text;
                    deserializeObject.Items[i].purchase_date = DateTime.Parse(txbPurchaseDate.Text);
                    deserializeObject.Items[i].cost = double.Parse(txbCost.Text);
                    deserializeObject.Items[i].locationName = txbLocation.Text;
                    deserializeObject.Items[i].sub_location = txbSubLocation.Text;
                }

                if (txbCatName.Text == root.Items[i].categoryName) {
                    post.category = root.Items[i].id;
                }

                if (txbCompName.Text == rootComp.Items[i].companyName) {
                    post.manufacturer = rootComp.Items[i].id;
                }

                if (txbLocation.Text == rootLoc.Items[i].locationName) {
                    post.location = rootLoc.Items[i].ID;
                    //WHY
                    //ALL CAP WORK - LOWERCASE NO WORK
                }

                MSBeverageRecordGrid.ItemsSource = null;
                MSBeverageRecordGrid.ItemsSource = deserializeObject.Items;

            }//end for loop

            //SWITCH VIEWS
            MSBeverageRecordGrid.Visibility = Visibility.Visible;
            consoleOutput.Visibility = Visibility.Visible;
            fileMenu.Visibility = Visibility.Visible;
            Filter.Visibility = Visibility.Visible;

            btnSave.Visibility = Visibility.Hidden;
            btnCancel.Visibility = Visibility.Hidden;

            spLabels.Visibility = Visibility.Hidden;
            spText.Visibility = Visibility.Hidden;

            //CALL UPDATE FUNCTION WHEN USER SAVES
            UpdateDataBase();
        }//end event function


        private void btnCancel_Click(object sender, RoutedEventArgs e) {
            MSBeverageRecordGrid.Visibility = Visibility.Visible;
            consoleOutput.Visibility = Visibility.Visible;
            fileMenu.Visibility = Visibility.Visible;
            Filter.Visibility = Visibility.Visible;

            btnSave.Visibility = Visibility.Hidden;
            btnCancel.Visibility = Visibility.Hidden;

            spLabels.Visibility = Visibility.Hidden;
            spText.Visibility = Visibility.Hidden;
        }//ef
        #endregion

        #region API PULL FROM DATABASE
        public void Tables() {

            //SETTING UP NEW INSTANCE OF A TYPE OF DATA
            using HttpClient client = new();
            //GETTING QUERY API LINK FOR OBJECT DATA 
            client.BaseAddress = new Uri("http://localhost:4001/api/category");

            //ADD AN "Accept" HEADER FOR JSON FORMAT.
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));
            //THIS IS VARIABLE TO GET OBJECT DATA FROM API

            var response = client.GetAsync(client.BaseAddress).Result;

            //IF THE RESPONSE VARIABLE IS TRUE RUN THIS CODE.
            if (response.IsSuccessStatusCode) {
                ////CONVERTING OBJECT "response" variable DATA TO STRING 
                string dataobjects = response.Content.ReadAsStringAsync().Result;

                //NEED ACCESS GLOBALLY TO 
                root.Items = JsonSerializer.Deserialize<List<Category>>(dataobjects);
                CreateCategoryFilterItems(root);
            }//end if statusOK
        }//end Tables function


        public void Locations() {
            //SETTING UP NEW instance of a type of data
            using HttpClient client = new();
            //GETTING QUERY API LINK FOR OBJECT DATA 
            client.BaseAddress = new Uri("http://localhost:4001/api/location");

            //ADD AN "Accept" HEADER FOR JSON FORMAT.
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));
            //THIS IS VARIABLE TO GET OBJECT DATA FROM API

            var response = client.GetAsync(client.BaseAddress).Result;

            //IF THE RESPONSE VARIABLE IS TRUE RUN THIS CODE.
            if (response.IsSuccessStatusCode) {
                ////CONVERTING OBJECT "response" variable DATA TO STRING 
                string dataobjects = response.Content.ReadAsStringAsync().Result;

                //NEED ACCESS GLOBALLY TO 
                rootLoc.Items = JsonSerializer.Deserialize<List<Location>>(dataobjects);
                CreateLocationFilterItems(rootLoc);
            }//end if statusOK
        }//end Locations function


        public void Companies() {
            //SETTING UP NEW instance of a type of data
            using HttpClient client = new();
            //GETTING QUERY API LINK FOR OBJECT DATA 
            client.BaseAddress = new Uri("http://localhost:4001/api/manufacturer");

            //ADD AN "Accept" HEADER FOR JSON FORMAT.
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));
            //THIS IS VARIABLE TO GET OBJECT DATA FROM API

            var response = client.GetAsync(client.BaseAddress).Result;

            //IF THE RESPONSE VARIABLE IS TRUE RUN THIS CODE.
            if (response.IsSuccessStatusCode) {
                ////CONVERTING OBJECT "response" variable DATA TO STRING 
                string dataobjects = response.Content.ReadAsStringAsync().Result;

                //NEED ACCESS GLOBALLY TO 
                rootComp.Items = JsonSerializer.Deserialize<List<Manufacture>>(dataobjects);
                CreateCompanyFilterItems(rootComp);
            }
        }
        #endregion

        #region THE COMBOBOX FILL UP
        private void CreateLocationFilterItems(RootLoc list) {

            bool contains = false;

            txbLocation.Items.Add("none");

            for (int index = 0; index < list.Items.Count; index++) {

                for (int itemIndex = 0; itemIndex < txbLocation.Items.Count; itemIndex++)

                    if (txbLocation.Items[itemIndex].ToString() == list.Items[index].locationName) {

                        contains = true;

                    }//end if

                if (contains == false) {

                    txbLocation.Items.Add(list.Items[index].locationName);

                }//end if

            }//end for loop
        }//end function


        private void CreateCompanyFilterItems(RootComp list) {

            bool contains = false;

            txbCompName.Items.Add("none");

            for (int index = 0; index < list.Items.Count; index++) {

                for (int itemIndex = 0; itemIndex < txbCompName.Items.Count; itemIndex++)

                    if (txbCompName.Items[itemIndex].ToString() == list.Items[index].companyName) {

                        contains = true;

                    }//end if

                if (contains == false) {

                    txbCompName.Items.Add(list.Items[index].companyName);

                }//end if

            }//end for loop
        }//end function


        private void CreateCategoryFilterItems(Root list) {

            bool contains = false;


            txbCatName.Items.Add("none");

            for (int index = 0; index < list.Items.Count; index++) {

                for (int itemIndex = 0; itemIndex < txbCatName.Items.Count; itemIndex++)

                    if (txbCatName.Items[itemIndex].ToString() == list.Items[index].categoryName) {

                        contains = true;

                    }//end if

                if (contains == false) {

                    txbCatName.Items.Add(list.Items[index].categoryName);

                }//end if

            }//end for loop
        }//end function

        
        #endregion

    }//end class
}//end namespace