using System;
using System.Windows.Forms;

namespace ISStorageCS
{
    public partial class GoodsShipmentForm : Form
    {
        public GoodsShipmentForm()
        {
            InitializeComponent();
            refreshData();
        }
        
        public void refreshData()
        {
            comboBox1.Items.Clear();
            using (var reader = Program.database.GetReader("select name from Categories"))
            {
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader.GetString(0));
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count;
            using (var reader = Program.database.GetReader($"select count from {comboBox1.Text} where name = '{comboBox2.Text}'"))
            {
                reader.Read();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            using (var reader = Program.database.GetReader($"select * from {comboBox1.Text}"))
            {
                while (reader.Read())
                {
                    comboBox2.Items.Add(reader.GetString(0));
                }
            }
        }
    }
}