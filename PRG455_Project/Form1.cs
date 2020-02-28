/* Name: Rittin Shingari
 * Date: April 16, 2018
 * Professor: Goran Svenk
 * Project: Airline Reservation System
 * Subject: PRG455NBBL
 * Description: This form uses various data types and other tools like datagridview, virtual table, etc for better 
 * functionality of the program. SQL commands are used to fill the datagridview with required data where user can pick
 * a specific flight by searching. User will have to enter destinationa and departure city by filling the text boxes
 * and clicking on search. Search button uses sql commands passes to database method which in turn looks up for specific 
 * columns in the database file and displays it on the datagridview.
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
    public partial class Form1 : Form
    {
        string sqlstr;
        public static int fid;
        DataTable vt = new DataTable();
        bool search;
        public Form1()
        {
            InitializeComponent();
            this.dateTimePicker1.MinDate = System.DateTime.Now;  // datatimepicker for more efficiency
            this.dateTimePicker1.Value = System.DateTime.Now;
            sqlstr = "";
            fid = 0;
            search = false;
            this.ActiveControl = txtBoxfrom;
        }

        private void database(string sqlcmd)
        {// this method recieves sql string and bool data type and and fills the datagridview with virtual table
            try  // exception handling
            {
                OleDbDataAdapter dad = new OleDbDataAdapter(sqlcmd, "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Database2.accdb");
                dad.Fill(vt);  // fills the datagridview with the contents of virtual table
                dad.Dispose();   //disposes the virtual table
                dgv1.DataSource = vt;  //sets the datasource of datagridview to the data in the virtual table
            }
            catch (OleDbException exc)  //catch statements
            {
                MessageBox.Show("Make sure that the entered value is correct");
                MessageBox.Show(exc.Message);
            }
            catch(Exception excep)
            {
                MessageBox.Show("Make sure that the entered value is correct");
                MessageBox.Show(excep.Message);
            }
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtBoxfrom.Text) && !string.IsNullOrWhiteSpace(txtBoxto.Text))  // checks if both the text boxes are null
                {
                    sqlstr = "SELECT FlightID, CityofDepart, CityofArrival, DepartTime, ArrivalTime, Price1stclass, CoachPrice FROM Flights WHERE CityofDepart LIKE '"
                                    + txtBoxfrom.Text + "' AND CityofArrival LIKE '" + txtBoxto.Text + "'"; 
                    database(sqlstr);  // passes sqlstr to database method
                    search = true;    // exits the program if search = true
                }
                else
                {
                    MessageBox.Show("Fill in the required fields to proceed");
                }
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
            this.ActiveControl = btnBuy;   // focusses on purchase tickets button after search has been pressed
        }

        private void btnExit_Click(object sender, EventArgs e)  // exits the program after exit button is pressed
        {
            Application.Exit();
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            if(search == true)  
            {
                if(Form3.f3 == true)  // if search is true and f3 from form3 is true program closes, f3 is set to true once the user clicks on close in form3 design
                {
                    Application.Exit();
                }
                fid = Convert.ToInt32(dgv1.SelectedRows[0].Cells["FlightID"].Value);  // sets the selected flight id 
                Form2 f2 = new Form2();  // new form declaration
                this.Hide();
                f2.ShowDialog();   // this form will still be open in the background
                this.Show();
            }
            else
            {
                MessageBox.Show("Search for a specific flight and then proceed by clicking on purchase.");
            }
        }
    }
}