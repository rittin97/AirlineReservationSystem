/* Description: This form asks the user to enter the data in the text boxes. If the required class seat is unavailable then
 * the program returns the user to previous form and asks the user the enter data but with specs this time. This form is 
 * responsible for updating all the data in the flights table and inserts the new user in the customerinfo table. After 
 * purchase tickets button has been pressed then the form goes to reciept i.e., next form.
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
    public partial class Form2 : Form
    {
        public static string[] data = new string[5];  // strings for storing the data like the first and last name of user, telephone, address and flight class selection
        string sqlstr;
        DataTable vt2 = new DataTable();  // virtual table for filling in all the data from flights table with particular flight id
        DataTable vt3 = new DataTable();  // virtual table for filling in all the data from customerInfo table 
        bool duplication;
        public Form2()
        {
            InitializeComponent();
            sqlstr = "";
            duplication = false;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtAddess.Text) && !string.IsNullOrWhiteSpace(txtFirst.Text) && !string.IsNullOrWhiteSpace(txtLast.Text) && !string.IsNullOrWhiteSpace(txtNumber.Text) && !string.IsNullOrWhiteSpace(cmbuser.Text))
                {
                    OleDbConnection con = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Database2.accdb");
                    OleDbDataAdapter adapt = new OleDbDataAdapter();
                    OleDbDataAdapter adapt2 = new OleDbDataAdapter("SELECT * FROM Flights WHERE FlightID = " + Form1.fid, "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Database2.accdb");
                    OleDbDataAdapter adapt3 = new OleDbDataAdapter("SELECT * FROM CustomerInfo", "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Database2.accdb");
                    adapt2.Fill(vt2);  // fligths data
                    adapt2.Dispose();
                    adapt3.Fill(vt3);  // customerinfo data
                    adapt3.Dispose();
                    con.Open();
                    if (Convert.ToInt32(vt2.Rows[0][7]) == 0)  // goes back to previously form if the seats availale are zero
                    {
                        MessageBox.Show("Sorry no more coach class seats available. Remake different selection");
                        this.Close();
                        this.DialogResult = DialogResult.OK;
                    }
                    if (Convert.ToInt32(vt2.Rows[0][6]) == 0)  // goes back to previously form if the seats availale are zero
                    {
                        MessageBox.Show("Sorry no more first class seats available. Remake different selection");
                        this.Close();
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        for (int i = 0; i < vt3.Rows.Count; i++)  //maximum iteration less than array length to prevent index out of range
                        {
                            if (txtFirst.Text == Convert.ToString(vt3.Rows[i][1]) && txtLast.Text == Convert.ToString(vt3.Rows[i][2]) && txtNumber.Text == Convert.ToString(vt3.Rows[i][3]) && txtAddess.Text == Convert.ToString(vt3.Rows[i][4]))
                            {// if statement to check if the customer data have been used previously or not, if yes then it doesnot add the customer data in the customerinfo table
                                duplication = true;  // duplication set to true if yes
                            }
                        }

                        if (duplication != true)  // if duplication is false then customer data is inserted into customerinfo table
                        {
                            sqlstr = "INSERT INTO CustomerInfo (FirstName, LastName, Telephone, Address) VALUES ('" + txtFirst.Text + "', '" + txtLast.Text + "', '" + txtNumber.Text + "', '" + txtAddess.Text + "')";
                            adapt.InsertCommand = new OleDbCommand(sqlstr, con);
                            adapt.InsertCommand.ExecuteNonQuery();
                        }
                        if (cmbuser.SelectedItem.ToString() == "First Class" && Convert.ToInt32(vt2.Rows[0][6]) > 0)
                        { // this updates the existing flights if first class seats are chosen i.e., if user purchases a ticket then avail tickets are descreases by 1 and ticket purchases is increased by 1
                            sqlstr = "UPDATE Flights SET 1stseatsavail = " + (Convert.ToInt32(vt2.Rows[0][6]) - 1) + ", 1stseatssold = " + (Convert.ToInt32(vt2.Rows[0][7]) + 1) + " WHERE FlightID = " + Form1.fid;
                            adapt2.UpdateCommand = new OleDbCommand(sqlstr, con);
                            adapt2.UpdateCommand.ExecuteNonQuery();
                            data[4] = cmbuser.Text;
                        }

                        else if (cmbuser.SelectedItem.ToString() == "Coach Class" && Convert.ToInt32(vt2.Rows[0][8]) > 0)
                        { // this updates the existing flights if first class seats are chosen i.e., if user purchases a ticket then avail tickets are descreases by 1 and ticket purchases is increased by 1
                            sqlstr = "UPDATE Flights SET Coachseatsavail = " + (Convert.ToInt32(vt2.Rows[0][8]) - 1) + ", Coachseatssold = " + (Convert.ToInt32(vt2.Rows[0][9]) + 1) + " WHERE FlightID = " + Form1.fid;
                            adapt2.UpdateCommand = new OleDbCommand(sqlstr, con);
                            adapt2.UpdateCommand.ExecuteNonQuery();
                            data[4] = cmbuser.Text;
                        }

                        data[0] = txtFirst.Text;
                        data[1] = txtLast.Text;
                        data[2] = txtNumber.Text;
                        data[3] = txtAddess.Text;
                        con.Close();
                        Form3 f3 = new Form3();
                        this.Hide();
                        f3.ShowDialog();
                    }
                    
                } 
                else // if any of the required text box is empty display the following message
                {
                    MessageBox.Show("please fill all the required information");
                }
            }
            catch (OleDbException exc)
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

        private void btnBack_Click(object sender, EventArgs e)  // back to previous form
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnexit_Click(object sender, EventArgs e) //ex its the form  
        {
            this.Hide();
            Application.Exit();
        }

        private void Form2_Load(object sender, EventArgs e)  // load the combo box with first and coach class selection
        {
            this.ActiveControl = cmbuser;
            cmbuser.Items.Add("First Class");
            cmbuser.Items.Add("Coach Class");
        }
    }
}