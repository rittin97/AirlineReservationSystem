/* Description: This form displays the user the purchased ticket with all of his/her information like first, last name, 
 * telephone number, destination city, departure city, address, flight class, departure time, arrival time, and price. This 
 * form uses data from the database file via virtual table to access data like cities, time and price, etc. 
*/
using System;
using System.Data.OleDb;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRG455_Project
{
    public partial class Form3 : Form
    {
        string sqlstr;
        DataTable vt2 = new DataTable();
        string price;
        public static bool f3;
        public Form3()
        {
            InitializeComponent();
            sqlstr = "";
            price = "";
            f3 = false;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            try
            {// oledb adapter to data like cities, price from flights table
                OleDbConnection con = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Database2.accdb");
                OleDbDataAdapter adapt = new OleDbDataAdapter();
                OleDbDataAdapter adapt2 = new OleDbDataAdapter("SELECT * FROM Flights WHERE FlightID = " + Form1.fid, "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Database2.accdb");
                adapt2.Fill(vt2);
                adapt2.Dispose();
                con.Open();
                // sets all the labels to respective text
                lblfname.Text = "First Name: " + Form2.data[0];
                lbllname.Text = "Last Name: " + Form2.data[1];
                lblAddress.Text = "Address: " + Form2.data[3];
                lblTelephone.Text = "Telephone: " + Form2.data[2];
                lblatime.Text = "Arrival Time: " + Convert.ToString(vt2.Rows[0][4]);
                lbldcity.Text = "City of Departure: " + Convert.ToString(vt2.Rows[0][1]);
                lbldtime.Text = "Departure Time: " + Convert.ToString(vt2.Rows[0][3]);
                lblfcity.Text = "City of Arrival: " + Convert.ToString(vt2.Rows[0][2]);
                if (Form2.data[4] == "Coach Class") // if coach class is chosen then price of coach class is selected to be displayed on the receipt
                {
                    lblclass.Text = Form2.data[4];
                    lblprice.Text = "Final Price: $" + Convert.ToString(Convert.ToDouble(vt2.Rows[0][10]) * 1.13);
                    price = Convert.ToString(Convert.ToDouble(vt2.Rows[0][10]) * 1.13);
                }
                else if (Form2.data[4] == "First Class") // if First class is chosen then price of First class is selected to be displayed on the receipt
                {
                    price = Convert.ToString(Convert.ToDouble(vt2.Rows[0][5]) * 1.13);
                    lblclass.Text = Form2.data[4];
                    lblprice.Text = "Final Price: $" + Convert.ToString(Convert.ToDouble(vt2.Rows[0][5]) * 1.13);
                }
                // inserts all the required data into the third table
                sqlstr = "INSERT INTO data (FirstName, LastName, Telephone, Address, CityofDepart, CityofArrival, DepartTime, ArrivalTime, Cost, Class) VALUES ('" + Form2.data[0] + "', '" + Form2.data[1] + "', '" + Form2.data[2] + "', '" + Form2.data[3] + "', '" + Convert.ToString(vt2.Rows[0][1]) + "', '" + Convert.ToString(vt2.Rows[0][2]) + "', '" + Convert.ToString(vt2.Rows[0][3]) + "', '" + Convert.ToString(vt2.Rows[0][4]) + "', '" + price + "', '" + lblclass.Text + "')";
                adapt.InsertCommand = new OleDbCommand(sqlstr, con);
                adapt.InsertCommand.ExecuteNonQuery();
                con.Close();
            }
            catch (OleDbException exc)
            {
                MessageBox.Show("Make sure that the entered value is correct");
                MessageBox.Show(exc.Message);
            }
            catch (Exception excep)
            {
                MessageBox.Show("Make sure that the entered value is correct");
                MessageBox.Show(excep.Message);
            }
        }

        private void btnclose_Click(object sender, EventArgs e)  // closes the program when this button is clicked and the whole program terminates
        {
            f3 = true;
            this.Hide();
            Application.Exit();
        }
    }
}