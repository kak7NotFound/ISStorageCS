using System;
using System.Windows.Forms;

namespace ISStorageCS
{
    public partial class GoodsEditorForm : Form
    {
        public GoodsEditorForm()
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
            dataGridView1.Rows.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new AddGoodsForm(this).Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            using (var reader = Program.database.GetReader($"select * from {comboBox1.Text}"))
            {
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader.GetString(0), reader.GetInt32(1).ToString(), reader.GetInt32(2).ToString(), reader.GetString(3), reader.GetString(4)
                    );
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program.database.ExecuteNonQuery($"delete from {comboBox1.Text} where name = '{dataGridView1.CurrentRow.Cells[0].Value}'");
            dataGridView1.Rows.Clear();
            using (var reader = Program.database.GetReader($"select * from {comboBox1.Text}"))
            {
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader.GetString(0), reader.GetInt32(1).ToString(), reader.GetInt32(2).ToString(), reader.GetString(3), reader.GetString(4)
                    );
                }
            }
        }
    }
}