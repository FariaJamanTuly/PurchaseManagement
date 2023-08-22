using Microsoft.SqlServer.Server;
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
    public partial class Login : Form
    {
        string conStr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        public Login()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SignUp objSignUp= new SignUp();
            this.Hide();
            objSignUp.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
           string userName=txtName.Text;
           string pass=txtPass.Text;
           SqlConnection con=new SqlConnection(conStr);
            string SqlQuery = "SELECT * FROM Employee WHERE EmpUserName='"+ userName + "' and EmpPassword='"+ pass + "'";
            SqlCommand cmd = new SqlCommand(SqlQuery, con);
            cmd.Parameters.AddWithValue("@userName", userName);
            cmd.Parameters.AddWithValue("@pass", pass);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
           
            if (rdr.HasRows == true)
            {
                con.Close();             
                MessageBox.Show("Login Successfull", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
