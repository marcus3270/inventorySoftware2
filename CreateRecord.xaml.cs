//using ChoETL;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;


namespace MSBeverageRecordApp
{

    /// <summary>
    /// INTERACTION LOGIC FOR CreateRecord.xaml
    /// </summary>

    public partial class CreateRecord : Page {
        //GLOBAL VARIABLE
        RootObject deserializeObject = new RootObject();

        //GLOBAL CLASS FOR DATA TO SEND TO API
        class PostRecordsData {
            public int record_id { get; set; }
            public int category { get; set; }
            public int manufacturer { get; set; }
            public string model { get; set; }
            public string serial { get; set; }
            public DateTime purchase_date { get; set; }
            public decimal cost { get; set; }
            public int location { get; set; }
            public string sub_location { get; set; }
        }//end class

        //GLOBAL CLASS FOR RECORDS TABLE
        public class Records {
            public int record_id { get; set; }
            public string categoryName { get; set; }
            public string companyName { get; set; }
            public string model { get; set; }
            public string serial { get; set; }
            public DateTime purchase_date { get; set; }
            public decimal cost { get; set; }
            public string locationName { get; set; }
            public string sub_location { get; set; }
        }//end class

        //GLOBAL CLASS FOR CATEGORY TABLE
        public class Category {
            public int id { get; set; }
            public string categoryName { get; set; }
        }//end class

        //GLOBAL CLASS FOR LOCATION TABLE
        public class Location {
            public int ID { get; set; }//*NOTE- LOCATION ID IS UPPERCASE!
            public string locationName { get; set; }
        }//end class

        //GLOBAL CLASS FOR MANUFACTURER TABLE
        public class Manufacturer {
            public int id { get; set; }
            public string companyName { get; set; }
        }//end class

        //GLOBAL CLASS TO HOLD DATA
        public class RootObject {
            public int id { get; set; }
            public List<Records> Items { get; set; }
            public List<Category> CategoryItems { get; set; }
            public List<Location> LocationItems { get; set; }
            public List<Manufacturer> ManufacturerItems { get; set; }
        }//end class

        //CLASS TO GET RESPONSE FROM API
        class PostResponse {
            public int Id { get; set; }
        }//end class

        public CreateRecord() {
            InitializeComponent();

            //CALL API's FOR EACH TABLE IN DATABASE
            RecordsAPI();
            CategoryAPI();
            LocationAPI();
            ManufacturerAPI();

            //CALL CREATE COMBO BOX FUNCTIONS
            RecordIDTextBox(deserializeObject);
            CreateCategoryComboBox(deserializeObject);
            CreateLocationComboBox(deserializeObject);
            CreateManufacturerComboBox(deserializeObject);
        }//end main


        //SUMMARY OF "RecordsAPI" METHOD BELOW:
        //FETCHES DATA FROM THE SPECIFIED API ENDPOINT, ENSURES THAT THE RESPONSE IS SUCCESSFUL,
        //AND CONVERTS THE JSON DATA INTO A LIST OF RECORDS OBJECTS
        private void RecordsAPI() {

            //SETTING UP NEW INSTANCE OF A TYPE OF DATA
            using HttpClient client = new();

            //GETTING QUERY API LINK FOR OBJECT DATA 
            client.BaseAddress = new Uri("http://localhost:4001/api/records/recordsreal");

            //ADD AN "Accept" HEADER FOR JSON FORMAT.
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            //THIS IS VARIABLE TO GET OBJECT DATA FROM API
            var response = client.GetAsync(client.BaseAddress).Result;

            //IF THE "response" VARIABLE IS TRUE RUN THIS CODE.
            if (response.IsSuccessStatusCode) {

                //CONVERTING OBJECT "response" VARIABLE DATA TO STRING 
                var dataobjects = response.Content.ReadAsStringAsync().Result;

                //CHANGE OUR STRING TO OBJECT DATA
                deserializeObject.Items = JsonSerializer.Deserialize<List<Records>>(dataobjects);

            }//end if
        }//end function


        #region Category Table Combobox

        private void CategoryAPI() {

            //SETTING UP NEW INSTANCE OF A TYPE OF DATA
            using HttpClient client = new();

            //GETTING QUERY API LINK FOR OBJECT DATA 
            client.BaseAddress = new Uri("http://localhost:4001/api/category");

            //ADD AN "Accept" HEADER FOR JSON FORMAT
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            //THIS IS VARIABLE TO GET OBJECT DATA FROM API
            var response = client.GetAsync(client.BaseAddress).Result;

            //IF THE "response" VARIABLE IS TRUE RUN THIS CODE.
            if (response.IsSuccessStatusCode) {

                //CONVERTING OBJECT "response" VARIABLE DATA TO STRING 
                var dataobjects = response.Content.ReadAsStringAsync().Result;

                //CHANGE OUR STRING TO OBJECT DATA
                deserializeObject.CategoryItems = JsonSerializer.Deserialize<List<Category>>(dataobjects);

            }//end if
        }//end function


        private void CreateCategoryComboBox(RootObject list) {
            //INITIALIZE BOOL TO FALSE
            bool contains = false;

            //LOOP THROUGH LIST OF ITEMS
            for (int index = 0; index < list.CategoryItems.Count; index++) {
                //LOOP THROUGH COMBOBOX
                for (int itemIndex = 0; itemIndex < cboCategory.Items.Count; itemIndex++)

                    //IF COMBOBOX CONTAINS THE LIST ITEM
                    if (cboCategory.Items[itemIndex].ToString() == list.CategoryItems[index].categoryName) {
                        //SET CONTAINS TO TRUE, THE COMBOBOX ALREADY HAS THE LIST ITEM
                        contains = true;
                    }//end if

                //IF THE COMBOBOX DOES NOT CONTAIN THE LIST ITEM
                if (contains == false) {
                    //ADD THE LIST ITEM TO THE COMBOBOX
                    cboCategory.Items.Add(list.CategoryItems[index].categoryName);
                }//end if

            }//end for
        }//end function
        #endregion Category Table Combobox


        #region Location Table Combobox
        private void LocationAPI() {

            //SETTING UP NEW INSTANCE OF A TYPE OF DATA
            using HttpClient client = new();

            //GETTING QUERY API LINK FOR OBJECT DATA 
            client.BaseAddress = new Uri("http://localhost:4001/api/location");

            //ADD AN "Accept" HEADER FOR JSON FORMAT
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            //THIS IS VARIABLE TO GET OBJECT DATA FROM API
            var response = client.GetAsync(client.BaseAddress).Result;

            //IF THE "response" VARIABLE IS TRUE RUN THIS CODE.
            if (response.IsSuccessStatusCode) {

                //CONVERTING OBJECT "response" VARIABLE DATA TO STRING 
                var dataobjects = response.Content.ReadAsStringAsync().Result;

                //CHANGE OUR STRING TO OBJECT DATA
                deserializeObject.LocationItems = JsonSerializer.Deserialize<List<Location>>(dataobjects);

            }//end if
        }//end function


        private void CreateLocationComboBox(RootObject list) {
            //INITIALIZE BOOL TO FALSE
            bool contains = false;

            //LOOP THROUGH LIST OF ITEMS
            for (int index = 0; index < list.LocationItems.Count; index++) {
                //LOOP THROUGH COMBOBOX
                for (int itemIndex = 0; itemIndex < cboLocation.Items.Count; itemIndex++)

                    //IF COMBOBOX CONTAINS THE LIST ITEM
                    if (cboLocation.Items[itemIndex].ToString() == list.LocationItems[index].locationName) {
                        //SET CONTAINS TO TRUE, THE COMBOBOX ALREADY HAS THE LIST ITEM
                        contains = true;
                    }//end if

                //IF THE COMBOBOX DOES NOT CONTAIN THE LIST ITEM
                if (contains == false) {
                    //ADD THE LIST ITEM TO THE COMBOBOX
                    cboLocation.Items.Add(list.LocationItems[index].locationName);
                }//end if

            }//end for
        }//end function
        #endregion Location Table Combobox


        #region Manufacturer Table Combobox
        private void ManufacturerAPI() {

            //SETTING UP NEW INSTANCE OF A TYPE OF DATA
            using HttpClient client = new();

            //GETTING QUERY API LINK FOR OBJECT DATA 
            client.BaseAddress = new Uri("http://localhost:4001/api/manufacturer");

            //ADD AN "Accept" HEADER FOR JSON FORMAT
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            //THIS IS VARIABLE TO GET OBJECT DATA FROM API
            var response = client.GetAsync(client.BaseAddress).Result;

            //IF THE "response" VARIABLE IS TRUE RUN THIS CODE.
            if (response.IsSuccessStatusCode) {

                //CONVERTING OBJECT "response" VARIABLE DATA TO STRING 
                var dataobjects = response.Content.ReadAsStringAsync().Result;

                //CHANGE OUR STRING TO OBJECT DATA
                deserializeObject.ManufacturerItems = JsonSerializer.Deserialize<List<Manufacturer>>(dataobjects);

            }//end if
        }//end function


        private void CreateManufacturerComboBox(RootObject list) {
            PostRecordsData manufacturer = new PostRecordsData();

            //INITIALIZE BOOL TO FALSE
            bool contains = false;

            //LOOP THROUGH LIST OF ITEMS
            for (int index = 0; index < list.ManufacturerItems.Count; index++) {
                //LOOP THROUGH COMBOBOX
                for (int itemIndex = 0; itemIndex < cboManufacturer.Items.Count; itemIndex++)

                    //IF COMBOBOX CONTAINS THE LIST ITEM
                    if (cboManufacturer.Items[itemIndex].ToString() == list.ManufacturerItems[index].companyName) {
                        //SET CONTAINS TO TRUE, THE COMBOBOX ALREADY HAS THE LIST ITEM
                        contains = true;
                    }//end if

                //IF THE COMBOBOX DOES NOT CONTAIN THE LIST ITEM
                if (contains == false) {
                    //ADD THE LIST ITEM TO THE COMBOBOX
                    cboManufacturer.Items.Add(list.ManufacturerItems[index].companyName);
                }//end if

            }//end for

        }//end function
        #endregion Manufacturer Table Combobox


        #region RecordID
        private void RecordIDTextBox(RootObject list) {

            //INITIALIZE BOOL TO FALSE
            bool contains = false;

            //INITIALIZE CURRENT RECORDID TO ZERO
            int currentRecordID = 0;

            //LOOP THROUGH LIST OF ITEMS
            for (int index = 0; index < list.Items.Count; index++) {

                //IF CURRENT RECORD ID IS = 0
                int newCurrentRecordID = 0;

                //SET NEWCURRENTRECORDID TO INDEX OF RECORD ID
                newCurrentRecordID = list.Items[index].record_id;

                //IF NEWCURRENTRECORD ID IS GREATER THAN CURRENT VALUE OF CURRENTRECORDID
                if (newCurrentRecordID > currentRecordID) {
                    //UPDATE VALUE OF CURRENTRECORD ID 
                    currentRecordID = newCurrentRecordID;
                    //UPDATE RECORDNUMBER TEXT BOX TO CURRENTRECORDID + 1
                    recordNumber.Text = $"{currentRecordID + 1}";
                }//end if
            }//end for

        }//end RecordIDTextBox

        private void recordNumber_TextChanged(object sender, TextChangedEventArgs e) {
            //IF RECORD NUMBER TEXTBOX IS NOT EMPTY
            if (recordNumber.Text != "") {
                //HIDE THE PLACEHOLDER TEXT
                IDtxtSearchPlaceholder.Visibility = Visibility.Hidden;
            } else {
                //SHOW THE PLACEHOLDER TEXT IF TEXTBOX IS EMPTY
                IDtxtSearchPlaceholder.Visibility = Visibility.Visible;
            }//end if
        }//end event
        #endregion RecordID


        //SUMMARY OF EVENT BELOW: IF THE USER ENTERS TEXT, THE PLACEHOLDER DISAPPEARS; OTHERWISE, IT REAPPEARS.
        private void txtModel_TextChanged(object sender, TextChangedEventArgs e) {
            //IF MODEL TEXTBOX IS EMPTY
            if (txtModel.Text != "") {
                //HIDE THE PLACEHOLDER TEXT
                modeltxtSearchPlaceholder.Visibility = Visibility.Hidden;
            } else {
                //SHOW THE PLACEHOLDER TEXT IF TEXTBOX IS EMPTY
                modeltxtSearchPlaceholder.Visibility = Visibility.Visible;
            }//end if
        }//end event


        //SUMMARY OF EVENT BELOW: USER INTERACTS WITH THE "txtSerialNumber" TEXTBOX, THE PLACEHOLDER DISAPPEARS; OTHERWISE, IT REAPPEARS.
        private void txtSerialNumber_TextChanged(object sender, TextChangedEventArgs e) {
            //IF SERIAL NUMBER TEXTBOX IS EMPTY
            if (txtSerialNumber.Text != "") {
                //HIDE THE PLACEHOLDER TEXT
                serialtxtSearchPlaceholder.Visibility = Visibility.Hidden;
            } else {
                //SHOW THE PLACEHOLDER TEXT IF TEXTBOX IS EMPTY
                serialtxtSearchPlaceholder.Visibility = Visibility.Visible;
            }//end if 
        }//end event


        //SUMMARY OF EVENT BELOW: USER INTERACTS WITH THE "txtCost" TEXTBOX, THE PLACEHOLDER DISAPPEARS; OTHERWISE, IT REAPPEARS.
        private void txtCost_TextChanged(object sender, TextChangedEventArgs e) {
            //IF COST TEXTBOX IS EMPTY
            if (txtCost.Text != "") {
                //HIDE THE PLACEHOLDER TEXT
                costtxtSearchPlaceholder.Visibility = Visibility.Hidden;
            } else {
                //SHOW THE PLACEHOLDER TEXT IF TEXTBOX IS EMPTY
                costtxtSearchPlaceholder.Visibility = Visibility.Visible;
            }//end if
        }//end event


        //SUMMARY OF EVENT BELOW: USER INTERACTS WITH THE "txtSubLocation" TEXTBOX, THE PLACEHOLDER DISAPPEARS; OTHERWISE, IT REAPPEARS.
        private void txtSubLocation_TextChanged(object sender, TextChangedEventArgs e) {
            //IF SUB LOCATION TEXTBOX IS EMPTY
            if (txtSubLocation.Text != "") {
                //HIDE THE PLACEHOLDER TEXT
                subLocationtxtSearchPlaceholder.Visibility = Visibility.Hidden;
            } else {
                //SHOW THE PLACEHOLDER TEXT IF TEXTBOX IS EMPTY
                subLocationtxtSearchPlaceholder.Visibility = Visibility.Visible;
            }//end if
        }//end event


        //SUMMARY OF "PostNewRecords" METHOD BELOW:
        //COLLECTS INPUT DATA, ASSOCIATES IT WITH RELEVANT IDS, AND PREPARES IT FOR POSTING TO THE API,
        //HANDLES POSTING NEW RECORDS TO THE API, INCLUDING INPUT VALIDATION
        //AND DISPLAYING A SUCCESS MESSAGE TO THE USER
        private void PostNewRecords(RootObject list) {
            //RETRIEVE ALL INPUTS FROM CREATE RECORD PAGE
            var postData = new PostRecordsData {
                record_id = Convert.ToInt32(recordNumber.Text),
                model = txtModel.Text.ToUpper(),
                serial = txtSerialNumber.Text.ToUpper(),
                purchase_date = PurchaseDate.SelectedDate.Value,
                cost = decimal.Parse(txtCost.Text),
                sub_location = txtSubLocation.Text.ToUpper()
            };//end var postData

            //LOOP THROUGH CATEGORY TABLE ITEMS
            for (int itemIndex = 0; itemIndex < list.CategoryItems.Count; itemIndex++) {
                //IF COMBOBOX SELECTED VALUE IS EQUAL TO CATEGORY NAME AT INDEX
                if (cboCategory.SelectedValue == list.CategoryItems[itemIndex].categoryName) {
                    //SAVE ID TO POST DATA FOR CATEGORY
                    postData.category = list.CategoryItems[itemIndex].id;
                }//end if
            }//end for 

            //LOOP THROUGH LOCATION TABLE ITEMS 
            for (int itemIndex = 0; itemIndex < list.LocationItems.Count; itemIndex++) {
                //IF COMBOBOX SELECTED VALUE IS EQUAL TO LOCATION NAME AT INDEX
                if (cboLocation.SelectedValue == list.LocationItems[itemIndex].locationName) {
                    //SAVE ID TO POST DATA FOR LOCATION
                    postData.location = list.LocationItems[itemIndex].ID;
                }//end if
            }//end for

            //LOOP THROUGH MANUFACTURER TABLE ITEMS
            for (int itemIndex = 0; itemIndex < list.ManufacturerItems.Count; itemIndex++) {
                //IF COMBOBOX SELECTED VALUE IS EQUAL TO MANUFACTURER NAME AT INDEX
                if (cboManufacturer.SelectedValue == list.ManufacturerItems[itemIndex].companyName) {
                    //SAVE ID TO POST DATA FOR MANUFACTURER
                    postData.manufacturer = list.ManufacturerItems[itemIndex].id;
                }//end if
            }//end for

            //CREATING A NEW HTTPCLIENT OBJECT
            var client = new HttpClient();

            //SET BASE ADDRESS OF API
            client.BaseAddress = new Uri("http://localhost:4001/api/records/recordscreate");

            //SERIALIZE POSTDATA OBJECT TO JSON STRING
            var json = System.Text.Json.JsonSerializer.Serialize(postData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            //MAKE POST REQUEST
            var response = client.PostAsync(" ", content).Result;

            //CHECK STATUS CODE TO SEE IF REQUEST WAS SUCCESSFUL
            if (response.IsSuccessStatusCode) {
                var responseContent = response.Content.ReadAsStringAsync().Result;
                var options = new JsonSerializerOptions {
                    PropertyNameCaseInsensitive = true
                };//end var options

                //PROMPT USER THAT A NEW RECORD WAS CREATED
                MessageBox.Show("New Record Created. Please add another record, or return to main menu.");

            }//end if

        }//end function


        //SUMMARY OF EVENT BELOW: HANDLES INPUT VALIDATION, POSTS DATA TO THE API, AND REFRESHES THE PAGE AFTER SUBMISSION
        private void btnSubmit_Click(object sender, System.Windows.RoutedEventArgs e) {

            //INPUT VALIDATION
            if (string.IsNullOrEmpty(txtModel.Text) || string.IsNullOrEmpty(txtSerialNumber.Text) || string.IsNullOrEmpty(txtCost.Text) || string.IsNullOrEmpty(PurchaseDate.Text) || cboCategory.SelectedValue == null || cboLocation.SelectedValue == null || cboManufacturer.SelectedValue == null) {
                //THE TEXTBOX IS EMPTY; DISPLAY AN ERROR MESSAGE OR TAKE APPROPRIATE ACTION.
                MessageBox.Show("Please ensure all fields are completed.");
            } else {
                //POST THE NEW RECORD TO API
                PostNewRecords(deserializeObject);

                //REFRESH THE PAGE
                this.NavigationService.Refresh();

            }//end if
        }//end event

    }//end class
}//end namespace
