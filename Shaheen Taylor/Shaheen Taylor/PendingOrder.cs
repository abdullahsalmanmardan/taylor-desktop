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
    public partial class PendingOrder : Form
    {
        db fn=new db();
        public PendingOrder()
        {
            InitializeComponent();
        }

        private void PendingOrder_Load(object sender, EventArgs e)
        {
            string query1 = "SELECT * FROM Orders INNER JOIN measurement ON Orders.mid=measurement.mid and orderStatus='"+"pending"+"'";
            DataSet ds = fn.getData(query1);
            dataGridView1.DataSource = ds.Tables[0];

           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string orderid = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtorderid.Text= orderid;
            }
            catch { }
           
        }

        private void btnupdateorder_Click(object sender, EventArgs e)
        {
            string query= "UPDATE orders SET orderStatus = '"+"clear"+"' where orderid='"+txtorderid.Text+"'";
            fn.setData(query, $"order with id {txtorderid.Text} is completed");
        }
    }
}
