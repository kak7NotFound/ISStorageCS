using System;
using System.Windows.Forms;

namespace ISStorageCS
{
    public partial class GoodsAcceptanceForm : Form
    {
        public GoodsAcceptanceForm()
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
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.database.ExecuteNonQuery($"insert into '{comboBox1.Text}' values ('{textBox1.Text}', '{numericUpDown1.Value}', '{numericUpDown2.Value}', '{comboBox2.Text + comboBox3.Text}', '{textBox2.Text}')");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}