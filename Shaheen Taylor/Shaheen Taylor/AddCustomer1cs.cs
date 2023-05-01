using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Shaheen_Taylor
{
    public partial class AddCustomer1cs : Form
    {
        db fn = new db();
        public AddCustomer1cs()
        {
            InitializeComponent();
        }

        private bool checkIfNumberExist(string query1)
        {
            bool ifExist = false;
        
            DataSet ds = fn.getData(query1);

            //if table contain no value 
            if (ds.Tables[0].Rows.Count == 0)
            {
                ifExist = true;
            }
            // return false if found
            else
            {
                ifExist = false;
            }
            return ifExist;
        }



        private void label6_Click(object sender, EventArgs e)
        {
            string name=txtcustomername.Text;
            string phone=txtphone.Text;
            
            string address=txtaddress.Text;

            if(txtcustomername.Text.Length < 0  || txtphone.Text.Length<0 ) 
            {
                MessageBox.Show("Enter all the feilds");
                return;
            }
            if(txtphone.Text.Length>11)
            {
                MessageBox.Show("valid phone no is of 11 digit");
                return;
            }
            string noExist = "select * from customer where phoneNo='" + phone + "'";
            bool numberExist= checkIfNumberExist(noExist);
            if(!numberExist)
            {
                MessageBox.Show("Customer already exists");
                return;
            }
            string query = "insert into customer (phoneNo,address,name) values('" + phone + "','" + address + "','" + name + "') ";
            fn.setData(query, "Customer Added");

            txtcustomername.Clear();
            txtphone.Clear();
           
            txtaddress.Clear();

        }
    }
}
