using System.Net.Http;
using System.Windows;
using System.Text;
using System.Text.Json;
using System.Windows.Controls;

namespace MSBeverageRecordApp {

    /// <summary>
    /// INTERACTION LOGIC FOR CategoryTable.xaml
    /// </summary>

    public partial class CategoryTable : Page {
        //CLASS TO GET RESPONSE FROM API
        class PostResponse {
            public int Id { get; set; }
        }//end class
         //GLOBAL CLASS FOR DATA TO SEND TO API
        class PostCategory {
            public string categoryName { get; set; }
        }//end class
        class PostLocation {
            public string locationName { get; set; }
        }//end class
        class PostManufacturer {
            public string companyName { get; set; }
        }//end class
        public CategoryTable() {
            InitializeComponent();
        }//end main CategoryTable

        //POST CATEGORY
        private void Category_Button_Click(object sender, RoutedEventArgs e) {
            //INPUT VALIDATION
            if (string.IsNullOrEmpty(txtCategory.Text)) {
                //THE TEXTBOX IS EMPTY; DISPLAY AN ERROR MESSAGE OR TAKE APPROPRIATE ACTION.
                MessageBox.Show("Please enter a value in the category.");
            } else {
                string input = txtCategory.Text;
                txtCategory.Text = "";

                var postData = new PostCategory {
                    categoryName = txtCategory.Text.ToUpper()
                };

                //CREATING A NEW HTTPCLIENT OBJECT
                var client = new HttpClient();

                //SET BASE ADDRESS OF API
                client.BaseAddress = new Uri("http://localhost:4001/api/category/categorycreate/");

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

                    };
                    //PROMPT USER CATEGORY IS UPDATED
                    MessageBox.Show("New Category Created");
                }//end if



                //RETURN TO MAIN MENU
                this.NavigationService.Navigate(new Uri("MenuPage.xaml", UriKind.Relative));

            }//end if
        }//end event


        //POST LOCATION
        private void Location_Button_Click(object sender, RoutedEventArgs e) {
            //INPUT VALIDATION
            if (string.IsNullOrEmpty(txtLocation.Text)) {
                //THE TEXTBOX IS EMPTY; DISPLAY AN ERROR MESSAGE OR TAKE APPROPRIATE ACTION.
                MessageBox.Show("Please enter a value in the category.");
            } else {
                string input = txtLocation.Text;
                txtLocation.Text = "";
            
                var postData = new PostLocation {
                    locationName = txtLocation.Text.ToUpper()
                };

                //CREATING A NEW HTTPCLIENT OBJECT
                var client = new HttpClient();

                //SET BASE ADDRESS OF API
                client.BaseAddress = new Uri("http://localhost:4001/api/location/locationcreate/");

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

                    };
                    //PROMPT USER CATEGORY IS UPDATED
                    MessageBox.Show("New Location Added");
                }//end if

                //RETURN TO MAIN MENU
                this.NavigationService.Navigate(new Uri("MenuPage.xaml", UriKind.Relative));

            }//end if
        }//end event


        //POST LOCATION
        private void Manufacturer_Button_Click(object sender, RoutedEventArgs e) {
            //INPUT VALIDATION
            if (string.IsNullOrEmpty(txtManufacturer.Text)) {
                //THE TEXTBOX IS EMPTY; DISPLAY AN ERROR MESSAGE OR TAKE APPROPRIATE ACTION.
                MessageBox.Show("Please enter a value in the category.");
            } else {
                string input = txtManufacturer.Text;
                txtManufacturer.Text = "";

                var postData = new PostManufacturer {
                    companyName = txtManufacturer.Text.ToUpper()
                };

                //CREATING A NEW HTTPCLIENT OBJECT
                var client = new HttpClient();

                //SET BASE ADDRESS OF API
                client.BaseAddress = new Uri("http://localhost:4001/api/manufacturer/manufacturercreate/");

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

                    };
                    //PROMPT USER CATEGORY IS UPDATED
                    MessageBox.Show("New manufacturer Added");
                }//end if

                //RETURN TO MAIN MENU
                this.NavigationService.Navigate(new Uri("MenuPage.xaml", UriKind.Relative));
            }//end if

        }//end event
    }//end class

}//end namespace
