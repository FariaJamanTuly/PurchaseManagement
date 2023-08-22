using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PurchaseManagement
{
    public partial class SignUp : Form
    {
        Employee objEmployee=new Employee();
        string conStr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;

        public string ImageLocation { get; private set; }

        public SignUp()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try     
            {
                objEmployee.FullName = txtFullName.Text;
                objEmployee.EmpNID = txtNID.Text;
                objEmployee.EmpEmail= txtEmail.Text;
                objEmployee.EmpAddress= txtAddress.Text;
                objEmployee.EmpPassword= txtPassword.Text;
                objEmployee.EmpUserName= txtUserName.Text;
                objEmployee.ImagePath = ImageLocation;
                SqlConnection con =new SqlConnection(conStr);
                string SqlQuery = "Insert into Employee values(@FullName,@EmpUserName,@EmpAddress,@EmpEmail,@EmpPassword,@ImagePath,@EmpNID)";
                SqlCommand cmd =new SqlCommand(SqlQuery, con);
                cmd.Parameters.AddWithValue("@FullName", objEmployee.FullName);
                cmd.Parameters.AddWithValue("@EmpNID", objEmployee.EmpNID);
                cmd.Parameters.AddWithValue("@EmpEmail", objEmployee.EmpEmail);
                cmd.Parameters.AddWithValue("@EmpAddress", objEmployee.EmpAddress);
                cmd.Parameters.AddWithValue("@EmpPassword", objEmployee.EmpPassword);
                cmd.Parameters.AddWithValue("@EmpUserName", objEmployee.EmpUserName);
                cmd.Parameters.AddWithValue("@ImagePath", objEmployee.ImagePath);
                con.Open();
                int rowCount=cmd.ExecuteNonQuery();
               
                if (rowCount > 0)
                {
                    con.Close();
                    MessageBox.Show("Registered Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Login objLogin= new Login();
                    this.Hide();
                    objLogin.ShowDialog();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog= new OpenFileDialog();
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ImageLocation=openFileDialog.FileNames.ToString();
            }
        }
    }
}
