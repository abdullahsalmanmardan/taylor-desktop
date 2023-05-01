using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using System.Collections;

namespace Shaheen_Taylor
{
    public partial class Measurement : Form
    {
        
        db fn = new db();
        public Measurement()
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

    

        
        private void btnsearch_Click(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Measurement_Load(object sender, EventArgs e)
        {
            txttotalbill.ReadOnly = true;
           
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            string phoneNo = txtcustomernumber.Text;
            string name=txtcustomername.Text;
            string address=txtcustomeraddress.Text;
            string collar = txtcollarsize.Text;
            string shoulder=txtshouldersize.Text;
            string sleeve=txtsleevesize.Text;
            string chest=txtchestsize.Text;
            string waist=txtwaistsize.Text;
            string length=txtlength.Text;
            string armhole = txtarmhole.Text;
            string trouserLength=txttrouserlength.Text;
            string trouserBottom=txttrouserbottom.Text;
            string pricePerSuit=txtpricepersuit.Text;   
            string quantity=txtquantity.Text;
            string frontPocket= cbpocket.SelectedItem.ToString();
            string sidepocket= cbsidepocket.SelectedItem.ToString();
            string notes = txtinstructions.Text;
            if (phoneNo=="")
            {
                MessageBox.Show("Enter the phone number first");
                return;
            }
            if( phoneNo.Length>0 && address.Length>0 && name.Length>0&& collar.Length > 0 && shoulder.Length>0 && sleeve.Length > 0 && chest.Length > 0 && waist.Length > 0 && length.Length > 0 && armhole.Length > 0 && trouserLength.Length > 0 && trouserBottom.Length > 0 && pricePerSuit.Length > 0 && quantity.Length>0 )
            {

                string noExist = "select * from customer where phoneNo='" + phoneNo + "'";
                bool numberExist = checkIfNumberExist(noExist);
                if (!numberExist)
                {
                    MessageBox.Show("Customer already exists");
                    return;
                }
                string query = "insert into customer (phoneNo,address,name) values('" + phoneNo + "','" + address + "','" + name + "') ";
                fn.setData(query, "Customer Added");

               
                string query1 = "insert into measurement (collar,shoulder, sleeves, chest,waist,length,armhole,trouserlength ,bottom,frontpocket,sidepocket,notes,price,phoneNo ) values('" + collar + "','" + shoulder + "','" + sleeve + "','" + chest + "','" + waist + "','" + length + "','" + armhole + "','" + trouserLength + "','" + trouserBottom + "','" + frontPocket + "','" + sidepocket + "','" + notes + "','" + pricePerSuit + "','" + phoneNo + "') ";
                fn.setData(query1, "Measurements added");

                string query2 = "select max(mid) from measurement";
                DataSet ds = fn.getData(query2);
                string midValue=ds.Tables[0].Rows[0][0].ToString();

                txttotalbill.Text = Convert.ToString( Int32.Parse(quantity) * Int32.Parse(pricePerSuit));

                string query3 = "insert into orders (orderdate,quantity,totalbill,mid,orderStatus,deliverydate) values('" + dateTimePicker1.Value.ToString() + "','" + quantity + "','" + txttotalbill.Text + "','" + midValue + "','" + "pending" + "','" + dateTimePicker3.Value.ToString() + "') ";
                fn.setData(query3, "order placed");
                clearTextFeild();
            }
            
            else
            {
                MessageBox.Show("Enter all the feilds");
                return;
            }

        }

        // clear text
        public void clearTextFeild()
        {
             txtcollarsize.Clear();
             txtshouldersize.Clear();
             txtsleevesize.Clear();
             txtchestsize.Clear();
             txtwaistsize.Clear();
             txtlength.Clear();
             txtarmhole.Clear();
             txttrouserlength.Clear();
             txttrouserbottom.Clear();
             txtpricepersuit.Clear();
             txtquantity.Clear();
             txtcustomeraddress.Clear();
            txtcustomername.Clear();
            txtcustomeraddress.Clear(); 
             txtinstructions.Clear();
        }

    }

}
