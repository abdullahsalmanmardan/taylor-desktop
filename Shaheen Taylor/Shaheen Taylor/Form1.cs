namespace Shaheen_Taylor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            AddCustomer1cs ad = new AddCustomer1cs();
            ad.TopLevel = false;
            panel4.Controls.Add(ad);
            ad.Width = Screen.PrimaryScreen.Bounds.Width;
            ad.Height = Screen.PrimaryScreen.Bounds.Height - 170;
            ad.BringToFront();  
            ad.Show();
        }
       
        // search customer
        private void searchcustomer_Click(object sender, EventArgs e)
        {
            SearchCustomer ad = new SearchCustomer();
            
            ad.TopLevel = false;
            panel4.Controls.Add(ad);
            ad.BringToFront();
            ad.Show();
            ad.Width = Screen.PrimaryScreen.Bounds.Width;
            ad.Height = Screen.PrimaryScreen.Bounds.Height - 170;
            
        }
        // add customer button1
        private void addcustomer_Click(object sender, EventArgs e)
        {
            AddCustomer1cs ad = new AddCustomer1cs();
            ad.TopLevel = false;
            panel4.Controls.Add(ad);
            ad.Width = Screen.PrimaryScreen.Bounds.Width;
            ad.Height = Screen.PrimaryScreen.Bounds.Height - 170;
            ad.BringToFront();
            ad.Show();
        }

        private void addmeasurement_Click(object sender, EventArgs e)
        {
            Measurement ad = new Measurement();
            ad.TopLevel = false;
            panel4.Controls.Add(ad);
            ad.Width = Screen.PrimaryScreen.Bounds.Width;
            ad.Height = Screen.PrimaryScreen.Bounds.Height - 170;
            ad.BringToFront();
            ad.Show();
        }
    }
}