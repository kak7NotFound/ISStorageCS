using System;
using System.Windows.Forms;

namespace ISStorageCS
{
    public partial class WorkingSpace : Form
    {
        public WorkingSpace()
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
            new AddCategoryForm().Show();
        }
    }
}