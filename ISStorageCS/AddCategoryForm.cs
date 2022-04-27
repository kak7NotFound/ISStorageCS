using System;
using System.Windows.Forms;

namespace ISStorageCS
{
    public partial class AddCategoryForm : Form
    {
        public AddCategoryForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.database.ExecuteNonQuery($"create table {textBox1.Text} (item text, weight int, count int, owner text)");
            Close();
        }
    }
}